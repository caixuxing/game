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

namespace Ooph.MergePart3Game.GameCQ9.Models;
public class OrderSummaryOutput : ResponseBase<OrderSummaryData?> { }

public class OrderSummaryData
{
    /// <summary>  
    /// 交易分组汇总列表。  
    /// </summary>  
    public List<SummaryReportItem?>? SummaryReport { get; set; }

    /// <summary>  
    /// 总押注量。  
    /// </summary>  
    public int? TotalBets { get; set; }

    /// <summary>  
    /// 总有效押注量
    ///此栏位值用于牌桌/真人/体彩类游戏
    /// </summary>  
    public int? TotalValidBets { get; set; }

    /// <summary>  
    /// 总赢分量(已包含总彩池奖金及总共从PC赢得的金额)
    /// </summary>  
    public int? TotalWins { get; set; }

    /// <summary>  
    /// 总彩池奖金  
    /// </summary>  
    public decimal? TotalJackpots { get; set; }

    /// <summary>  
    /// 总抽水金额
    ///※此栏位为牌桌游戏使用
    /// </summary>  
    public decimal? TotalRake { get; set; }

    /// <summary>  
    /// 总开房费用。  
    /// </summary>  
    public decimal? TotalRoomFee { get; set; }

    /// <summary>  
    /// 总损益。  
    /// </summary>  
    public decimal? TotalIncome { get; set; }
}


/// <summary>  
/// 表示交易分组汇总列表中的单个项。  
/// </summary>  
public class SummaryReportItem
{
    /// <summary>  
    /// 分组信息。  
    /// </summary>  
    public GroupByInfo? GroupBy { get; set; }

    /// <summary>  
    /// 该游戏的押注量。  
    /// </summary>  
    public int? Bets { get; set; }

    /// <summary>  
    /// 有效押注量
    ///※此栏位值用于牌桌/真人/体彩类游戏。  
    /// </summary>  
    public int? ValidBet { get; set; }

    /// <summary>  
    /// 该游戏的赢分量(已包含彩池奖金及从PC赢得的金额)。  
    /// </summary>  
    public int? Wins { get; set; }

    /// <summary>  
    /// 该游戏的彩池奖金。  
    /// </summary>  
    public decimal? Jackpots { get; set; }

    /// <summary>  
    /// 该游戏的抽水金额
    ///※此栏位为牌桌游戏使用。  
    /// </summary>  
    public decimal? Rake { get; set; }

    /// <summary>  
    /// 开房费用。  
    /// </summary>  
    public decimal? RoomFee { get; set; }

    /// <summary>  
    /// 该游戏的损益。  
    /// </summary>  
    public decimal? Income { get; set; }
}

/// <summary>  
/// 表示分组信息的实体类。  
/// </summary>  
public class GroupByInfo
{
    /// <summary>  
    /// 帐号。  
    /// </summary>  
    public string? Account { get; set; }

    /// <summary>  
    /// 游戏代码。  
    /// </summary>  
    public string? GameCode { get; set; }

    /// <summary>  
    /// 游戏厂商。  
    /// </summary>  
    public string? GameHall { get; set; }
}
