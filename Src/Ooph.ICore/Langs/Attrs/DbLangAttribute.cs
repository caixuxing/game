// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using DbLocalizationProvider;
using DbLocalizationProvider.Abstractions;
using DbLocalizationProvider.Commands;
using Furion;
using Furion.DependencyInjection;
using Microsoft.Extensions.Localization;
using NewLife.Caching;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Ooph;

/// <summary>
/// 多语言设置
/// </summary>
[SuppressSniffer]
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class DbLangAttribute : Attribute
{
    public string ResourceKeyPrefix { get; }

    public DbLangAttribute(string resourceKeyPrefix, [CallerMemberName] string memberName = "")
    {
        ResourceKeyPrefix = $"{resourceKeyPrefix}.{memberName}".TrimEnd('.');
    }

    public void AddResourceAndTranslation(string suffix,string value,string lang = "")
    {
        var resResp = App.GetRequiredService<IResourceRepository>();
        resResp.AddTranslation(
                new LocalizationResource {
                    Id = 0,
                    Author = "CustomCode",
                    FromCode = true,
                    IsHidden = false,
                    IsModified = false,
                    ModificationDate = DateTime.UtcNow,
                    Notes = $"From {nameof(DbLangAttribute)} Create",
                    ResourceKey = $"{ResourceKeyPrefix}.{suffix}",
                },
                new LocalizationResourceTranslation {
                    Id = 0,
                    ResourceId = 0,
                    ModificationDate = DateTime.UtcNow,
                    Language = lang,
                    Value = value,
                }
            );
    }

    public string GetTranslation(string suffix, string lang = "",string defaultVal = "")
    {
        if (string.IsNullOrEmpty(suffix)) { throw new ArgumentNullException("suffix"); }
        if (string.IsNullOrEmpty(lang)) { lang = CultureInfo.CurrentCulture.Name; }
        var resResp = App.GetRequiredService<IResourceRepository>();
        var langRes = resResp.GetByKey($"{ResourceKeyPrefix}.{suffix}");
        var tran = langRes?.Translations.Where(x => x.Language == lang).Select(x => x.Value).FirstOrDefault();

        if (string.IsNullOrWhiteSpace(tran)) { tran = langRes?.Translations?.Where(x => x.Language == string.Empty).Select(x => x.Value).FirstOrDefault(); }

        return string.IsNullOrWhiteSpace(tran) ? defaultVal : tran;
    }
}

public static class DbLangExt
{
    public static void Test1()
    {
        var local = App.GetRequiredService<IStringLocalizer<object>>();
        var aaa = local.GetString("DB.Ogp.GamePlatformName.CQ9",new CultureInfo("zh"));



        var commandExecutor = App.GetRequiredService<ICommandExecutor>();
        var queryExecutor = App.GetRequiredService<IQueryExecutor>();
        var newRes = new LocalizationResource(
                $"existingResource.ResourceKey-{DateTime.Now:yyyyMMdd.HHmmss}",
                true)
        {
            Author = "Code.DbCreate",
             FromCode = true,
              Notes = null,
        };
        newRes.Translations.Add(new LocalizationResourceTranslation { Language = string.Empty, Value = "translation.Value111", });
        commandExecutor.Execute(new CreateNewResource.Command(newRes));
        commandExecutor.Execute(new CreateOrUpdateTranslation.Command(
                newRes.ResourceKey,
                CultureInfo.InvariantCulture,
                "translation.Value111")
            );
        commandExecutor.Execute(new CreateOrUpdateTranslation.Command(
                newRes.ResourceKey,
                CultureInfo.DefaultThreadCurrentCulture!,
                "translation.Value111")
            );



        
        var res2 = local.GetString(newRes.ResourceKey);

        var res = queryExecutor.Execute(new DbLocalizationProvider.Queries.GetResource.Query("DB.Ogp.GamePlatformName.CQ9"));
        var res1 = queryExecutor.Execute(new DbLocalizationProvider.Queries.GetAllResources.Query(true));

    }

    public static Dictionary<string, string> GetTranslations(string resKeyPrefix, IEnumerable<string> suffixs,string InvariantCultureValue)
    {
        //var cache = App.GetRequiredService<ICacheProvider>();
        var local = App.GetRequiredService<ILocalizationProvider>();
        var res = new Dictionary<string, string>();
        foreach (var suffix in suffixs)
        {
            var val = local.GetString($"{resKeyPrefix}.{suffix}");
            if (val == null) {
                var resResp = App.GetRequiredService<IResourceRepository>();
                AddTranslation(resResp, CultureInfo.InvariantCulture.Name, $"{resKeyPrefix}.{suffix}",  InvariantCultureValue);
                AddTranslation(resResp, CultureInfo.DefaultThreadCurrentCulture?.Name ?? "cn", $"{resKeyPrefix}.{suffix}",   InvariantCultureValue);
                val = InvariantCultureValue;
            }
            res.Add(suffix, val);
        }
        return res;
    }

    private static void AddTranslation(IResourceRepository resResp,string lang, string resourceKey, string val)
    {
        resResp.AddTranslation(
                            new LocalizationResource
                            {
                                Id = 0,
                                Author = "CustomCode",
                                FromCode = true,
                                IsHidden = false,
                                IsModified = false,
                                ModificationDate = DateTime.UtcNow,
                                Notes = $"From {nameof(DbLangAttribute)} Create",
                                ResourceKey = resourceKey,
                            },
                            new LocalizationResourceTranslation
                            {
                                Id = 0,
                                ResourceId = 0,
                                ModificationDate = DateTime.UtcNow,
                                Language = lang,
                                Value = val,
                            }
                        );
    }
}
