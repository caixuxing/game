// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using DbLocalizationProvider.AspNetCore;
using DbLocalizationProvider.AdminUI.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Localization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Globalization;
using DbLocalizationProvider.Storage.MySql;
using DbLocalizationProvider.Translator;
using DbLocalizationProvider.AspNetCore.ClientsideProvider.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using DbLocalizationProvider.AdminUI.AspNetCore.Areas._4D5A2189D188417485BF6C70546D34A1.Pages;
using Microsoft.AspNetCore.Localization;
using DbLocalizationProvider.Abstractions;
using Furion;
using Furion.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

namespace Ooph.Localization;

/// <summary>
/// 多语言服务拓展类
/// </summary>
[SuppressSniffer]
public static class OoLocalizationServiceCollectionExtensions
{
    public static IApplicationBuilder UseAppOoLocalizationProvider(this IApplicationBuilder app)
    {
        var options = App.GetRequiredService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);

        app.UseDbLocalizationProvider();
        app.UseDbLocalizationClientsideProvider(); //assuming that you like also Javascript
        if (App.WebHostEnvironment.EnvironmentName == "Development")
        {
            app.UseDbLocalizationProviderAdminUI();
        }
        return app;
    }

    public static IEndpointRouteBuilder MapAppOoLocalizationClientsideProvider(this IEndpointRouteBuilder build)
    {
        build.MapDbLocalizationClientsideProvider(path: "/jsl10n");
        build.MapRazorPages();

        return build;
    }

    /// <summary>
    /// 配置多语言服务
    /// </summary>
    public static IMvcBuilder AddAppOoLocalization(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.AddMvcLocalization();

        return mvcBuilder;
    }

    public static CultureInfo DefaultCulture = new("zh");

    public static List<CultureInfo> SupportedCultures = new List<CultureInfo>
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

    /// <summary>
    /// 配置多语言服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="customizeConfigure">如果传入该参数，则使用自定义多语言机制</param>
    /// <returns></returns>
    public static IServiceCollection AddAppOoLocalization(this IServiceCollection services, Action<RequestLocalizationOptions> customizeConfigure = default)
    {
        // 获取多语言配置选项
        var localizationSettings = App.GetConfig<RequestLocalizationOptions>("OOLocalization", true);

        // 使用自定义
        customizeConfigure?.Invoke(localizationSettings);
        localizationSettings.DefaultRequestCulture = new RequestCulture(DefaultCulture);

        // 注册请求多语言配置选项
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = localizationSettings.DefaultRequestCulture;
            //options.SetDefaultCulture("en");
            options.SupportedCultures = SupportedCultures;
            options.SupportedUICultures = SupportedCultures;
            options.ApplyCurrentCultureToResponseHeaders = true;
            options.FallBackToParentCultures = true;
            options.FallBackToParentUICultures = true;
        });

        // 处理多语言在 Razor 视图中文乱码问题
        //services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
        services.AddDbLocalizationProvider(cfg =>
        {
            cfg.DefaultResourceCulture = DefaultCulture;

            // configure provider
            //cfg.UseSqlServer($"{builder.Configuration.GetConnectionString("LangConnStr-SqlServer")}");
            cfg.UseMySql($"{App.Configuration["ConnectionStrings:LangConn"]}");

            //cfg.FallbackLanguages.Try(new CultureInfo("en")).Then(new CultureInfo("zh"));
            cfg.FallbackLanguages.Try(new CultureInfo("en")).Then(new CultureInfo(DefaultCulture.Name));
            cfg.ScanAllAssemblies = true;
            //cfg.EnableLocalization = ()=> { return true; };
            
            //cfg.EnableInvariantCultureFallback = true;

            cfg.ModelMetadataProviders.ReplaceProviders = true;
            cfg.FlexibleRefactoringMode = true;

            //cfg.UseAzureCognitiveServices("{access-key}", "{region}");
            //cfg.UseMyMemoryTranslator();
            cfg.UseMicrosoftEdgeTranslator();
        });

        if (App.WebHostEnvironment.EnvironmentName == "Development")
        {
            services.AddRazorPages();
            // https://github.com/valdisiljuconoks/localization-provider-core/blob/master/docs/getting-started-adminui.md AdminUI for Asp.Net Core 入门
            BasePage.PackageName_For_LocalizationProvider_AdminUI_AspNetCore = $"OO.{BasePage.PackageName_For_LocalizationProvider_AdminUI_AspNetCore_CONST}";
            services.AddDbLocalizationProviderAdminUI(c =>
            {
                //...
                c.EnableDbSearch = true;
                c.RootUrl = "/OO-LANG-AdminUi";
                c.AccessPolicyOptions = x =>
                {
                    x.AddRequirements(new CheckAdministratorsRoleRequirement());
                };
                c.CustomCssPath = "/css/custom-adminui.css";
                c.HideDeleteButton = false;
                c.ShowInvariantCulture = true;
                //ctx.DefaultView = ResourceListView.Tree;
                c.DefaultView = ResourceListView.Table;
                //c.UseAvailableLanguageListFromStorage = true;
            });
        }

        return services;
    }
}

public class CheckAdministratorsRoleRequirement : AuthorizationHandler<CheckAdministratorsRoleRequirement>, IAuthorizationRequirement
#region MyRegion
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,CheckAdministratorsRoleRequirement requirement)
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
#endregion