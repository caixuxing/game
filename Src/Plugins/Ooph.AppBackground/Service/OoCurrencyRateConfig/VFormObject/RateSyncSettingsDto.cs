

namespace Ooph.AppBackground.Service.OoCurrencyRateConfig.VFormObject;


/// <summary>
/// 汇率同步设置VFormDto
/// </summary>
public class RateSyncSettingsDto
{
    /// <summary>
    /// 汇率充提设置
    /// </summary>
    public int DepositsWithdrawalsSet { get; set; }

    /// <summary>
    /// 更新方式
    /// </summary>
    public int UpdateType { get; set; }

    /// <summary>
    /// 更新频率
    /// </summary>
    public int Frequency { get; set; }
}
