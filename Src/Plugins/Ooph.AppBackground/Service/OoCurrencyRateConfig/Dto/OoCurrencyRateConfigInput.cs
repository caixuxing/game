// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Core;
using Ooph.Database.Enum;
using System.ComponentModel.DataAnnotations;

namespace Ooph.AppBackground;

    /// <summary>
    /// 币种汇率配置基础输入参数
    /// </summary>
    public class OoCurrencyRateConfigBaseInput
    {
        /// <summary>
        /// 原币种类型
        /// </summary>
        public virtual string OriginalCurrency { get; set; }
        
        /// <summary>
        /// 兑换币种类型
        /// </summary>
        public virtual string ExchangeCurrency { get; set; }
        
        /// <summary>
        /// 汇率来源
        /// </summary>
        public virtual RateSourceEnum RateSource { get; set; }
        
        /// <summary>
        /// 市场汇率
        /// </summary>
        public virtual decimal? MarketRate { get; set; }
        
        /// <summary>
        /// 充值汇率差单位
        /// </summary>
        public virtual RateDiffUnitTypeEnum RechargeRateDiffUnit { get; set; }
        
        /// <summary>
        /// 充值正负极
        /// </summary>
        public virtual PolarTypeEnum RechargePolar { get; set; }
        
        /// <summary>
        /// 充值汇率差
        /// </summary>
        public virtual decimal? RechargeRateDiff { get; set; }
        
        /// <summary>
        /// 充值生效汇率
        /// </summary>
        public virtual decimal? RechargeValidRate { get; set; }
        
        /// <summary>
        /// 充值同步单位
        /// </summary>
        public virtual RateDiffUnitTypeEnum RechargeSyncUnit { get; set; }
        
        /// <summary>
        /// 充值同步触发值
        /// </summary>
        public virtual decimal? RechargeSyncTrigger { get; set; }
        
        /// <summary>
        /// 充值汇率差单位
        /// </summary>
        public virtual RateDiffUnitTypeEnum PayRateDiffUnit { get; set; }
        
        /// <summary>
        /// 提现正负极
        /// </summary>
        public virtual PolarTypeEnum PayPolar { get; set; }
        
        /// <summary>
        /// 提现汇率差
        /// </summary>
        public virtual decimal? PayRateDiff { get; set; }
        
        /// <summary>
        /// 提现生效汇率
        /// </summary>
        public virtual decimal? PayValidRate { get; set; }
        
        /// <summary>
        /// 提现同步单位
        /// </summary>
        public virtual RateDiffUnitTypeEnum PaySyncUnit { get; set; }
        
        /// <summary>
        /// 提现同步触发值
        /// </summary>
        public virtual decimal? PaySyncTrigger { get; set; }
        
        /// <summary>
        /// 租户Id
        /// </summary>
        public virtual long? TenantId { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }
        
        /// <summary>
        /// 创建者Id
        /// </summary>
        public virtual long? CreateUserId { get; set; }
        
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public virtual string? CreateUserName { get; set; }
        
        /// <summary>
        /// 修改者Id
        /// </summary>
        public virtual long? UpdateUserId { get; set; }
        
        /// <summary>
        /// 修改者姓名
        /// </summary>
        public virtual string? UpdateUserName { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        public virtual bool IsDelete { get; set; }
        
    }

    /// <summary>
    /// 币种汇率配置分页查询输入参数
    /// </summary>
    public class OoCurrencyRateConfigInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 原币种类型
        /// </summary>
        public string? OriginalCurrency { get; set; }
        
        /// <summary>
        /// 兑换币种类型
        /// </summary>
        public string? ExchangeCurrency { get; set; }
        
        /// <summary>
        /// 汇率来源
        /// </summary>
        public RateSourceEnum? RateSource { get; set; }
        
    }

    /// <summary>
    /// 币种汇率配置增加输入参数
    /// </summary>
    public class AddOoCurrencyRateConfigInput : OoCurrencyRateConfigBaseInput
    {
        /// <summary>
        /// 原币种类型
        /// </summary>
        [Required(ErrorMessage = "原币种类型不能为空")]
        public override string OriginalCurrency { get; set; }
        
        /// <summary>
        /// 兑换币种类型
        /// </summary>
        [Required(ErrorMessage = "兑换币种类型不能为空")]
        public override string ExchangeCurrency { get; set; }
        
        /// <summary>
        /// 汇率来源
        /// </summary>
        [Required(ErrorMessage = "汇率来源不能为空")]
        public override RateSourceEnum RateSource { get; set; }
        
        /// <summary>
        /// 充值汇率差单位
        /// </summary>
        [Required(ErrorMessage = "充值汇率差单位不能为空")]
        public override RateDiffUnitTypeEnum RechargeRateDiffUnit { get; set; }
        
        /// <summary>
        /// 充值正负极
        /// </summary>
        [Required(ErrorMessage = "充值正负极不能为空")]
        public override PolarTypeEnum RechargePolar { get; set; }
        
        /// <summary>
        /// 充值同步单位
        /// </summary>
        [Required(ErrorMessage = "充值同步单位不能为空")]
        public override RateDiffUnitTypeEnum RechargeSyncUnit { get; set; }
        
        /// <summary>
        /// 充值汇率差单位
        /// </summary>
        [Required(ErrorMessage = "充值汇率差单位不能为空")]
        public override RateDiffUnitTypeEnum PayRateDiffUnit { get; set; }
        
        /// <summary>
        /// 提现正负极
        /// </summary>
        [Required(ErrorMessage = "提现正负极不能为空")]
        public override PolarTypeEnum PayPolar { get; set; }
        
        /// <summary>
        /// 提现同步单位
        /// </summary>
        [Required(ErrorMessage = "提现同步单位不能为空")]
        public override RateDiffUnitTypeEnum PaySyncUnit { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        [Required(ErrorMessage = "软删除不能为空")]
        public override bool IsDelete { get; set; }
        
    }

    /// <summary>
    /// 币种汇率配置删除输入参数
    /// </summary>
    public class DeleteOoCurrencyRateConfigInput : BaseIdInput
    {
    }

    /// <summary>
    /// 币种汇率配置更新输入参数
    /// </summary>
    public class UpdateOoCurrencyRateConfigInput : OoCurrencyRateConfigBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 币种汇率配置主键查询输入参数
    /// </summary>
    public class QueryByIdOoCurrencyRateConfigInput : DeleteOoCurrencyRateConfigInput
    {

    }
