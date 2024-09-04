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
public class PlayRecordOutput
{
    /// <summary>  
    /// 注单编号，唯一标识一个注单  
    /// </summary>  
    public string? BetOrderId { get; set; }

    /// <summary>  
    /// 牌局编号，与注单关联的牌局  
    /// </summary>  
    public string? GameSessionId { get; set; }

    /// <summary>  
    /// 会员ID，用户的唯一标识  
    /// </summary>  
    public long? MemberId { get; set; }

    /// <summary>  
    /// 会员账号，用户登录时使用的账号  
    /// </summary>  
    public string? MemberAccount { get; set; }

    /// <summary>  
    /// 游戏类型，如电子、体育等  
    /// </summary>  
    public string? GameCategory { get; set; }

    /// <summary>  
    /// 游戏平台
    /// </summary>  
    public string? PlatformCode { get; set; }

    /// <summary>  
    /// 子游戏id  
    /// </summary>  
    public string? GameCode { get; set; }

    /// <summary>  
    /// 子游戏名称  
    /// </summary>  
    public string? GameName { get; set; }

    /// <summary>  
    /// 投注时间，注单下注的时间  
    /// </summary>  
    public DateTime? BetTime { get; set; }

    /// <summary>  
    /// 结算时间，注单结算的时间（如果已结算）  
    /// </summary>  
    public DateTime? SettlementTime { get; set; }

    /// <summary>  
    /// 币种，注单使用的货币类型  
    /// </summary>  
    public string? CurrencyTypeName { get; set; }

    /// <summary>  
    /// 投注金额，用户下注的金额  
    /// </summary>  
    public decimal? BetAmount { get; set; }

    /// <summary>  
    /// 有效投注，经过某些规则调整后的实际投注金额（如可能有优惠、折扣等）  
    /// </summary>  
    public decimal? EffectiveBetAmount { get; set; }

    /// <summary>  
    /// 会员输赢，注单结算后会员的盈亏情况（正数为赢，负数为输）  
    /// </summary>  
    public decimal? MemberWinLoss { get; set; }

    /// <summary>  
    /// 投注后余额，注单下注后会员的账户余额  
    /// </summary>  
    public decimal? BalanceAfterBet { get; set; }

    /// <summary>  
    /// 状态，注单的状态（如已结算、未结算、已撤单等）  
    /// </summary>  
    public string? Status { get; set; }


}
