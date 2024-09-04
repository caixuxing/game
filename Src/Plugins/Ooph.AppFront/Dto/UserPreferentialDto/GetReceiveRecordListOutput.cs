// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.AppFront.Dto.UserPreferentialDto;
public class GetReceiveRecordListOutput
{
    /// <summary>  
    /// 单号，用于唯一标识该记录  
    /// </summary>  
    public string? OrderNumber { get; set; }

    /// <summary>  
    /// 会员的唯一标识符  
    /// </summary>  
    public long? MemberId { get; set; }

    /// <summary>  
    /// 会员的账号名称  
    /// </summary>  
    public string? MemberAccount { get; set; }

    /// <summary>  
    /// 会员使用的币种  
    /// </summary>  
    public string? CurrencyTypeName { get; set; }

    /// <summary>  
    /// 优惠的唯一标识符  
    /// </summary>  
    public int? OffersID { get; set; }

    /// <summary>  
    /// 优惠的名称  
    /// </summary>  
    public string? OfferName { get; set; }

    /// <summary>  
    /// 优惠来源，如活动、推广等  
    /// </summary>  
    public string? OffersSource { get; set; }

    /// <summary>  
    /// 来源类型，可能用于区分不同的来源渠道或方式  
    /// </summary>  
    public string? SourceType { get; set; }

    /// <summary>  
    /// 优惠类型，如折扣、满减、赠品等  
    /// </summary>  
    public string? OffersType { get; set; }

    /// <summary>  
    /// 优惠可领取的开始时间  
    /// </summary>  
    public DateTime? OffersStartTime { get; set; }

    /// <summary>  
    /// 优惠的过期时间，超过此时间则无法领取  
    /// </summary>  
    public DateTime? OffersExpiryTime { get; set; }

    /// <summary>  
    /// 奖励的详细说明  
    /// </summary>  
    public string? RewardDescription { get; set; }

    /// <summary>  
    /// 奖励的金额，如果适用  
    /// </summary>  
    public decimal? RewardAmount { get; set; }

    /// <summary>  
    /// 稽核倍数，用于计算最终奖励的倍数（如果适用）  
    /// </summary>  
    public decimal? AuditMultiplier { get; set; }

    /// <summary>  
    /// 前台显示的备注信息，可能用于用户界面的展示  
    /// </summary>  
    public string? FrontEndNote { get; set; }


}
