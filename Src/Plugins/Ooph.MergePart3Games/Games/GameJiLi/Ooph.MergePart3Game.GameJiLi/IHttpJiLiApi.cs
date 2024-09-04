// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Furion.RemoteRequest;
using Ooph.MergePart3Game.GameJiLi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game.GameJiLi;

[Client("game-jili"), RetryPolicy(0)]
public interface IHttpJiLiApi : IHttpJiLiHDP
{
    /// <summary>
    /// 登入返還位置
    /// </summary>
    [Post("/LoginWithoutRedirect")]
    Task<LoginWithoutRedirectOutput> LoginWithoutRedirectAsync([Body("application/x-www-form-urlencoded", "UTF-8")] LoginWithoutRedirectInput input);

    /// <summary>
    /// 建立账号
    /// </summary>
    [Post("/CreateMember")]
    Task<CreateMemberOutput> CreateMemberAsync([Body("application/x-www-form-urlencoded", "UTF-8")] CreateMemberInput input);

    /// <summary>
    /// 注销游戏
    /// </summary>
    [Post("/KickMember")]
    Task<KickMemberOutput> KickMemberAsync([Body("application/x-www-form-urlencoded", "UTF-8")] KickMemberInput input);

    /// <summary>
    /// 注销游戏(全踢或依游戏)
    /// </summary>
    [Post("/KickMemberAll")]
    Task<KickMemberAllOutput> KickMemberAllAsync([Body("application/x-www-form-urlencoded", "UTF-8")] KickMemberAllInput input);

    /// <summary>
    /// 查询会员状态
    /// </summary>
    [Post("/GetMemberInfo")]
    Task<GetMemberInfoOutput> GetMemberInfoAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetMemberInfoInput input);

    /// <summary>
    /// 查询所有在线玩家账号
    /// </summary>
    [Post("/GetOnlineMember")]
    Task<GetOnlineMemberOutput> GetOnlineMemberAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetOnlineMemberInput input);

    /// <summary>
    /// 查询一笔额度转移纪录(依 TransactionId)
    /// </summary>
    [Post("/CheckTransferByTransactionId")]
    Task<CheckTransferByTransactionIdOutput> CheckTransferByTransactionIdAsync([Body("application/x-www-form-urlencoded", "UTF-8")] CheckTransferByTransactionIdInput input);

    /// <summary>
    /// 查询额度转移纪录 (依时间范围)
    /// </summary>
    [Post("/GetTransferRecordByTime")]
    Task<GetTransferRecordByTimeOutput> GetTransferRecordByTimeAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetTransferRecordByTimeInput input);

    /// <summary>
    /// 查询游戏纪录 (依时间范围)
    /// </summary>
    [Post("/GetBetRecordByTime")]
    Task<GetBetRecordByTimeOutput> GetBetRecordByTimeAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetBetRecordByTimeInput input);

    /// <summary>
    /// 查询游戏清单
    /// </summary>
    [Post("/GetGameList")]
    Task<GetGameListOutput> GetGameListAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetGameListInput input);

    /// <summary>
    /// 取得注单详细结果连结
    /// </summary>
    [Post("/GetGameDetailUrl")]
    Task<GetGameDetailUrlOutput> GetGameDetailUrlAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetGameDetailUrlInput input);

    /// <summary>
    /// 额度转移(比值绑定 AgentId)
    /// </summary>
    [Post("/ExchangeTransferByAgentId")]
    Task<ExchangeTransferByAgentIdOutput> ExchangeTransferByAgentIdAsync([Body("application/x-www-form-urlencoded", "UTF-8")] ExchangeTransferByAgentIdInput input);

    /// <summary>
    /// 查詢 MustHitBy
    /// </summary>
    [Post("/GetMustHitBy")]
    Task<GetMustHitByOutput> GetMustHitByAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetMustHitByInput input);

    /// <summary>
    /// 查詢單一玩家遊戲紀錄(依時間範圍)
    /// </summary>
    [Post("/GetUserBetRecordByTime")]
    Task<GetUserBetRecordByTimeOutput> GetUserBetRecordByTimeAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetUserBetRecordByTimeInput input);

    /// <summary>
    /// 给予玩家免费游戏局数
    /// </summary>
    [Post("/CreateFreeSpin")]
    Task<CreateFreeSpinOutput> CreateFreeSpinAsync([Body("application/x-www-form-urlencoded", "UTF-8")] CreateFreeSpinInput input);

    /// <summary>
    /// 查询 FreeSpin 总览
    /// </summary>
    [Post("/GetFreeSpinRecordSummary")]
    Task<GetFreeSpinRecordSummaryOutput> GetFreeSpinRecordSummaryAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetFreeSpinRecordSummaryInput input);

    /// <summary>
    /// 查询 FreeSpin 已派送细节
    /// </summary>
    [Post("/GetFreeSpinSendDetail")]
    Task<GetFreeSpinSendDetailOutput> GetFreeSpinSendDetailAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetFreeSpinSendDetailInput input);

    /// <summary>
    /// 查询 FreeSpin 游戏纪录
    /// </summary>
    [Post("/GetFreeSpinRecordByTime")]
    Task<GetFreeSpinRecordByTimeOutput> GetFreeSpinRecordByTimeAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetFreeSpinRecordByTimeInput input);

    /// <summary>
    /// 查询 FreeSpin 已使用纪录
    /// </summary>
    [Post("/GetFreeSpinDashflow")]
    Task<GetFreeSpinDashflowOutput> GetFreeSpinDashflowAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetFreeSpinDashflowInput input);

    /// <summary>
    /// 透过序号查询 FreeSpin 游戏纪录
    /// </summary>
    [Post("/GetFreeSpinRecordByReferenceID")]
    Task<GetFreeSpinRecordByReferenceIDOutput> GetFreeSpinRecordByReferenceIDAsync([Body("application/x-www-form-urlencoded", "UTF-8")] GetFreeSpinRecordByReferenceIDInput input);

    /// <summary>
    /// 取消已赠送的 FreeSpin 次数
    /// </summary>
    [Post("/CancelFreeSpin")]
    Task<CancelFreeSpinOutput> CancelFreeSpinAsync([Body("application/x-www-form-urlencoded", "UTF-8")] CancelFreeSpinInput input);

    /// <summary>
    /// 取消玩家的免费游戏次数
    /// </summary>
    [Post("/CancelFreeSpinByAccount")]
    Task<CancelFreeSpinByAccountOutput> CancelFreeSpinByAccountAsync([Body("application/x-www-form-urlencoded", "UTF-8")] CancelFreeSpinByAccountInput input);

    /// <summary>
    /// 给予多个玩家免费游戏局数
    /// </summary>
    [Post("/CreateFreeSpinForMany")]
    Task<CreateFreeSpinForManyOutput> CreateFreeSpinForManyAsync([Body("application/x-www-form-urlencoded", "UTF-8")] CreateFreeSpinForManyInput input);

}
