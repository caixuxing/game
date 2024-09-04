// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Core;
using Admin.NET.Core.Service;
using AspNetCoreRateLimit;
using DbLocalizationProvider.AdminUI.AspNetCore;
using DbLocalizationProvider.AspNetCore;
using DbLocalizationProvider.AspNetCore.ClientsideProvider.Routing;
using DbLocalizationProvider.Storage.MySql;
using DbLocalizationProvider.Translator;
using Elastic.Clients.Elasticsearch.Xpack;
using Furion;
using Furion.Logging;
using Furion.Schedule;
using Furion.SpecificationDocument;
using Furion.VirtualFileServer;
//using IGeekFan.AspNetCore.Knife4jUI;
using IPTools.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using OnceMi.AspNetCore.OSS;
using SixLabors.ImageSharp.Web.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Admin.NET.Web.Core;

public class LazyLoader<T> : Lazy<T>
{
    public LazyLoader(IServiceProvider sp) : base(sp.GetRequiredService<T>)
    {
    }
}

[AppStartup(100)]
public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // 配置选项
        services.AddProjectOptions();

        // 注册Lazy https://www.cnblogs.com/eventhorizon/p/9545311.html https://www.cnblogs.com/szw/p/8985109.html
        //services.AddScoped(typeof(Lazy<>), typeof(LazyLoader<>)); // 也可以，区别不大
        services.AddTransient(typeof(Lazy<>), typeof(LazyLoader<>)); // 也可以，区别不大
        //services.AddTransient(typeof(Lazy<>)); // 直接注入可能不生效，还是会默认被初始化
        // 注入示例代码： public Home(Lazy<IUserService> userService){}

        // 缓存注册
        services.AddCache();
        // SqlSugar
        services.AddSqlSugar();
        // JWT
        services.AddJwt<JwtHandler>(enableGlobalAuthorize: true, jwtBearerConfigure: options =>
        {
            // 实现 JWT 身份验证过程控制
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var httpContext = context.HttpContext;
                    // 若请求 Url 包含 token 参数，则设置 Token 值
                    if (httpContext.Request.Query.ContainsKey("token"))
                        context.Token = httpContext.Request.Query["token"];
                    return Task.CompletedTask;
                }
            };
        }).AddSignatureAuthentication(options =>  // 添加 Signature 身份验证
        {
            options.Events = SysOpenAccessService.GetSignatureAuthenticationEventImpl();
        });

        // 允许跨域
        services.AddCorsAccessor();
        // 远程请求
        services.AddRemoteRequest(options =>
        {
            // 忽略所有客户端证书检查 需在所有客户端注册之前注册
            // options.ApproveAllCerts();

            // 配置默认 HttpClient
            options
                .AddHttpClient(string.Empty, c =>
                {
                    c.Timeout = TimeSpan.FromSeconds(10);
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .ConfigurePrimaryHttpMessageHandler(u => new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.All,
                    // 使用默认 SSL 证书 在一些情况下，可直接使用默认证书即可解决问题，如：
                    AllowAutoRedirect = true,
                    UseDefaultCredentials = true,
                    // 忽略特定客户端 SSL 证书检查
                    ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
                    // 手动指定 SSL 证书 手动配置证书
                    /*
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ClientCertificates = {
                    new X509Certificate2("...","..."),
                    new X509Certificate2("...","..."),
                    new X509Certificate2("...","...")
                    },
                    */
                    MaxConnectionsPerServer = 50,
                    UseCookies = false,
                });

        });

        // 任务队列
        services.AddTaskQueue();
        // 任务调度
        services.AddSchedule(options =>
        {
            options.AddPersistence<DbJobPersistence>(); // 添加作业持久化器
            options.AddMonitor<JobMonitor>(); // 添加作业执行监视器

            /* HTTP 请求作业通常用于定时请求/访问互联网地址 */
            /*
            options.AddHttpJob(request =>
            {
                request.RequestUri = "https://www.chinadot.net";
                request.HttpMethod = HttpMethod.Get;
                // request.Body = "{}"; // 设置请求报文体
                // request.Headers.Add("framework", "Furion"); // Furion 4.8.8.46+ 支持
                // request.GroupName = "group"; // Furion 4.8.8.46+ 支持
                // request.Description = "作业请求描述"; // Furion 4.8.8.46+ 支持
            }, Triggers.PeriodSeconds(5));
            */

            /* 委托方式作业 有时我们需要快速开启新的定时作业但不考虑后续持久化存储（如数据库存储），这时可以使用委托作业方式，如： */
            // 和 IJob 的 ExecuteAsync 方法签名一致
            /*
            options.AddJob((context, stoppingToken) =>
            {
                // 可通过 context.ServiceProvider 解析服务；框架提供了 .GetLogger() 拓展方法输出日志
                context.ServiceProvider.GetLogger().LogInformation($"{context}");
                return Task.CompletedTask;
            }, Triggers.PeriodSeconds(5));
            */

        });
        // 脱敏检测
        services.AddSensitiveDetection();

        // Json序列化设置
        static void SetNewtonsoftJsonSetting(JsonSerializerSettings setting)
        {
            setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            setting.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            setting.DateFormatString = "yyyy-MM-dd HH:mm:ss"; // 时间格式化
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // 忽略循环引用
            // setting.ContractResolver = new CamelCasePropertyNamesContractResolver(); // 解决动态对象属性名大写
            // setting.NullValueHandling = NullValueHandling.Ignore; // 忽略空值
            // setting.Converters.AddLongTypeConverters(); // long转string（防止js精度溢出） 超过17位开启
            // setting.MetadataPropertyHandling = MetadataPropertyHandling.Ignore; // 解决DateTimeOffset异常
            // setting.DateParseHandling = DateParseHandling.None; // 解决DateTimeOffset异常
            // setting.Converters.Add(new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }); // 解决DateTimeOffset异常
        };

        services
            .AddControllersWithViews()
            //.AddAppLocalization()
            .AddMvcLocalization()
            .AddNewtonsoftJson(options => SetNewtonsoftJsonSetting(options.SerializerSettings))
            //.AddXmlSerializerFormatters()
            //.AddXmlDataContractSerializerFormatters()
            .AddInjectWithUnifyResult<AdminResultProvider>();
        services.AddRazorPages();

        #region [ 多语言 ]
        var supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("zh"),
            new CultureInfo("en"),
            new CultureInfo("vi"),
            new CultureInfo("th"),
            new CultureInfo("ja"),
            new CultureInfo("kn"),
            new CultureInfo("te"),
            new CultureInfo("mr"),
            new CultureInfo("km"),
            new CultureInfo("ta"),
            new CultureInfo("my"),
            new CultureInfo("ru"),
            new CultureInfo("fr"),
            new CultureInfo("es"),
            new CultureInfo("ko"),
            new CultureInfo("pt"),
            new CultureInfo("hi"),
        };

        services.Configure<RequestLocalizationOptions>(opts =>
        {
            opts.DefaultRequestCulture = new RequestCulture("zh");
            //opts.SetDefaultCulture("en");
            opts.SupportedCultures = supportedCultures;
            opts.SupportedUICultures = supportedCultures;
            opts.ApplyCurrentCultureToResponseHeaders = true;
            opts.FallBackToParentCultures = true;
            opts.FallBackToParentUICultures = true;
        });
        services.AddDbLocalizationProvider(cfg =>
        {
            cfg.DefaultResourceCulture = new CultureInfo("zh");
            cfg.UseMySql($"{App.Configuration["ConnectionStrings:LangConn"]}");
            //cfg.AssemblyScanningFilter = (t) =>
            //{
            //    var a3s = AppDomain.CurrentDomain.GetAssemblies();
            //    return true;
            //};
            cfg.FallbackLanguages.Try(new CultureInfo("en")).Then(new CultureInfo("zh")).Then(CultureInfo.InvariantCulture);
            cfg.ScanAllAssemblies = false;
            cfg.EnableLocalization = ()=> { return true; };
            cfg.EnableInvariantCultureFallback = true;
            cfg.ModelMetadataProviders.ReplaceProviders = true;
            cfg.FlexibleRefactoringMode = true;
            //cfg.UseAzureCognitiveServices("{access-key}", "{region}");
            //cfg.UseMyMemoryTranslator();
            cfg.UseMicrosoftEdgeTranslator();
        });

        if (App.WebHostEnvironment.IsDevelopment())
        {
            // https://github.com/valdisiljuconoks/localization-provider-core/blob/master/docs/getting-started-adminui.md AdminUI for Asp.Net Core 入门
            DbLocalizationProvider.AdminUI.AspNetCore.Areas._4D5A2189D188417485BF6C70546D34A1.Pages.BasePage.PackageName_For_LocalizationProvider_AdminUI_AspNetCore = $"OO.{DbLocalizationProvider.AdminUI.AspNetCore.Areas._4D5A2189D188417485BF6C70546D34A1.Pages.BasePage.PackageName_For_LocalizationProvider_AdminUI_AspNetCore_CONST}";
            services.AddDbLocalizationProviderAdminUI(c =>
            {
                //c.EnableDbSearch = true;
                c.RootUrl = "/OO-LANG-AdminUi";
                c.AccessPolicyOptions = x => { x.AddRequirements(new CheckAdministratorsRoleRequirement()); };
                c.CustomCssPath = $"{c.RootUrl}/css/custom-adminui.css";
                c.HideDeleteButton = false;
                c.ShowInvariantCulture = true;
                c.DefaultView = ResourceListView.Table;
                //ctx.DefaultView = ResourceListView.Tree;
                //c.UseAvailableLanguageListFromStorage = true;
            });
        }
        #endregion

        // 三方授权登录OAuth
        services.AddOAuth();

        // ElasticSearch
        services.AddElasticSearch();

        // 配置Nginx转发获取客户端真实IP
        // 注1：如果负载均衡不是在本机通过 Loopback 地址转发请求的，一定要加上options.KnownNetworks.Clear()和options.KnownProxies.Clear()
        // 注2：如果设置环境变量 ASPNETCORE_FORWARDEDHEADERS_ENABLED 为 True，则不需要下面的配置代码
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.All;
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });

        // 限流服务
        services.AddInMemoryRateLimiting();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

        // 事件总线
        services.AddEventBus(options =>
        {
            options.UseUtcTimestamp = false;
            // 不启用事件日志
            options.LogEnabled = false;
            // 事件执行器（失败重试）
            options.AddExecutor<RetryEventHandlerExecutor>();
            // 事件执行器（重试后依然处理未处理异常的处理器）
            options.UnobservedTaskExceptionHandler = (obj, args) =>
            {
                if (args.Exception?.Message != null)
                    Log.Error($"EeventBus 有未处理异常 ：{args.Exception?.Message} ", args.Exception);
            };
            // 事件执行器-监视器（每一次处理都会进入）
            options.AddMonitor<EventHandlerMonitor>();

            #region Redis消息队列

            //// 替换事件源存储器
            //options.ReplaceStorer(serviceProvider =>
            //{
            //    var cacheProvider = serviceProvider.GetRequiredService<NewLife.Caching.ICacheProvider>();
            //    // 创建默认内存通道事件源对象，可自定义队列路由key，如：adminnet
            //    return new RedisEventSourceStorer(cacheProvider, "adminnet", 3000);
            //});

            #endregion Redis消息队列

            #region RabbitMQ消息队列

            //// 创建默认内存通道事件源对象，可自定义队列路由key，如：adminnet
            //var eventBusOpt = App.GetConfig<EventBusOptions>("EventBus", true);
            //var rbmqEventSourceStorer = new RabbitMQEventSourceStore(new ConnectionFactory
            //{
            //    UserName = eventBusOpt.RabbitMQ.UserName,
            //    Password = eventBusOpt.RabbitMQ.Password,
            //    HostName = eventBusOpt.RabbitMQ.HostName,
            //    Port = eventBusOpt.RabbitMQ.Port
            //}, "adminnet", 3000);

            //// 替换默认事件总线存储器
            //options.ReplaceStorer(serviceProvider =>
            //{
            //    return rbmqEventSourceStorer;
            //});

            #endregion RabbitMQ消息队列
        });

        // 图像处理
        services.AddImageSharp();

        // OSS对象存储
        var ossOpt = App.GetConfig<OSSProviderOptions>("OSSProvider", true);
        services.AddOSSService(Enum.GetName(ossOpt.Provider), "OSSProvider");

        // 模板引擎
        services.AddViewEngine();

        // 即时通讯
        services.AddSingleton<IUserIdProvider, UserIdProvider>();
        services.AddSignalR(options =>
        {
            options.KeepAliveInterval = TimeSpan.FromSeconds(10);
        })
            .AddNewtonsoftJsonProtocol(options => SetNewtonsoftJsonSetting(options.PayloadSerializerSettings))
            .AddMessagePackProtocol();

        // 系统日志
        services.AddLoggingSetup();

        // 验证码
        services.AddCaptcha();

        // 控制台logo
        //services.AddConsoleLogo();

        // 将IP地址数据库文件完全加载到内存，提升查询速度（以空间换时间，内存将会增加60-70M）
        IpToolSettings.LoadInternationalDbToMemory = true;
        // 设置默认查询器China和International
        //IpToolSettings.DefalutSearcherType = IpSearcherType.China;
        IpToolSettings.DefalutSearcherType = IpSearcherType.International;
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseForwardedHeaders();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.Use(async (context, next) =>
        {
            if (context.Response.Headers.TryGetValue("furion", out StringValues val)) { context.Response.Headers.Remove("furion"); }
            context.Response.Headers.Append("Oo", "GamePlatform");
            await next();
        });

        // 图像处理
        app.UseImageSharp();

        // 特定文件类型（文件后缀）处理
        var contentTypeProvider = FS.GetFileExtensionContentTypeProvider();
        // contentTypeProvider.Mappings[".文件后缀"] = "MIME 类型";
        app.UseStaticFiles(new StaticFileOptions
        {
            ContentTypeProvider = contentTypeProvider
        });

        //// 启用HTTPS
        //app.UseHttpsRedirection();

        // 启用OAuth
        app.UseOAuth();

        // 添加状态码拦截中间件
        app.UseUnifyResultStatusCodes();

        // 启用多语言，必须在 UseRouting 之前
        //app.UseAppLocalization();

        

        // 路由注册
        app.UseRouting();

        // 启用跨域，必须在 UseRouting 和 UseAuthentication 之间注册
        app.UseCorsAccessor();

        // 启用鉴权授权
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseDbLocalizationProvider();
        app.UseDbLocalizationClientsideProvider(); //assuming that you like also Javascript
        if (App.WebHostEnvironment.IsDevelopment()) { app.UseDbLocalizationProviderAdminUI(); }


        // 限流组件（在跨域之后）
        app.UseIpRateLimiting();
        app.UseClientRateLimiting();

        // 任务调度看板
        app.UseScheduleUI(options =>
        {
            options.RequestPath = "/oog_schedule_8eb42378";  // 必须以 / 开头且不以 / 结尾
            options.DisableOnProduction = true; // 生产环境关闭
            options.DisplayEmptyTriggerJobs = true; // 是否显示空作业触发器的作业
            options.DisplayHead = false; // 是否显示页头
            options.DefaultExpandAllJobs = false; // 是否默认展开所有作业
        });

        //// 配置Swagger-Knife4UI（路由前缀一致代表独立，不同则代表共存）
        //app.UseKnife4UI(options =>
        //{
        //    options.RoutePrefix = "kapi";
        //    foreach (var groupInfo in SpecificationDocumentBuilder.GetOpenApiGroups())
        //    {
        //        options.SwaggerEndpoint("/" + groupInfo.RouteTemplate, groupInfo.Title);
        //    }
        //});

        //app.UseRequestLocalization(new RequestLocalizationOptions
        //{
        //    ApplyCurrentCultureToResponseHeaders = true
        //});

        var options = app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);

        app.UseInject(string.Empty, options =>
        {
            foreach (var groupInfo in SpecificationDocumentBuilder.GetOpenApiGroups())
            {
                // groupInfo.Description += "<br/><u><b><font color='FF0000'> 👮不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！</font></b></u>";
                groupInfo.Description += "<br/><u><b><font style='color:gray'>Game-Platform ！</font></b></u>";
            }
        });

        app.UseEndpoints(endpoints =>
        {
            // 注册集线器
            endpoints.MapHubs();

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapDbLocalizationClientsideProvider(path: "/jsl10n");
            // http://localhost:5005/jsl10n/Lang?json&lang=zh
            if (App.WebHostEnvironment.IsDevelopment()) { endpoints.MapRazorPages(); }
        });
    }
}

public class CheckAdministratorsRoleRequirement
    : AuthorizationHandler<CheckAdministratorsRoleRequirement>, IAuthorizationRequirement
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        CheckAdministratorsRoleRequirement requirement)
    {
#if DEBUG
        context.Succeed(requirement);
#else
        if (context.User.IsInRole("Administrators")|| context.User.IsInRole("LangAdmin"))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
#endif

        return Task.CompletedTask;
    }
}
