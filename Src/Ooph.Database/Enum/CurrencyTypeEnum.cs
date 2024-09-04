using Ooph.Core.Attribute;

namespace Ooph.Database.Enum;

/// <summary>
/// 币种枚举
/// </summary>
[Description("币种枚举")]
public enum CurrencyTypeEnum
{
    /// <summary>
    /// 人民币
    /// </summary>
    [Description("人民币")]
    CNY = 0,

    /// <summary>
    /// 日元
    /// </summary>
    [Description("日元")]
    JPY = 1,

    /// <summary>
    /// 泰铢
    /// </summary>
    [Description("泰铢")]
    THB = 2,

    /// <summary>
    /// USDT
    /// </summary>
    [Description("USDT")]
    [EnumGroup((int)CurrencyCategoryEnum.Virtual)]
    USDT = 3,

    /// <summary>
    /// 越南盾
    /// </summary>
    [Description("越南盾")]
    VND = 4,

    /// <summary>
    /// 印尼盾
    /// </summary>
    [Description("印尼盾")]
    IDR = 5,

    /// <summary>
    /// 印度卢比
    /// </summary>
    [Description("印度卢比")]
    INR = 6,

    /// <summary>
    /// 韩元
    /// </summary>
    [Description("韩元")]
    KRW = 7,

    /// <summary>
    /// 巴西雷亚尔
    /// </summary>
    [Description("巴西雷亚尔")]
    BRL = 8,

    /// <summary>
    /// 墨西哥比索
    /// </summary>
    [Description("墨西哥比索")]
    MXN = 9,

    /// <summary>
    /// 欧元
    /// </summary>
    [Description("欧元")]
    EUR = 10,

    /// <summary>
    /// 俄罗斯卢布
    /// </summary>
    [Description("俄罗斯卢布")]
    RUB = 11,

    /// <summary>
    /// 缅币
    /// </summary>
    [Description("缅币")]
    MMK = 12,

    /// <summary>
    /// 菲律宾披索
    /// </summary>
    [Description("菲律宾披索")]
    PHP = 13,

    /// <summary>
    /// 柬埔寨瑞尔
    /// </summary>
    [Description("柬埔寨瑞尔")]
    KHR = 14,

    /// <summary>
    /// 孟加拉塔卡
    /// </summary>
    [Description("孟加拉塔卡")]
    BDT = 15,

    /// <summary>
    /// TRX
    /// </summary>
    [Description("TRX")]
    [EnumGroup((int)CurrencyCategoryEnum.Virtual)]
    TRX = 16,

    /// <summary>
    /// 尼日利亚奈拉
    /// </summary>
    [Description("尼日利亚奈拉")]
    NGN = 17,

    /// <summary>
    /// 土耳其里拉
    /// </summary>
    [Description("土耳其里拉")]
    TRY = 18,

    /// <summary>
    /// USDC
    /// </summary>
    [Description("USDC")]
    [EnumGroup((int)CurrencyCategoryEnum.Virtual)]
    USDC = 19,

    /// <summary>
    /// ETH
    /// </summary>
    [Description("ETH")]
    [EnumGroup((int)CurrencyCategoryEnum.Virtual)]
    ETH = 20,

    /// <summary>
    /// BTC
    /// </summary>
    [Description("BTC")]
    [EnumGroup((int)CurrencyCategoryEnum.Virtual)]
    BTC = 21,
}