// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Furion.RemoteRequest;
using Ooph.MergePart3Game.GameCQ9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game.GameCQ9;

[Client("game-cq9"), RetryPolicy(0)]
public interface IHttpCQ9Api : IHttpCQ9HDP
{
    /// <summary>
    /// 取得时戳
    /// </summary>
    [Get("/gameboy/ping")]
    Task<PingOutput> PingAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PingInput input);

    /// <summary>
    /// 建立Player
    /// </summary>
    [Post("/gameboy/player")]
    Task<PlayerOutput> PlayerAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerInput input);

    /// <summary>
    /// Player登入
    /// </summary>
    [Post("/gameboy/player/login")]
    Task<PlayerLoginOutput> PlayerLoginAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerLoginInput input);

    /// <summary>
    /// Player 取得游戏大厅连结
    /// </summary>
    [Post("/gameboy/player/lobbylink")]
    Task<PlayerLobbylinkOutput> PlayerLobbylinkAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerLobbylinkInput input);


    /// <summary>
    /// Player 取得游戏连结
    /// </summary>
    [Post("/gameboy/player/gamelink")]
    Task<PlayerGamelinkOutput> PlayerGamelinkAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerGamelinkInput input);

    /// <summary>
    /// 取款
    /// </summary>
    [Post("/gameboy/player/withdraw")]
    Task<PlayerWithDrawOutput> PlayerWithdrawAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerWithDrawInput input);

    /// <summary>
    /// 存款
    /// </summary>
    [Post("/gameboy/player/deposit")]
    Task<PlayerDepositOutput> PlayerDepositAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerDepositInput input);

    /// <summary>
    /// 查询余额
    /// </summary>
    [Get("/gameboy/player/balance")]
    Task<PlayerBalanceOutput> PlayerBalanceAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerBalanceInput input);

    /// <summary>
    /// 玩家更换密码
    /// </summary>
    [Post("/gameboy/player/pwd")]
    Task<PlayerPwdOutput> PlayerPwdAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerPwdInput input);

    /// <summary>
    /// 游戏厂商列表
    /// </summary>
    [Get("/gameboy/game/halls")]
    Task<GameHallsOutput> GameHallsAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GameHallsInput input);

    /// <summary>
    /// 游戏列表
    /// </summary>
    [Get("/gameboy/game/list")]
    Task<GameListOutput> GameListAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GameListlInput input);

    /// <summary>
    /// 注单查询
    /// </summary>
    [Get("/gameboy/order/view")]
    Task<OrderViewOutput> OrderViewAsync([Body("application/x-www-form-urlencoded", "UTF-8")] OrderViewInput input);

    /// <summary>
    /// 单一注单查询
    /// </summary>
    [Get("/gameboy/order/record")]
    Task<OrderRecordOutput> OrderRecordAsync([Body("application/x-www-form-urlencoded", "UTF-8")] OrderRecordInput input);

    /// <summary>
    /// 交易查询
    /// </summary>
    [Get("/gameboy/transaction/view")]
    Task<TransactionViewOutput> TransactionViewAsync([Body("application/x-www-form-urlencoded", "UTF-8")] TransactionViewInput input);

    /// <summary>
    /// 单一交易查询
    /// </summary>
    [Get("/gameboy/transaction/record")]
    Task<TransactionRecordOutput> TransactionRecordAsync([Body("application/x-www-form-urlencoded", "UTF-8")] TransactionRecordInput input);

    /// <summary>
    /// 钱包历程
    /// </summary>
    [Get("/gameboy/transaction/history")]
    Task<TransactionHistoryOutput> TransactionHistoryAsync([Body("application/x-www-form-urlencoded", "UTF-8")] TransactionHistoryInput input);

    /// <summary>
    /// 单一玩家注单小计
    /// </summary>
    [Get("/gameboy/order/summary")]
    Task<OrderSummaryOutput> OrderSummaryAsync([Body("application/x-www-form-urlencoded", "UTF-8")] OrderSummaryInput input);

    /// <summary>
    /// 玩家登出
    /// </summary>
    [Post("/gameboy/player/logout")]
    Task<PlayerLogoutOutput> PlayerLogoutAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerLogoutInput input);

    /// <summary>
    /// 登出代理所有玩家
    /// </summary>
    [Post("/gameboy/to/logout/all")]
    Task<LogoutAllOutput> LogoutAllAsync([Body("application/x-www-form-urlencoded", "UTF-8")] LogoutAllInput input);

    /// <summary>
    /// 查询玩家token
    /// </summary>
    [Get("/gameboy/player/token/{input.Account}")]
    Task<PlayerTokenOutput> PlayerTokenAsync(PlayerTokenInput input);

    /// <summary>
    /// 查询玩家帐号是否存在
    /// </summary>
    [Get("/gameboy/player/check/{input.Account}")]
    Task<PlayerCheckOutput> PlayerCheckAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerCheckInput input);

    /// <summary>
    /// 游戏彩池金额查询
    /// </summary>
    [Get("/gameboy/game/jackpot")]
    Task<GameJackpotOutput> GameJackpotAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GameJackpotInput input);

    /// <summary>
    /// 取得会员系统连结
    /// </summary>
    [Post("/gameboy/player/mslink")]
    Task<PlayerMslinkOutput> PlayerMslinkAsync([Body("application/x-www-form-urlencoded", "UTF-8")] PlayerMslinkInput input);
}