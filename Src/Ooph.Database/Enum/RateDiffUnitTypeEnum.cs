namespace Ooph.Database.Enum;


/// <summary>
/// 汇率差异单位类型枚举
/// </summary>
[Description("汇率差异单位类型枚举")]
public enum RateDiffUnitTypeEnum
{
    /// <summary>
    /// 百分比
    /// </summary>
    [Description("百分比")]
    Percentage = 1,

    /// <summary>
    /// 固定值
    /// </summary>
    [Description("固定值")]
    FixedValue = 2
}