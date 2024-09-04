using Admin.NET.Core;
using DbLocalizationProvider.Abstractions;
using DbLocalizationProvider;
using DbLocalizationProvider.Storage.MySql;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using DbLocalizationProvider.Queries;
using DbLocalizationProvider.Commands;
using Furion;

namespace Ooph.Localization
{

    public class DbLangService(
            ISqlSugarClient _client
            ,Lazy<IOptions<RequestLocalizationOptions>> _requestLocalizationOptions
            ,Lazy<ICommandExecutor> commandExecutor
            ,Lazy<IQueryExecutor> queryExecutor
        ) :
        //IDynamicApiController,
        ITransient
    {
        //public Task<List<lang_res>> QueryPageResource(QueryPageResourceInput input)
        //{
        //    var res = client.Queryable<lang_res>()
        //        .WhereIF(!string.IsNullOrWhiteSpace(input.Prefix), x=>x.ResourceKey.StartsWith(input.Prefix!))
        //        .OrderBy(x=>x.ResourceKey)
        //        .ToPageListAsync(input.Page,input.PageSize);
        //    return res;
        //}

        /// <summary>
        /// 
        /// </summary>
        public async Task InitDefLangResAsync(string resourceKey, string defTranslation,string? notes = null)
        {
            //var commandExecutor = App.GetRequiredService<ICommandExecutor>();
            //var queryExecutor = App.GetRequiredService<IQueryExecutor>();
            


            var resId = await _client.Queryable<lang_res>()
                .Where(x => x.ResourceKey == resourceKey)
                .Select(x => x.Id)
                .FirstAsync();

            if (resId<=0)
            {
                //resId = (int)await _client.Insertable<lang_res>(new lang_res
                //{
                //    Id = 0,
                //    ResourceKey = resourceKey,
                //    Author = "CustomCode.DB",
                //    FromCode = true,
                //    IsHidden = false,
                //    IsModified = false,
                //    ModificationDate = DateTime.UtcNow,
                //    Notes = null,
                //}).ExecuteReturnBigIdentityAsync();

                LocalizationResource newRes = new(resourceKey, true)
                {
                    Author = "Code.DbCreate",
                    FromCode = true,
                    Notes = notes!,
                };
                //newRes.Translations.Add(new LocalizationResourceTranslation { Language = string.Empty, Value = defTranslation, });
                commandExecutor.Value.Execute(new CreateNewResource.Command(newRes));
            }

            commandExecutor.Value.Execute(
                new CreateOrUpdateTranslation.Command(resourceKey, CultureInfo.InvariantCulture, defTranslation)
                );
            commandExecutor.Value.Execute(
                    new CreateOrUpdateTranslation.Command(resourceKey, CultureInfo.DefaultThreadCurrentCulture!, defTranslation));

            
            //if (!await _client.Queryable<lang_translation>().AnyAsync(x => x.ResourceId == resId && x.Language == string.Empty))
            //{
            //    await _client.Insertable<lang_translation>(new lang_translation
            //    {
            //        Id = 0,
            //        Language = string.Empty,
            //        ResourceId = resId,
            //        Value = defTranslation,
            //        ModificationDate = DateTime.UtcNow,
            //    }).ExecuteCommandAsync();
            //}

            //if (!await _client.Queryable<lang_translation>().AnyAsync(x => x.ResourceId == resId && x.Language == CultureInfo.DefaultThreadCurrentCulture!.Name))
            //{
            //    await _client.Insertable<lang_translation>(new lang_translation
            //    {
            //        Id = 0,
            //        Language = CultureInfo.DefaultThreadCurrentCulture!.Name,
            //        ResourceId = resId,
            //        Value = defTranslation,
            //        ModificationDate = DateTime.UtcNow,
            //    }).ExecuteCommandAsync();
            //}
        }

        //public async Task<object> QueryAsync()
        //{
        //    var res = queryExecutor.Value.Execute(new GetResource.Query("DB.Ogp.GamePlatformName.CQ9"));
        //    var res1 = queryExecutor.Value.Execute(new GetAllResources.Query(true));
        //}

        public async Task<IEnumerable<TranslationItem>> QueryResources(QueryResourceInput input)
        {
            List<string> queryCultureNames = new();

            if (string.IsNullOrWhiteSpace(input.Prefix)) { return new List<TranslationItem>(); }

            if (string.IsNullOrWhiteSpace(input.Lang))
            {
                var cur = CultureInfo.CurrentCulture.Name;
                if (_requestLocalizationOptions.Value.Value.SupportedCultures == null) { throw Oops.Oh("SupportedCultures 未配置"); }

                var cultures = GetParentCultureInfos(CultureInfo.CurrentCulture);
                cultures.Insert(0, CultureInfo.CurrentCulture);
                CultureInfo? selectDefaultCulture = null;
                List<CultureInfo> queryCultures = new List<CultureInfo> { };
                foreach (var item in cultures)
                {
                    if (_requestLocalizationOptions.Value.Value.SupportedCultures.Contains(item))
                    {
                        queryCultures.Add(item);
                        selectDefaultCulture ??= item;
                    }
                }
                selectDefaultCulture ??= CultureInfo.InvariantCulture;
                if (queryCultures.Count == 0) { queryCultures.Add(new CultureInfo("en")); }
                //queryCultures.Add(CultureInfo.InvariantCulture);
                queryCultureNames = queryCultures.Select(x => x.Name).ToList();
            }
            else
            {
                queryCultureNames.Add(input.Lang);
            }

            var keyCount = await _client.Queryable<lang_res>()
            .WhereIF(!string.IsNullOrWhiteSpace(input.Prefix), x => x.ResourceKey.StartsWith(input.Prefix!))
            .OrderBy(x => x.ResourceKey)
            .Select(x => new { x.Id, /*x.ResourceKey,*/ })
            .CountAsync();

            var prefixLength = input.Prefix.Length;

            var trans = await _client.Queryable<lang_translation>()
                .LeftJoin<lang_res>((t, r) => t.ResourceId == r.Id)
                .WhereIF(!string.IsNullOrWhiteSpace(input.Prefix), (t, r) => r.ResourceKey.StartsWith(input.Prefix!))
                //.Where(t => resIds.Contains(t.ResourceId))
                .Where(t => queryCultureNames.Contains(t.Language))
                .Select((t, r) => new TranslationItem
                {
                    ResourceKeyPrefix = input.Prefix,
                    ResourceKeySuffix = r.ResourceKey.Substring(prefixLength),
                    Language = t.Language,
                    Value = t.Value,
                })
                .ToListAsync();

            if (keyCount > 0 && trans.Count < keyCount)
            {
                
                var trans1 = await _client.Queryable<lang_translation>()
                    .LeftJoin<lang_res>((t, r) => t.ResourceId == r.Id)
                    .WhereIF(!string.IsNullOrWhiteSpace(input.Prefix), (t, r) => r.ResourceKey.StartsWith(input.Prefix!))
                    .Where(t => t.Language == CultureInfo.InvariantCulture.Name)
                    .Select((t, r) => new TranslationItem
                    {
                        //ResourceKey = r.ResourceKey,
                        ResourceKeyPrefix = input.Prefix,
                        ResourceKeySuffix = r.ResourceKey.Substring(prefixLength),
                        Language = t.Language,
                        Value = t.Value,
                    })
                    .ToListAsync();
                foreach (var t in trans1)
                {
                    if (!trans.Any(x => x.ResourceKeySuffix == t.ResourceKeySuffix)) { trans.Add(t); }
                }
            }

            return trans;
        }

        private List<CultureInfo> GetParentCultureInfos(CultureInfo cultureInfo)
        {
            var list = new List<CultureInfo>();

            if (string.IsNullOrWhiteSpace(cultureInfo.Parent.Name))
            {
                list.Add(cultureInfo.Parent);
                return list;
            }
            list.Add(cultureInfo.Parent);
            list.AddRange(GetParentCultureInfos(cultureInfo.Parent));
            return list;
        }
    }

    public class QueryResourceInput
    {
        [Required]
        public string? Prefix { get; set; }
        public string? Lang { get; set; }
    }

    public class TranslationItem
    {
        /// <summary>
        /// ResourceKey 前缀
        /// </summary>
        [JsonProperty("kp")]
        public string? ResourceKeyPrefix { get; set; }
        
        /// <summary>
        /// ResourceKey 后缀
        /// </summary>
        [JsonProperty("ks")]
        public string? ResourceKeySuffix { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("L")]
        public string? Language { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [JsonProperty("V")]
        public string? Value { get; set; }
    }
}