// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using NewLife.Reflection;
using Ooph.IMergePart3Game;
using Ooph.MergePart3Game.Models;
using Ooph.MergePart3Game.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game.GameJiLi;

public class GameJiLiService : IPart3GameSub, ITransient
{
    private readonly IHttpJiLiApi _httpJiLiApi;

    public GameJiLiService(IHttpJiLiApi httpJiLiApi)
    {
        this._httpJiLiApi = httpJiLiApi;
    }

    private GameResponse<TRes> handlerResponse<TRes>(Ooph.MergePart3Game.GameJiLi.Models.GameJiliResponseBase response) where TRes : class
    {
        GameResponse<TRes> res = new();
        if (response.ErrorCode != 0)
        {
            res.Code = 500;
            res.Message = $"{response.Message}[{response.ErrorCode}]";
        }
        return res;
    }

    public async Task<GameResponse<CreatePlayerOutput>> CreatePlayerAsync(CreatePlayerInput input)
    {
        var httpResponseResult = await _httpJiLiApi.CreateMemberAsync(new Models.CreateMemberInput { Account = input.Account });
        var res = this.handlerResponse<CreatePlayerOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }

        var resData = httpResponseResult?.Data;
        res.Result = new CreatePlayerOutput
        {
            Account = input.Account,
            Nickname = input.NickName,
            Password = input.Password,
        };

        return res;
    }

    public async Task<GameResponse<GetGameUrlOutput>> GetGameUrlAsync(GetGameUrlInput input)
    {
        var httpResponseResult = await _httpJiLiApi.LoginWithoutRedirectAsync(new Models.LoginWithoutRedirectInput { Account = input.Account, GameId = Convert.ToInt32(input.GameCode), Lang = input.Lang, Platform = input.GamePlatForm });
        var res = this.handlerResponse<GetGameUrlOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }

        var resData = httpResponseResult?.Data;
        res.Result = new GetGameUrlOutput
        {
            GameUrl = resData
        };

        return res;
    }

    public async Task<GameResponse<List<GetGameListOutput>>> GetGameListAsync(GetGameListInput input)
    {
        var httpResponseResult = await _httpJiLiApi.GetGameListAsync(new Models.GetGameListInput { });
        var res = this.handlerResponse<List<GetGameListOutput>>(httpResponseResult);
        if (res.Code != 200) { return res; }

        res.Result = new();
        var httpResData = httpResponseResult?.Data;
        if (httpResData != null)
        {
            foreach (var item in httpResData)
            {
                GameTypeEnum gameType = JiliGameTypeChange(item?.GameCategoryId);
                var gameName=new Dictionary<string, string>();
                if (item?.Name!=null)
                {
                    foreach (var key in item.Name)
                    {
                        var lang = key.Key.ToString();
                        var newlang = HandleLang.HandleLangAsync(lang);
                        gameName.Add(newlang, key.Value);
                    }
                }
                var resData = new GetGameListOutput
                {
                    GameCode = item?.GameId.ToString(),
                    GameName = gameName,
                    GameType = gameType,
                };
                res.Result?.Add(resData);
            }
        }

        return res;
    }

    public async Task<GameResponse<SaveDepositOutput>> SaveDepositAsync(SaveDepositInput input)
    {
        var httpResponseResult = await _httpJiLiApi.ExchangeTransferByAgentIdAsync(new Models.ExchangeTransferByAgentIdInput { Account = input.Account, Amount = input.Amount, TransactionId = input.TransactionId, TransferType = 3 });
        var res = this.handlerResponse<SaveDepositOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }

        var resData = httpResponseResult?.Data;
        res.Result = new SaveDepositOutput
        {
            TransactionId = resData?.TransactionId,
            Amount = input.Amount,
            Balance = Convert.ToDecimal(resData?.CurrencyAfter),
        };

        return res;
    }

    public async Task<GameResponse<WithdrawalOutput>> WithdrawalAsync(WithdrawalInput input)
    {
        var httpResponseResult = await _httpJiLiApi.ExchangeTransferByAgentIdAsync(new Models.ExchangeTransferByAgentIdInput { Account = input.Account, Amount = input.Amount, TransactionId = input.TransactionId, TransferType = 3 });
        var res = this.handlerResponse<WithdrawalOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }

        var resData = httpResponseResult?.Data;
        res.Result = new WithdrawalOutput
        {
            TransactionId = resData?.TransactionId,
            Amount = input.Amount,
            Balance = Convert.ToDecimal(resData?.CurrencyAfter),
        };

        return res;
    }

    public async Task<GameResponse<GetPayTransactionRecordOutput>> GetPayTransactionRecordAsync(GetPayTransactionRecordInput input)
    {
        var httpResponseResult = await _httpJiLiApi.CheckTransferByTransactionIdAsync(new Models.CheckTransferByTransactionIdInput { TransactionId = input.TransactionId });
        var res = this.handlerResponse<GetPayTransactionRecordOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }

        var resData = httpResponseResult?.Data;
        var status = handleStatus(resData?.Status);
        res.Result = new GetPayTransactionRecordOutput
        {
            Account = resData?.Account,
            TransactionId = resData?.TransactionId,
            Currency = null,
            Amount = resData?.Amount,
            Balance = null,
            Status = status,
            TransactionType = resData?.TransferType == 1 ? TransactionTypeEnum.Cashout : TransactionTypeEnum.Cashin,
        };

        return res;
    }

    private string handleStatus(int? status)
    {
        var handleStatus = "";
        switch (status)
        {
            case 1:
                handleStatus = "success"; break;
            case 2:
                handleStatus = "failed"; break;
            default:
                break;
        }
        return handleStatus;
    }

    public async Task<GameResponse<List<GetPayTransactionListOutput>>> GetPayTransactionListAsync(GetPayTransactionListInput input)
    {
        var httpResponseResult = await _httpJiLiApi.GetTransferRecordByTimeAsync(new Models.GetTransferRecordByTimeInput { Account = input.Account, StartTime = input.StartTime, EndTime = input.EndTime, Page = input.Page, PageLimit = input.PageSize });
        var res = this.handlerResponse<List<GetPayTransactionListOutput>>(httpResponseResult);
        if (res.Code != 200) { return res; }

        var httpResData = httpResponseResult?.Data?.TransferRecordByTimeDataResult;

        res.Result = new List<GetPayTransactionListOutput>();
        if (httpResData != null)
        {
            foreach (var item in httpResData)
            {
                var status = handleStatus(item?.Status);
                var resData = new GetPayTransactionListOutput
                {
                    Account = item?.Account,
                    TransactionId = item?.TransactionId,
                    Currency = null,
                    Amount = item?.Amount,
                    Balance = null,
                    Status = status,
                    TransactionType = item?.TransferType == 1 ? TransactionTypeEnum.Cashout : TransactionTypeEnum.Cashin,
                };
                res.Result.Add(resData);
            };
        }

        return res;
    }

    public async Task<GameResponse<LogOutOutput>> LogOutAsync(LogOutInput input)
    {
        var httpResponseResult = await _httpJiLiApi.KickMemberAsync(new Models.KickMemberInput { Account = input.Account });
        var res = this.handlerResponse<LogOutOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }
        res.Result = new LogOutOutput
        {
            IsSuccess = true,
        };

        return res;
    }

    public async Task<GameResponse<LogOutAllOutput>> LogOutAllAsync(LogOutAllInput input)
    {
        var httpResponseResult = await _httpJiLiApi.KickMemberAllAsync(new Models.KickMemberAllInput { GameId = input.GameCode });
        var res = this.handlerResponse<LogOutAllOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }
        res.Result = new LogOutAllOutput
        {
            IsSuccess = true,
        };

        return res;
    }

    public async Task<GameResponse<List<GetGameRecordListOutput>>> GetGameRecordListAsync(GetGameRecordListInput input)
    {
        var httpResponseResult = await _httpJiLiApi.GetBetRecordByTimeAsync(new Models.GetBetRecordByTimeInput { });
        var res = this.handlerResponse<List<GetGameRecordListOutput>>(httpResponseResult);
        if (res.Code != 200) { return res; }

        var HttpResData = httpResponseResult?.Data?.GetBetRecordByTimeDataItem;
        if (HttpResData != null)
        {
            foreach (var item in HttpResData)
            {
                GameTypeEnum gameType = JiliGameTypeChange(item?.GameCategoryId);
                var resData = new GetGameRecordListOutput
                {
                    GameCode = item?.GameId.ToString(),
                    Account = item?.Account,
                    BetAmount = Convert.ToDecimal(item?.BetAmount),
                    ValidBetAmount = Convert.ToDecimal(item?.Turnover),
                    BetSlipsCode = Convert.ToInt64(item?.WagersId),
                    BetTime = item?.WagersTime,
                    BetType = item?.Type,
                    GamePlatForm = null,
                    GameType = gameType,
                    Status = item?.Status,
                    WinsAmount = null,
                    IncomeAmount = null,
                    //PayoffAmount = item?.PayoffAmount,
                    //PayoffTime = item?.PayoffTime,
                };
                res.Result?.Add(resData);
            }
        }
        return res;
    }

    private GameTypeEnum JiliGameTypeChange(int? GameTypes)
    {
        GameTypeEnum gameType = new();
        switch (GameTypes)
        {
            case 1:
                gameType = GameTypeEnum.Electron;
                break;
            case 2:
                gameType = GameTypeEnum.ChessCards;
                break;
            case 3:
                gameType = GameTypeEnum.Others;
                break;
            case 5:
                gameType = GameTypeEnum.CatchFish;
                break;
            case 8:
                gameType = GameTypeEnum.Others;
                break;
            default:
                break;
        }
        return gameType;
    }

    public async Task<GameResponse<List<GetGamePlayerRecordOutput>>> GetGamePlayerRecordAsync(GetGamePlayerRecordInput input)
    {
        var httpResponseResult = await _httpJiLiApi.GetUserBetRecordByTimeAsync(new Models.GetUserBetRecordByTimeInput { Account = input.Account, EndTime = input.EndTime, StartTime = input.StartTime, GameId = Convert.ToInt32(input.GameCode), Page = input.Page, PageLimit = input.PageSize });
        var res = this.handlerResponse<List<GetGamePlayerRecordOutput>>(httpResponseResult);
        if (res.Code != 200) { return res; }

        var HttpResData = httpResponseResult?.Data?.GetUserBetRecordByTimeDataItems;
        if (HttpResData != null)
        {
            foreach (var item in HttpResData)
            {
                GameTypeEnum gameType = JiliGameTypeChange(item?.GameCategoryId);
                var resData = new GetGamePlayerRecordOutput
                {
                    GameCode = item?.GameId.ToString(),
                    Account = item?.Account,
                    BetAmount = Convert.ToDecimal(item?.BetAmount),
                    ValidBetAmount = Convert.ToDecimal(item?.Turnover),
                    BetSlipsCode = Convert.ToInt64(item?.WagersId),
                    BetTime = item?.WagersTime,
                    BetType = item?.Type,
                    GamePlatForm = null,
                    GameType = gameType,
                    Status = item?.Status,
                     IncomeAmount=null,
                      WinsAmount=null,
                    //PayoffAmount = item?.PayoffAmount,
                    //PayoffTime = item?.PayoffTime,
                };
                res.Result?.Add(resData);
            }
        }
        return res;
    }

    public Task<GameResponse<GetGameRecordBetSlipsCodeOutput>> GetGameRecordBetSlipsCodeAsync(GetGameRecordBetSlipsCodeInput input)
    {
        //无实现
        throw new NotImplementedException();
    }
}
