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
public class GetMissionListOutput
{
    /// <summary>  
    /// 任务的唯一标识符  
    /// </summary>  
    public int? MissionId { get; set; }

    /// <summary>  
    /// 任务币种  
    /// </summary>  
    public string? CurrencyTypeName { get; set; }

    /// <summary>  
    /// 任务条件  
    /// </summary>  
    public string? MissionCondition { get; set; }

    /// <summary>  
    /// 任务的分类，用于将任务归类到不同的类别中  
    /// </summary>  
    public string? MissionCategory { get; set; }

    /// <summary>  
    /// 完成任务后可以获得的奖励金额  
    /// </summary>  
    public decimal? RewardAmount { get; set; }

    /// <summary>  
    /// 任务的目标描述或要求  
    /// </summary>  
    public string? MissionGoal { get; set; }

    /// <summary>  
    /// 完成任务后可以获得的活跃度奖励  
    /// </summary>  
    public int? RewardActivityPoints { get; set; }

    /// <summary>  
    /// 指示任务是否已开启
    /// </summary>  
    public bool? IsEnabled { get; set; }

    /// <summary>  
    /// 是否开启提示气泡  
    /// </summary>  
    public bool? IsCueBubbles { get; set; }

}
