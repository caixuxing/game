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
public class GetBetRecordByTimeOutput : ResponseBase<GetBetRecordByTimeData?> { }
public class GetBetRecordByTimeData : GameJiliResponsePagination
{
    public List<GetBetRecordByTimeDataItem?>? GetBetRecordByTimeDataItem { get; set; }
}

public class GetBetRecordByTimeDataItem
{
    /// <summary>
    /// 会员唯一识别值
    /// </summary>
    public string? Account { get; set; }

    /// <summary>
    /// 在游戏内注单唯一值
    /// </summary>
    public long? WagersId { get; set; }

    /// <summary>
    /// 游戏的唯一识别值
    /// </summary>
    public int? GameId { get; set; }

    /// <summary>
    /// 投注时间
    /// </summary>
    public DateTime? WagersTime { get; set; }

    /// <summary>
    /// 投注金额
    /// </summary>
    public decimal? BetAmount { get; set; }

    /// <summary>
    /// 派彩时间
    /// </summary>
    public DateTime? PayoffTime { get; set; }

    /// <summary>
    /// 派彩金额
    /// </summary>
    public decimal? PayoffAmount { get; set; }

    /// <summary>
    /// 注单状态：
    ///1: 赢 2: 输 3: 平局
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 对帐时间
    /// </summary>
    public DateTime? SettlementTime { get; set; }

    /// <summary>
    /// 游戏类型
    /// </summary>
    public int? GameCategoryId { get; set; }

    /// <summary>
    /// 注单类型
    /// </summary>
    public int? Type { get; set; }

    /// <summary>
    /// 会员所属站长唯一识别值
    /// </summary>
    public string? AgentId { get; set; }

    /// <summary>
    /// 有效投注金额 
    /// </summary>
    public decimal? Turnover { get; set; }

    /// <summary>
    /// 主单号，用于注单类型为 9 的注单 
    /// </summary>
    public long? RoundIndex { get; set; }
}