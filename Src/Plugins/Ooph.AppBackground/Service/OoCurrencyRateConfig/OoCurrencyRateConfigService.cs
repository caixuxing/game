
using DbLocalizationProvider.Internal;
using Ooph.Database.Entity;
namespace Ooph.AppBackground;

/// <summary>
/// 币种汇率配置服务
/// </summary>
[ApiDescriptionSettings(Order = 100, Groups = new[] { AppConst.GroupName_Test })]
public class OoCurrencyRateConfigService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<OoCurrencyRateConfig> _ooCurrencyRateConfigRep;
    public OoCurrencyRateConfigService(SqlSugarRepository<OoCurrencyRateConfig> ooCurrencyRateConfigRep)
    {
        _ooCurrencyRateConfigRep = ooCurrencyRateConfigRep;
    }

    /// <summary>
    /// 分页查询币种汇率配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    [DisplayName("分页查询币种汇率配置")]
    public async Task<SqlSugarPagedList<OoCurrencyRateConfigOutput>> Page(OoCurrencyRateConfigInput input)
    {
		input.SearchKey = input.SearchKey?.Trim();
        var query = _ooCurrencyRateConfigRep.AsQueryable()
            .WhereIF(!string.IsNullOrEmpty(input.SearchKey), u =>
                u.OriginalCurrency.ToString().Contains(input.SearchKey!)
                || u.ExchangeCurrency.ToString().Contains(input.SearchKey!)
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.OriginalCurrency), u => u.OriginalCurrency.ToString().Contains(input.OriginalCurrency!.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ExchangeCurrency), u => u.ExchangeCurrency.ToString().Contains(input.ExchangeCurrency!.Trim()))
            .WhereIF(input.RateSource.HasValue, u => u.RateSource == input.RateSource)
            .Select<OoCurrencyRateConfigOutput>();
		var data= await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
        return data;
    }

    /// <summary>
    /// 增加币种汇率配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    [DisplayName("增加币种汇率配置")]
    public async Task<long> Add(AddOoCurrencyRateConfigInput input)
    {
        var entity = input.Adapt<OoCurrencyRateConfig>();
        await _ooCurrencyRateConfigRep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除币种汇率配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    [DisplayName("删除币种汇率配置")]
    public async Task Delete(DeleteOoCurrencyRateConfigInput input)
    {
        var entity = await _ooCurrencyRateConfigRep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _ooCurrencyRateConfigRep.FakeDeleteAsync(entity);   //假删除
        //await _ooCurrencyRateConfigRep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新币种汇率配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    [DisplayName("更新币种汇率配置")]
    public async Task Update(UpdateOoCurrencyRateConfigInput input)
    {
        var entity = input.Adapt<OoCurrencyRateConfig>();
        await _ooCurrencyRateConfigRep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取币种汇率配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    [DisplayName("获取币种汇率配置")]
    public async Task<OoCurrencyRateConfig> Detail([FromQuery] QueryByIdOoCurrencyRateConfigInput input)
    {
        return await _ooCurrencyRateConfigRep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取币种汇率配置列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    [DisplayName("获取币种汇率配置列表")]
    public async Task<List<OoCurrencyRateConfigOutput>> List([FromQuery] OoCurrencyRateConfigInput input)
    {
        return await _ooCurrencyRateConfigRep.AsQueryable().Select<OoCurrencyRateConfigOutput>().ToListAsync();
    }





}
