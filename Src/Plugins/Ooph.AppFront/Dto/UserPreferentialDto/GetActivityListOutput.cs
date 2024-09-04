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
public class GetActivityListOutput
{
    /// <summary>  
    /// 活动名称，用于标识和描述活动的名称  
    /// </summary>  
    public string? ActivityName { get; set; }

    /// <summary>  
    /// 活动分类，用于将活动归类到不同的类别中  
    /// </summary>  
    public string? ActivityCategory { get; set; }

    /// <summary>  
    /// 活动币种，活动涉及的货币类型  
    /// </summary>  
    public string? CurrencyTypeName { get; set; }

    /// <summary>  
    /// 活动类型，如促销、抽奖、积分兑换等  
    /// </summary>  
    public string? ActivityType { get; set; }

    /// <summary>  
    /// 活动条件，参与活动需要满足的条件  
    /// </summary>  
    public string? ActivityConditions { get; set; }

    /// <summary>  
    /// 参与会员，可以参与此活动的会员列表或条件  
    /// </summary>  
    // 注意：这里假设是一个简单的字符串描述，实际中可能是会员ID列表或更复杂的逻辑  
    public string? ParticipatingMembers { get; set; }

    /// <summary>  
    /// 稽核倍数，用于计算活动奖励或优惠的倍数  
    /// </summary>  
    public decimal AuditMultiplier { get; set; }

    /// <summary>  
    /// 活动申领终端，可以申领此活动的终端或渠道  
    /// </summary>  
    public string? ClaimTerminals { get; set; }

    /// <summary>  
    /// 活动开始时间  
    /// </summary>  
    public DateTime? StartTime { get; set; }

    /// <summary>  
    /// 活动结束时间  
    /// </summary>  
    public DateTime? EndTime { get; set; }


    /// <summary>  
    /// 活动状态，如进行中、已结束、未开始等  
    /// </summary>  
    public string? ActivityStatus { get; set; }

}