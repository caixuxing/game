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
public class OrderViewOutput : ResponseBase<OrderViewData?> { }

public class OrderViewData
{
    /// <summary>
    /// 总笔数
    /// </summary>
    public int? TotalSize { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<GameRecord?>? Data { get; set; }
}

public class GameRecord
{
    /// <summary>
    /// 游戏商
    /// </summary>
    public string? GameHall { get; set; }

    /// <summary>
    /// 游戏种类
    /// </summary>
    public string? GameType { get; set; }

    /// <summary>
    /// 游戏平台
    /// </summary>
    public string? GamePlat { get; set; }

    /// <summary>
    /// 游戏代码
    /// </summary>
    public string? GameCode { get; set; }

    /// <summary>
    /// 玩家帐号
    /// </summary>
    public string? Account { get; set; }

    /// <summary>
    /// 注单号
    ///※round为唯一值
    /// </summary>
    public string? Round { get; set; }

    /// <summary>
    /// 游戏后余额
    /// </summary>
    public decimal? Balance { get; set; }

    /// <summary>
    /// 游戏赢分（已包含彩池奖金及从PC赢得的金额）
    /// </summary>
    public decimal? Win { get; set; }

    /// <summary>
    /// 下注金额
    /// </summary>
    public decimal? Bet { get; set; }

    /// <summary>
    /// 有效下注额
    ///※此栏位值用于牌桌/真人/体彩类游戏
    /// </summary>
    public decimal? ValidBet { get; set; }

    /// <summary>
    /// 彩池奖金
    /// </summary>
    public decimal? Jackpot { get; set; }

    /// <summary>
    /// 彩池奖金贡献值
    ///※从小彩池到大彩池依序排序
    ///(Mini / Minor / Major / Grand )
    /// </summary>
    public List<decimal?>? JackpotContribution { get; set; }

    /// <summary>
    /// 彩池奖金类别
    ///※此栏位值为空字串时，表示未获得彩池奖金
    /// </summary>
    public string? JackpotType { get; set; }

    /// <summary>
    /// 注单状态[complete]
    ///complete:完成
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// 游戏结束时间，格式为RFC3339
    /// </summary>
    public DateTime? EndRoundTime { get; set; }

    /// <summary>
    /// 当笔资料建立时间，格式为※系统结算时间, 注单结算时间及报表结算时间都是createtimeRFC3339
    /// </summary>
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 下注时间，格式为RFC3339
    /// </summary>
    public DateTime? BetTime { get; set; }

    /// <summary>
    /// 回传free game / bonus game / luckydraw / item / reward 资讯
    ///※slot 会回传free game / bonus game / luckydraw 资讯
    ///※fish 会回传item / reward 资讯
    ///※table/live 会回传空阵列
    /// </summary>
    public List<GameDetail?>? Detail { get; set; }

    /// <summary>
    /// [true|false]是否为再旋转形成的注单
    /// </summary>
    public bool? SingleRowBet { get; set; }

    /// <summary>
    /// 庄(banker) or 闲(player)
    ///※此栏位为牌桌游戏使用，非牌桌游戏此栏位值为空字串
    /// </summary>
    public string? GameRole { get; set; }

    /// <summary>
    /// 对战玩家是否有真人[pc|human]
    ///    pc：对战玩家没有真人
    ///    human：对战玩家有真人
    ///※此栏位为牌桌游戏使用，非牌桌游戏此栏位值为空字串
    ///※如果玩家不支持上庄，只存在与系统对玩。则bankertype 为PC
    /// </summary>
    public string? BankerType { get; set; }

    /// <summary>
    ///抽水金额
    ///※此栏位为牌桌游戏使用
    /// </summary>
    public decimal? Rake { get; set; }

    /// <summary>
    /// 开房费用
    /// </summary>
    public decimal? RoomFee { get; set; }

    /// <summary>
    /// 真人注单参数说明名称(1=百家，4=龙虎)
    ///真人参数说明※此栏位为真人游戏使用，非真人游戏此栏位值为空字串
    /// </summary>
    public string? TableType { get; set; }

    /// <summary>
    /// 桌号真人参数说明※此栏位为真人游戏使用，非真人游戏此栏位值为空字串
    /// </summary>
    public string? TableId { get; set; }

    /// <summary>
    /// 局号
    ///真人参数说明※此栏位为真人游戏使用，非真人游戏此栏位值为空字串
    /// </summary>
    public string? RoundNumber { get; set; }

    /// <summary>
    /// 下注玩法真人参数说明※此栏位为真人游戏使用，非真人游戏此栏位值为空阵列
    /// </summary>
    public List<int?>? BetType { get; set; }

    /// <summary>
    /// 游戏结果真人参数说明※此栏位为真人游戏使用，非真人游戏此栏位值为空阵列
    /// </summary>
    public GameResult? GameResult { get; set; }

    /// <summary>
    /// 免费券id
    /// </summary>
    public string? TicketId { get; set; }

    /// <summary>
    /// 免费券类型
    ///1 = 免费游戏(获得一局free game)
    ///2 = 免费spin(获得一次free spin)
    /// </summary>
    public string? TicketType { get; set; }

    /// <summary>
    ///  /// 免费券取得类型
    ///1 = 活动赠送
    ///101 = 代理赠送
    ///111 = 宝箱赠送
    ///112 = 商城购买
    /// </summary>
    public string? GivenType { get; set; }

    /// <summary>
    /// 免费券下注额
    /// </summary>

    public decimal? TicketBets { get; set; }

    /// <summary>
    /// 币别
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// 派彩加成金额
    /// </summary>
    public decimal? CardWin { get; set; }

    /// <summary>
    /// 打赏金额
    ///※此栏位为真人游戏使用，非真人游戏此栏位值为0
    /// </summary>
    public decimal? Donate { get; set; }

    /// <summary>
    /// 打赏判别
    ///※此栏位为真人游戏使用，非真人游戏此栏位值为false
    /// </summary>
    public bool? IsDonate { get; set; }
}

public class GameDetail
{
    /// <summary>
    /// 
    /// </summary>
    public int? FreeGame { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? LuckyDraw { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? Bonus { get; set; }
}

public class GameResult
{
    /// <summary>
    /// 
    /// </summary>
    public List<int?>? Points { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<Card?>? Cards { get; set; }
}

public class Card
{
    /// <summary>
    /// 
    /// </summary>
    public string? Poker { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? Tag { get; set; }
}
