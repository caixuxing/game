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

namespace Ooph.MergePart3Game.GameJiLi.Models;
public class GetFreeSpinRecordByReferenceIDOutput : ResponseBase<List<GetFreeSpinRecordByReferenceIDData?>?> { }

public class GetFreeSpinRecordByReferenceIDData
{

    /// <summary>  
    /// 会员唯一识别值  
    /// </summary>  
    public string? Account { get; set; }

    /// <summary>  
    /// 游戏的唯一识别值  
    /// </summary>  
    public int? GameId { get; set; }

    /// <summary>  
    /// 在游戏内注单唯一值  
    /// </summary>  
    public long? WagersId { get; set; }

    /// <summary>  
    /// 投注金额，精度为16位，小数部分为4位  
    /// </summary>  
    public decimal? BetAmount { get; set; }

    /// <summary>  
    /// 派彩金额，精度为16位，小数部分为4位  
    /// </summary>  
    public decimal? PayoffAmount { get; set; }

    /// <summary>  
    /// 投注时间，通常使用Unix时间戳表示（如果bigint是时间戳的话），否则可能是某种内部编号  
    /// 注意：如果WagersTime确实是时间戳，您可能需要将其转换为DateTime类型以便更方便地处理时间  
    /// </summary>  
    public long? WagersTime { get; set; }

    /// <summary>  
    /// 免费游戏序号  
    /// </summary>  
    public string? ReferenceId { get; set; }
}
