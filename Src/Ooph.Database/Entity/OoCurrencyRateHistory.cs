using Ooph.Database.Enum;
using SqlSugar.DbConvert;

namespace Ooph.Database.Entity;

/// <summary>
/// 币种汇率历史记录
/// </summary>
[SugarTable("Oo_Currency_Rate_History", "币种汇率历史记录")]
public class OoCurrencyRateHistory
{
    /// <summary>
    /// 更新方式
    /// </summary>
    [SugarColumn(ColumnDescription = "更新方式", Length = 20)]
    public string? UpdateType { get; set; }
    /// <summary>
    /// 同步频率
    /// </summary>
    [SugarColumn(ColumnDescription = "同步频率", Length = 10)]
    public string? SyncFrequency { get; set; }

    /// <summary>
    /// 原币种类型ID
    /// </summary>
    [SugarColumn(ColumnDescription = "原币种类型", ColumnDataType = "varchar(15)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public CurrencyTypeEnum OriginalCurrency { get; set; }

    /// <summary>
    /// 兑换币种类型ID
    /// </summary>
    [SugarColumn(ColumnDescription = "兑换币种类型", ColumnDataType = "varchar(15)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public CurrencyTypeEnum ExchangeCurrency { get; set; }

    /// <summary>
    /// 汇率来源
    /// </summary>
    [SugarColumn(ColumnDescription = "汇率来源", ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public RateSourceEnum RateSource { get; set; }


    /// <summary>
    /// 市场汇率
    /// </summary>
    [SugarColumn(ColumnDescription = "市场汇率", ColumnDataType = "decimal(18, 10)")]
    public decimal? MarketRate { get; set; }

    /// <summary>
    /// 充值汇率差单位
    /// </summary>
    [SugarColumn(ColumnDescription = "充值汇率差单位", ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public RateDiffUnitTypeEnum RechargeRateDiffUnit { get; set; }
    /// <summary>
    /// 充值正负极
    /// </summary>
    [SugarColumn(ColumnDescription = "充值正负极", ColumnDataType = "varchar(10)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public PolarTypeEnum RechargePolar { get; set; }
    /// <summary>
    /// 充值汇率差
    /// </summary>
    [SugarColumn(ColumnDescription = "充值汇率差", ColumnDataType = "decimal(10, 2)")]
    public decimal? RechargeRateDiff { get; set; }

    /// <summary>
    /// 充值生效汇率
    /// </summary>
    [SugarColumn(ColumnDescription = "充值生效汇率", ColumnDataType = "decimal(18, 10)")]
    public decimal? RechargeValidRate { get; set; }

    /// <summary>
    /// 充值同步单位
    /// </summary>
    [SugarColumn(ColumnDescription = "充值同步单位", ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public RateDiffUnitTypeEnum RechargeSyncUnit { get; set; }

    /// <summary>
    /// 充值同步触发值
    /// </summary>
    [SugarColumn(ColumnDescription = "充值同步触发值", ColumnDataType = "decimal(10, 2)")]
    public decimal? RechargeSyncTrigger { get; set; }

    /// <summary>
    /// 提现汇率差单位
    /// </summary>
    [SugarColumn(ColumnDescription = "充值汇率差单位", ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public RateDiffUnitTypeEnum PayRateDiffUnit { get; set; }

    /// <summary>
    /// 提现正负极
    /// </summary>
    [SugarColumn(ColumnDescription = "提现正负极", ColumnDataType = "varchar(10)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public PolarTypeEnum PayPolar { get; set; }

    /// <summary>
    ///  提现汇率差
    /// </summary>
    [SugarColumn(ColumnDescription = "提现汇率差", ColumnDataType = "decimal(10, 2)")]
    public decimal? PayRateDiff { get; set; }

    /// <summary>
    ///  提现生效汇率
    /// </summary>
    [SugarColumn(ColumnDescription = "提现生效汇率", ColumnDataType = "decimal(18, 10)")]
    public decimal? PayValidRate { get; set; }

    /// <summary>
    ///  提现同步单位
    /// </summary>
    [SugarColumn(ColumnDescription = "提现同步单位", ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public RateDiffUnitTypeEnum PaySyncUnit { get; set; }

    /// <summary>
    ///  提现同步触发值
    /// </summary>
    [SugarColumn(ColumnDescription = "提现同步触发值", ColumnDataType = "decimal(10, 2)")]
    public decimal? PaySyncTrigger { get; set; }
    /// <summary>
    /// 生效时间
    /// </summary>
    [SugarColumn(ColumnDescription = "生效时间")]
    public DateTime? ValidTime { get; set; }
    /// <summary>
    /// 失效时间
    /// </summary>
    [SugarColumn(ColumnDescription = "失效时间")]
    public DateTime? InvalidTime { get; set; }
}