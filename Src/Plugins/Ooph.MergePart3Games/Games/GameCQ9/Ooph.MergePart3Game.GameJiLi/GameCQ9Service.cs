// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Ooph.IMergePart3Game;
using Ooph.MergePart3Game.Models;
using Ooph.MergePart3Game.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game.GameCQ9;
public class GameCQ9Service : IPart3GameSub, ITransient
{
    private readonly IHttpCQ9Api _httpCQ9Api;

    public GameCQ9Service(IHttpCQ9Api httpCQ9Api)
    {
        this._httpCQ9Api = httpCQ9Api;
    }

    private GameResponse<TRes> handlerResponse<TRes>(Ooph.MergePart3Game.GameCQ9.Models.GameCQ9ResponseBase response) where TRes : class, new()
    {
        GameResponse<TRes> res = new();
        if (response?.Status?.Code != "0")
        {
            res.Code = 500;
            res.Message = $"{response?.Status?.Message}[{response?.Status?.Code}]";
        }
        else
        {
            res.Result = new TRes();
        }
        return res;
    }

    public async Task<GameResponse<CreatePlayerOutput>> CreatePlayerAsync(CreatePlayerInput input)
    {
        var httpResponseResult = await _httpCQ9Api.PlayerAsync(new Models.PlayerInput { Account=input.Account, Nickname=input.NickName, Password=input.Password});
        var res = this.handlerResponse<CreatePlayerOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData=httpResponseResult.Data;
        res.Result = new CreatePlayerOutput
        {
            Account = httpResData?.Account,
            Password = httpResData?.Password,
            Nickname = httpResData?.Nickname,
        };

        return res;
    }

    public Dictionary<string, Dictionary<string, string>> ConstGameNames = new Dictionary<string, Dictionary<string, string>>
    {
        {"Game1",new Dictionary<string, string> {
                { "zh", "Game1" } ,
                { "en", "Game1" } ,
            }
        },
        {"Game2",new Dictionary<string, string> {
                { "zh", "Game1" } ,
                { "en", "Game1" } ,
            }
        }
    };

    public async Task<GameResponse<List<GetGameListOutput>>> GetGameListAsync(GetGameListInput input)
    {
        var httpResponseResult = await _httpCQ9Api.GameListAsync(new Models.GameListlInput { GameHall = "cq9"});
        var res = this.handlerResponse<List<GetGameListOutput>>(httpResponseResult);
        if (res.Code != 200) { return res; }
        
        var httpResData = httpResponseResult?.Data;
        if (httpResData != null)
        {
            foreach (var item in httpResData)
            {
                GameTypeEnum gameType = Cq9GameTypeChange(item?.GameType);
                var gameName = new Dictionary<string, string> { };
                if (item?.Nameset!=null)
                {
                    foreach (var itemLang in item.Nameset)
                    {
                        if (itemLang?.Lang!=null&&itemLang?.Name!=null)
                        {
                            var newlang = HandleLang.HandleLangAsync(itemLang.Lang);
                            gameName.Add(newlang, itemLang.Name);
                        }
                    }
                }
                var resData = new GetGameListOutput
                {
                    GameCode = item?.GameCode,
                    GameName = gameName,
                    GameType = gameType,
                };
                res.Result?.Add(resData);
            }
        }
        return res;
    }

    public async Task<GameResponse<List<GetGamePlayerRecordOutput>>> GetGamePlayerRecordAsync(GetGamePlayerRecordInput input)
    {
        var gameTypeInput = handleCq9GameTypeChange(input.GameType);
        var httpResponseResult = await _httpCQ9Api.OrderSummaryAsync(new Models.OrderSummaryInput
        {
            Account = input.Account,
            StartTime = input.StartTime,
            EndTime = input.EndTime,
            GameType = gameTypeInput,
             
        });
        var res = this.handlerResponse<List<GetGamePlayerRecordOutput>>(httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult?.Data?.SummaryReport;
        if (httpResData!=null)
        {
            foreach (var item in httpResData)
            {
                // GameTypeEnum gameType = Cq9GameTypeChange(item.GameType);
                var resData = new GetGamePlayerRecordOutput
                {
                    GameCode = item?.GroupBy?.GameCode,
                    Account = item?.GroupBy?.Account,
                    BetAmount = Convert.ToDecimal(item?.Bets),
                    BetSlipsCode = null,
                    BetTime = null,
                    BetType = null,
                    GamePlatForm = item?.GroupBy?.GameHall,
                    GameType = null,
                    Status = null,
                    ValidBetAmount = Convert.ToDecimal(item?.ValidBet),
                    //PayoffAmount = null,
                    IncomeAmount = item?.Income,
                    WinsAmount = item?.Wins,
                };
                res.Result?.Add(resData);
            }
        }
        return res;
    }

    public async Task<GameResponse<List<GetGameRecordListOutput>>> GetGameRecordListAsync(GetGameRecordListInput input)
    {
        var gameTypeInput = handleCq9GameTypeChange(input.GameType);
        var httpResponseResult = await _httpCQ9Api.OrderViewAsync(new Models.OrderViewInput {  
            Account=input.Account, StartTime=input.StartTime, EndTime=input.EndTime,  GameType= gameTypeInput, Page=input.Page,PageSize=input.PageSize});
        var res = this.handlerResponse<List<GetGameRecordListOutput>> (httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult?.Data?.Data;
        if (httpResData!=null)
        {
            foreach (var item in httpResData)
            {
                GameTypeEnum gameType = Cq9GameTypeChange(item?.GameType);
                var resData = new GetGameRecordListOutput
                {
                    GameCode = item?.GameCode,
                    Account = item?.Account,
                    BetAmount = Convert.ToDecimal(item?.Bet),
                    BetSlipsCode = Convert.ToInt64(item?.Round),
                    BetTime = item?.BetTime,
                    BetType = null,
                    GamePlatForm = item?.GamePlat,
                    GameType = gameType,
                    Status = null,
                    ValidBetAmount = Convert.ToDecimal(item?.ValidBet),
                    //PayoffAmount = null,
                    IncomeAmount = null,
                    //PayoffTime = null,
                    WinsAmount = Convert.ToDecimal(item?.Win),

                };
                res.Result?.Add(resData);
            }
        }
        

        return res;
    }

    public async Task<GameResponse<GetGameUrlOutput>> GetGameUrlAsync(GetGameUrlInput input)
    {
        var httpUserToken = await _httpCQ9Api.PlayerLoginAsync(new Models.PlayerLoginInput { Account=input.Account, Password=input.Password});
        var httpResponseResult = await _httpCQ9Api.PlayerGamelinkAsync(new Models.PlayerGamelinkInput { UserToken=httpUserToken?.Data?.Usertoken,GameCode=input.GameCode, GameHall="cq9", App="N", Detect="N", Dollarsign="N", GamePlat=input.GamePlatForm, Lang=input.Lang   });
        var res = this.handlerResponse<GetGameUrlOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult.Data;
        res.Result = new GetGameUrlOutput
        {
             GameUrl=httpResData?.Url
        };

        return res;
    }

    public async Task<GameResponse<List<GetPayTransactionListOutput>>> GetPayTransactionListAsync(GetPayTransactionListInput input)
    {
        var httpResponseResult = await _httpCQ9Api.TransactionViewAsync(new Models.TransactionViewInput { Account=input.Account, EndTime=input.EndTime, StartTime=input.StartTime,Page=input.Page,PageSize=input.PageSize});
        var res = this.handlerResponse<List<GetPayTransactionListOutput>>(httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult?.Data?.List;
        if (httpResData!=null)
        {
            foreach (var item in httpResData)
            {
                var resData = new GetPayTransactionListOutput
                {
                    Account = input.Account,
                    TransactionType = item?.Action == "cashin" ? TransactionTypeEnum.Cashin : TransactionTypeEnum.Cashout,
                    Amount = item?.Amount,
                    Balance = item?.Balance,
                    Currency = item?.Currency,
                    Status = item?.Status,
                    TransactionId = item?.Mtcode,
                };
                res.Result?.Add(resData);
            }
        }
        return res;
    }

    public async Task<GameResponse<GetPayTransactionRecordOutput>> GetPayTransactionRecordAsync(GetPayTransactionRecordInput input)
    {
        var httpResponseResult = await _httpCQ9Api.TransactionRecordAsync(new Models.TransactionRecordInput { MtCode=input.TransactionId });
        var res = this.handlerResponse<GetPayTransactionRecordOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult.Data;

        res.Result = new GetPayTransactionRecordOutput
        {
            Account = null,
            TransactionType = httpResData?.Action == "cashin" ? TransactionTypeEnum.Cashin : TransactionTypeEnum.Cashout,
            Amount = httpResData?.Amount,
            Balance = httpResData?.Balance,
            Currency = httpResData?.Currency,
            Status = httpResData?.Status,
            TransactionId = httpResData?.MtCode,
        };
        return res;
           
    }

    public async Task<GameResponse<LogOutAllOutput>> LogOutAllAsync(LogOutAllInput input)
    {
        var httpResponseResult = await _httpCQ9Api.LogoutAllAsync(new Models.LogoutAllInput { Account= input.Account, IsAll=false,  });
        var res = this.handlerResponse<LogOutAllOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult.Data;

        res.Result = new LogOutAllOutput
        {
           IsSuccess = true,
        };
        return res;
    }

    public async Task<GameResponse<LogOutOutput>> LogOutAsync(LogOutInput input)
    {
        var httpResponseResult = await _httpCQ9Api.PlayerLogoutAsync(new Models.PlayerLogoutInput { Account=input.Account});
        var res = this.handlerResponse<LogOutOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult.Data;

        res.Result = new LogOutOutput
        {
            IsSuccess = true,
        };
        return res;
    }

    public async Task<GameResponse<SaveDepositOutput>> SaveDepositAsync(SaveDepositInput input)
    {
        var httpResponseResult = await _httpCQ9Api.PlayerDepositAsync(new Models.PlayerDepositInput { Account=input.Account, Amount=input.Amount, MtCode=input.TransactionId});
        var res = this.handlerResponse<SaveDepositOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult.Data;

        res.Result = new SaveDepositOutput
        {
            Amount = input.Amount,
            Balance = Convert.ToDecimal(httpResData?.Balance),
            TransactionId = input.TransactionId,
            Currency = httpResData?.Currency,
        };
        return res;
    }

    public async Task<GameResponse<WithdrawalOutput>> WithdrawalAsync(WithdrawalInput input)
    {
        var httpResponseResult = await _httpCQ9Api.PlayerWithdrawAsync
            (new Models.PlayerWithDrawInput { Account = input.Account, Amount = input.Amount, MtCode = input.TransactionId });
        var res = this.handlerResponse<WithdrawalOutput>(httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult.Data;

        res.Result = new WithdrawalOutput
        {
            Balance = Convert.ToDecimal(httpResData?.Balance),
            Amount= input.Amount,
            TransactionId = input.TransactionId,
            Currency = httpResData?.Currency,
        };
        return res;
    }

    private GameTypeEnum Cq9GameTypeChange(string? GameTypes)
    {
        GameTypeEnum gameType = new();
        switch (GameTypes)
        {
            case "slot":
                gameType = GameTypeEnum.Electron;
                break;
            case "live":
                gameType = GameTypeEnum.OogWay;
                break;
            case "arcade":
                gameType = GameTypeEnum.ChessCards;
                break;
            case "fish":
                gameType = GameTypeEnum.CatchFish;
                break;
            default:
                break;
        }
        return gameType;
    }


    private string  handleCq9GameTypeChange(GameTypeEnum? GameTypes)
    {
        string gameType = "";
        switch (GameTypes)
        {
            case GameTypeEnum.Electron:
                gameType = "slot";
                break;
            case GameTypeEnum.OogWay:
                gameType = "live";
                break;
            case GameTypeEnum.ChessCards:
                gameType = "arcade";
                break;
            case GameTypeEnum.CatchFish:
                gameType = "fish";
                break;
            default:
                break;
        }
        return gameType;
    }

    public async Task<GameResponse<GetGameRecordBetSlipsCodeOutput>> GetGameRecordBetSlipsCodeAsync(GetGameRecordBetSlipsCodeInput input)
    {
        var httpResponseResult = await _httpCQ9Api.OrderRecordAsync
            (new Models.OrderRecordInput {  GameCode=input.GameCode, RoundId=input.BetSlipsCode.ToString(), GamneHall="cq9"});
        var res = this.handlerResponse< GetGameRecordBetSlipsCodeOutput > (httpResponseResult);
        if (res.Code != 200) { return res; }
        var httpResData = httpResponseResult?.Data?.Order;
        GameTypeEnum gameType = Cq9GameTypeChange(httpResData?.GameType);
        res.Result = new GetGameRecordBetSlipsCodeOutput
        {
            GameCode = httpResData?.GameCode,
            Account = httpResData?.Account,
            BetAmount = Convert.ToDecimal(httpResData?.Bet),
            BetSlipsCode = Convert.ToInt64(httpResData?.Round),
            BetTime = httpResData?.BetTime,
            BetType = null,
            GamePlatForm = httpResData?.GamePlat,
            GameType = gameType,
            Status = null,
            ValidBetAmount = Convert.ToDecimal(httpResData?.ValidBet),
            WinsAmount = Convert.ToDecimal(httpResData?.Win),
            IncomeAmount = null,
            //PayoffTime = null,
            //PayoffAmount = null,
        };
        return res;
    }
}
