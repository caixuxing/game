using System.ComponentModel;
namespace Ooph.Database.Enum;

/// <summary>
/// 汇率来源
/// </summary>

[Description("汇率来源")]
public enum RateSourceEnum
{
    /// <summary>
    /// 国际离岸汇率
    /// </summary>
    [Description("国际离岸汇率")]
    IntlOffshore = 1,

    /// <summary>
    /// OKexOTC购买
    /// </summary>
    [Description("OKexOTC购买")]
    OKexBuy = 2,

    /// <summary>
    /// 币安OTC购买
    /// </summary>
    [Description("币安OTC购买")]
    BinanceBuy = 3,

    /// <summary>
    /// 币安OTC出售
    /// </summary>
    [Description("币安OTC出售")]
    BinanceSell = 4
}