using Ooph.MergePart3Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.IMergePart3Game
{
    public interface IPart3GameSub : IPart3Game { }
    public interface IPart3GameAggre : IPart3Game { }

    public interface IPart3Game
    {
        /// <summary>
        /// 添加玩家
        /// </summary>
        Task<GameResponse<CreatePlayerOutput>> CreatePlayerAsync(CreatePlayerInput input);

        /// <summary>
        /// 获取游戏地址URL
        /// </summary>
        Task<GameResponse<GetGameUrlOutput>> GetGameUrlAsync(GetGameUrlInput input);

        /// <summary>
        /// 获取游戏列表
        /// </summary>
        Task<GameResponse<List<GetGameListOutput>>> GetGameListAsync(GetGameListInput input);


        /// <summary>
        /// 存进
        /// </summary>
        Task<GameResponse<SaveDepositOutput>> SaveDepositAsync(SaveDepositInput input);

        /// <summary>
        /// 取出
        /// </summary>
        Task<GameResponse<WithdrawalOutput>> WithdrawalAsync(WithdrawalInput input);

        /// <summary>
        /// 单一交易查询
        /// </summary>
        Task<GameResponse<GetPayTransactionRecordOutput>> GetPayTransactionRecordAsync(GetPayTransactionRecordInput input);

        /// <summary>
        /// 交易查询（按时间）
        /// </summary>
        Task<GameResponse<List<GetPayTransactionListOutput>>> GetPayTransactionListAsync(GetPayTransactionListInput input);

        /// <summary>
        /// 退出游戏
        /// </summary>
        Task<GameResponse<LogOutOutput>> LogOutAsync(LogOutInput input);

        /// <summary>
        /// 所有账号退出游戏
        /// </summary>
        Task<GameResponse<LogOutAllOutput>> LogOutAllAsync(LogOutAllInput input);

        /// <summary>
        /// 查询游戏记录
        /// </summary>
        /// 
        Task<GameResponse<List<GetGameRecordListOutput>>> GetGameRecordListAsync(GetGameRecordListInput input);

        /// <summary>
        /// 查询单一账号玩家游戏记录
        /// </summary>
        Task<GameResponse<List<GetGamePlayerRecordOutput>>> GetGamePlayerRecordAsync(GetGamePlayerRecordInput input);

        /// <summary>
        /// 由注单号查询单一游戏记录
        /// </summary>
        Task<GameResponse<GetGameRecordBetSlipsCodeOutput>> GetGameRecordBetSlipsCodeAsync(GetGameRecordBetSlipsCodeInput input);
    }
}
