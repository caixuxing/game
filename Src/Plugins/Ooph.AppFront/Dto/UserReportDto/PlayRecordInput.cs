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

namespace Ooph.AppFront.Dto.UserReportDto;
public class PlayRecordInput : BasePageInput
{
    /// <summary>  
    /// 投注时间
    /// </summary>  
    public DateTime? BetTime { get; set; }

    /// <summary>  
    /// 游戏分类id，支持单一和全部类别  
    /// </summary>  
    public long? GameCategoryId { get; set; }

    /// <summary>  
    /// 平台，支持单一平台或全部平台  
    /// </summary>  
    public string? PlatformCode { get; set; }

    /// <summary>  
    /// 结算状态：全部状态  已结算/未结算/已撤单  
    /// </summary>  
    public string? SettlementStatus { get; set; }

    /// <summary>  
    /// 游戏名称id 支持单一游戏或全部游戏
    /// </summary>  
    public string? GameCode { get; set; }

    /// <summary>  
    /// 子游戏名称  
    /// </summary>  
    public string? GameName { get; set; }

}

