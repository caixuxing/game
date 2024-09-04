using Microsoft.OpenApi.Interfaces;
using NetTaste;
using Ooph.Database.Enum;
using SqlSugar.DbConvert;
using System.ComponentModel.DataAnnotations.Schema;
using OBT = SqlSugar.OrderByType;

namespace Ooph.Database.Entity;

/// <summary>
/// 币种汇率配置
/// </summary>
[SugarTable("oo_currency_rate_config", "币种汇率配置")]
[SugarIndex("index_{table}_OE", [nameof(OriginalCurrency), nameof(ExchangeCurrency)], [OBT.Asc, OBT.Asc], isUnique: true)]
public class OoCurrencyRateConfig : EntityTenant
{
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
    [SugarColumn(ColumnDescription = "汇率来源",ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public RateSourceEnum RateSource { get; set; }

    /// <summary>
    /// 市场汇率
    /// </summary>
    [SugarColumn(ColumnDescription = "市场汇率", ColumnDataType = "decimal(18, 10)")]
    public decimal? MarketRate { get; set; }


    /// <summary>
    /// 设置市场汇率
    /// </summary>
    [SugarColumn(ColumnDescription = "设置市场汇率", ColumnDataType = "decimal(18, 10)")]
    public decimal? SetMarketRate { get; set; }


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
    [SugarColumn(IsIgnore = true)]
    public decimal? RechargeValidRate { get;  }

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
    private decimal? _payValidRate;
    [SugarColumn(IsIgnore = true)]
    public decimal? PayValidRate
    {
        // get;set;
        get
        {
            return _payValidRate;
        }
        private
        set
        {
            if (PayRateDiffUnit == RateDiffUnitTypeEnum.Percentage && PayPolar == PolarTypeEnum.Positive)
                value = SetMarketRate + PayRateDiff / 100m;

            if (PayRateDiffUnit == RateDiffUnitTypeEnum.Percentage && PayPolar == PolarTypeEnum.Negative)
                value = SetMarketRate - PayRateDiff / 100m;

            if (PayRateDiffUnit == RateDiffUnitTypeEnum.FixedValue && PayPolar == PolarTypeEnum.Positive)
                value = SetMarketRate + PayRateDiff;

            if (PayRateDiffUnit == RateDiffUnitTypeEnum.FixedValue && PayPolar == PolarTypeEnum.Negative)
                value = SetMarketRate - PayRateDiff;
            value = value ?? 0.00m;

        }
    }

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
}