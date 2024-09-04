// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using DbLocalizationProvider;
using DbLocalizationProvider.Abstractions;
using Furion.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Ooph.Database.Entity;
using Ooph.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ooph.AppBackground.Service;



[ApiDescriptionSettings(Order = 100, Groups = new[] { AppConst.GroupName_Test })]
public class TestLangService : IDynamicApiController, ITransient
{
    private readonly IStringLocalizer<TestLangService> _stringLocalizer;

    public TestLangService(IStringLocalizer<TestLangService> stringLocalizer)
    {
        this._stringLocalizer = stringLocalizer;
    }

    public async Task<object> TestDbLangService([FromServices] DbLangService dbLang)
    {
        var a = await dbLang.QueryResources(new QueryResourceInput { Prefix = "Lang", Lang = "" });
        return a;
    }

    public Task<object> GetObj([FromServices]IOptions<RequestLocalizationOptions> loc, [FromServices]IStringLocalizer<TestLangService> localizer, [FromServices] IStringLocalizerFactory S, [FromServices] IStringLocalizer T)
    {
        var a = new OoGamePlatform() { PlatformCode = "CQ9",GamePlatformName = "CQ9中文" };
        var b = typeof(OoGamePlatform).GetProperties()
            .Where(x => x.Name.Contains(nameof(OoGamePlatform.PlatformCode)))
            .FirstOrDefault()?
            .GetCustomAttributes(typeof(DbLangAttribute), false)
            .Select(x=>(DbLangAttribute)x)
            .FirstOrDefault();

        //.CustomAttributes
        //.Where(x=>x.AttributeType == typeof(DbLangSetAttribute))
        //.FirstOrDefault();
        var c = b.GetTranslation(a.PlatformCode);
        var sourceKey = $"{b?.ResourceKeyPrefix}.{a.PlatformCode}";
        var sc = S.Create("","");
        var d = sc[sourceKey];
        var scAll = sc.GetAllStrings(true);

        DbLangExt.Test1();

        var f = DbLangExt.GetTranslations(b?.ResourceKeyPrefix, new[] { "CQ9" },a.GamePlatformName);
        

        // 8.1 转换文本多语言
        //var apiInterface = L.Text["API 接口"];

        // 8.2 转换 Html 多语言
        //var name = L.Html["<b>你好</b><i>{0}</i>", "名字"];

        // 8.3 设置当前语言
        //L.SetCulture("en-US");       // 默认只对下一次请求有效
        //L.SetCulture("en-US",true);  // 立即有效

        // 8.4 获取系统语言列表
        var listCultures = L.GetCultures();

        // 8.5 获取当前选中语言
        var listSelectCulture = L.GetSelectCulture();

        // 8.7 获取当前线程 UI 区域性
        // var CurrentUICulture1 = L.GetCurrentUICulture();

        // 8.6 设置当前线程 UI 区域性
        //L.SetCurrentUICulture("en-US");
        

        // 8.7 获取当前线程 UI 区域性
        var CurrentUICulture2 = L.GetCurrentUICulture();


        return Task.FromResult<object>(new
        {
           // abc = localizer.GetString(() => SampleResources.SomeCommonText),
        DefaultCulture = loc.Value.DefaultRequestCulture,
            CurrentUICulture = CurrentUICulture2,
            //apiInterface,
            //name,
            listCultures,
            //listSelectCulture, CurrentUICulture1,
            AllStrings_IncludeParentCultures = _stringLocalizer.GetAllStrings(true),
            AllCultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures).Select(x => new {
                name=x.Name,
                dname=x.DisplayName,
                ename=x.EnglishName,
                //x.IsNeutralCulture,
                x.NativeName
            })
        });
    }

    public Task<Dictionary<string,string>> GetCultures()
    {
        return Task.FromResult(L.GetCultures());
    }

    public Task<bool> SetLang(string lang = "en-US")
    {
        L.SetCulture(lang);
        return Task.FromResult(true);
    }

    public void ClearLangSet()
    {
        L.SetCulture("");
        L.SetCurrentUICulture("");
    }
}