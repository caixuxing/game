// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Ooph.Database.Enum;

namespace Ooph.AppBackground;

/// <summary>
/// 币种汇率配置输出参数
/// </summary>
public class OoCurrencyRateConfigOutput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// 原币种类型
    /// </summary>
    public string OriginalCurrency { get; set; }
    
    /// <summary>
    /// 兑换币种类型
    /// </summary>
    public string ExchangeCurrency { get; set; }
    
    /// <summary>
    /// 汇率来源
    /// </summary>
    public RateSourceEnum RateSource { get; set; }
    
    /// <summary>
    /// 市场汇率
    /// </summary>
    public decimal? MarketRate { get; set; }
    
    /// <summary>
    /// 充值汇率差单位
    /// </summary>
    public RateDiffUnitTypeEnum RechargeRateDiffUnit { get; set; }
    
    /// <summary>
    /// 充值正负极
    /// </summary>
    public PolarTypeEnum RechargePolar { get; set; }
    
    /// <summary>
    /// 充值汇率差
    /// </summary>
    public decimal? RechargeRateDiff { get; set; }
    
    /// <summary>
    /// 充值生效汇率
    /// </summary>
    public decimal? RechargeValidRate { get; set; }
    
    /// <summary>
    /// 充值同步单位
    /// </summary>
    public RateDiffUnitTypeEnum RechargeSyncUnit { get; set; }
    
    /// <summary>
    /// 充值同步触发值
    /// </summary>
    public decimal? RechargeSyncTrigger { get; set; }
    
    /// <summary>
    /// 充值汇率差单位
    /// </summary>
    public RateDiffUnitTypeEnum PayRateDiffUnit { get; set; }
    
    /// <summary>
    /// 提现正负极
    /// </summary>
    public PolarTypeEnum PayPolar { get; set; }
    
    /// <summary>
    /// 提现汇率差
    /// </summary>
    public decimal? PayRateDiff { get; set; }
    
    /// <summary>
    /// 提现生效汇率
    /// </summary>
    public decimal? PayValidRate { get; set; }
    
    /// <summary>
    /// 提现同步单位
    /// </summary>
    public RateDiffUnitTypeEnum PaySyncUnit { get; set; }
    
    /// <summary>
    /// 提现同步触发值
    /// </summary>
    public decimal? PaySyncTrigger { get; set; }
    
    /// <summary>
    /// 租户Id
    /// </summary>
    public long? TenantId { get; set; }
    
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }
    
    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }
    
    /// <summary>
    /// 创建者Id
    /// </summary>
    public long? CreateUserId { get; set; }
    
    /// <summary>
    /// 创建者姓名
    /// </summary>
    public string? CreateUserName { get; set; }
    
    /// <summary>
    /// 修改者Id
    /// </summary>
    public long? UpdateUserId { get; set; }
    
    /// <summary>
    /// 修改者姓名
    /// </summary>
    public string? UpdateUserName { get; set; }
    
    /// <summary>
    /// 软删除
    /// </summary>
    public bool IsDelete { get; set; }
    
    }
 

