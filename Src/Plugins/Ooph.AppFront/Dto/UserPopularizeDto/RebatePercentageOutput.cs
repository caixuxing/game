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

namespace Ooph.AppFront.Dto.UserPopularizeDto;
public class RebatePercentageOutput
{
    /// <summary>
    /// 游戏分类id
    /// </summary>
    public string? GameCategoryId { get; set; }

    /// <summary>
    /// 游戏分类名称
    /// </summary>
    public string? GameCategory { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<RebatePercentageItem?>? RebatePercentageItems { get; set; }
}


public class RebatePercentageItem
{
    /// <summary>
    /// 有效人数
    /// </summary>
    public int? EffectivePeople { get; set; }
    
    /// <summary>
    /// 业绩 （W）
    /// </summary>
    public decimal? AchievementAmount { get; set; }
    
    /// <summary>
    /// 每万返佣金额
    /// </summary>
    public decimal? RebatesAmount { get; set; }
}
