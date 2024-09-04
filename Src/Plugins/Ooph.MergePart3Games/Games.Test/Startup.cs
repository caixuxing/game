// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Furion;
using Furion.Logging;
using Furion.SpecificationDocument;
using Furion.VirtualFileServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Admin.NET.Web.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // 允许跨域
        services.AddCorsAccessor();
        // 远程请求
        services.AddRemoteRequest(x =>
        {
            x.AddHttpClient(string.Empty, c =>
            {
                c.Timeout = TimeSpan.FromSeconds(10);
                //c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All });
        });

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

        services.AddControllersWithViews()
            .AddAppLocalization()
            .AddNewtonsoftJson(options => SetNewtonsoftJsonSetting(options.SerializerSettings))
            .AddInject();

        // 配置Nginx转发获取客户端真实IP
        // 注1：如果负载均衡不是在本机通过 Loopback 地址转发请求的，一定要加上options.KnownNetworks.Clear()和options.KnownProxies.Clear()
        // 注2：如果设置环境变量 ASPNETCORE_FORWARDEDHEADERS_ENABLED 为 True，则不需要下面的配置代码
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.All;
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });

        // 模板引擎
        services.AddViewEngine();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        AppContext.SetSwitch("System.Net.DisableIPv6", true);

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
            context.Response.Headers.Append("Ooph", "GamePlatform");
            await next();
        });

        // 特定文件类型（文件后缀）处理
        var contentTypeProvider = FS.GetFileExtensionContentTypeProvider();
        // contentTypeProvider.Mappings[".文件后缀"] = "MIME 类型";
        app.UseStaticFiles(new StaticFileOptions
        {
            ContentTypeProvider = contentTypeProvider
        });

        //// 启用HTTPS
        //app.UseHttpsRedirection();

        // 添加状态码拦截中间件
        app.UseUnifyResultStatusCodes();

        // 启用多语言，必须在 UseRouting 之前
        app.UseAppLocalization();

        // 路由注册
        app.UseRouting();

        // 启用跨域，必须在 UseRouting 和 UseAuthentication 之间注册
        app.UseCorsAccessor();

        // 启用鉴权授权
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseInject(string.Empty, options =>
        {
            foreach (var groupInfo in SpecificationDocumentBuilder.GetOpenApiGroups())
            {
                groupInfo.Description += "<br/><u><b><font style='color:gray'>Game-Platform！</font></b></u>";
            }
        });

        app.UseEndpoints(endpoints =>
        {
            // 注册集线器
            endpoints.MapHubs();

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}