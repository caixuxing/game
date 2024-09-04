// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Core;
using Microsoft.Extensions.Primitives;
using Ooph.IMergePart3Game;
using Ooph.MergePart3Game.Models;
using Ooph.MergePart3Game.Models.FeatureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game;

public class Part3GameService : IPart3GameAggre, ITransient
{
    private readonly IPart3GameSub _Part3Game;
    private readonly UserManager userManager;

    public Part3GameService(UserManager userManager, INamedServiceProvider<IPart3GameSub> part3GameNamedServiceProvider)
    {
        this.userManager = userManager;
        var _gameType = "";
        #region [_gameType给值]
        var part3GameInfo = App.HttpContext?.Features?.Get<Part3GameInfoFeature>();
        if (part3GameInfo != null)
        {
            _gameType = part3GameInfo?.Part3GamePlatformType;
        }
        else
        {
            part3GameInfo = App.GetService<Part3GameInfoFeature>();
            if (part3GameInfo != null && string.IsNullOrWhiteSpace(part3GameInfo.Part3GamePlatformType))
            {
                part3GameInfo.Part3GamePlatformType = "游戏平台类型名称";
                _gameType = part3GameInfo.Part3GamePlatformType;
            }
        }

        if (string.IsNullOrWhiteSpace(_gameType))
        {
            throw Oops.Oh("如果是在请求中，请先通过 App.HttpContext.Features.Set<Part3GameInfoFeature>(gameInfo) 设置第三方平台信息。如果是在非请求中，请先通过 var part3GameInfo = App.GetService<Part3GameInfoFeature>(); part3GameInfo.Part3GamePlatformType = '游戏平台类型名称';");
        }
        #endregion

        var name = $"Game{_gameType}Service";
        _Part3Game = (IPart3GameSub)part3GameNamedServiceProvider.GetService(name);
    }

    public Task<GameResponse<CreatePlayerOutput>> CreatePlayerAsync(CreatePlayerInput input)
    {
        return this._Part3Game.CreatePlayerAsync(input);
    }

    public Task<GameResponse<List<GetGameListOutput>>> GetGameListAsync(GetGameListInput input)
    {
        return this._Part3Game.GetGameListAsync(input);
    }

    public Task<GameResponse<List<GetGamePlayerRecordOutput>>> GetGamePlayerRecordAsync(GetGamePlayerRecordInput input)
    {
        return this._Part3Game.GetGamePlayerRecordAsync(input);
    }

    public Task<GameResponse<GetGameRecordBetSlipsCodeOutput>> GetGameRecordBetSlipsCodeAsync(GetGameRecordBetSlipsCodeInput input)
    {
        return this._Part3Game.GetGameRecordBetSlipsCodeAsync(input);
    }

    public Task<GameResponse<List<GetGameRecordListOutput>>> GetGameRecordListAsync(GetGameRecordListInput input)
    {
        return this._Part3Game.GetGameRecordListAsync(input);
    }

    public Task<GameResponse<GetGameUrlOutput>> GetGameUrlAsync(GetGameUrlInput input)
    {
        return this._Part3Game.GetGameUrlAsync(input);
    }

    public Task<GameResponse<List<GetPayTransactionListOutput>>> GetPayTransactionListAsync(GetPayTransactionListInput input)
    {
        return this._Part3Game.GetPayTransactionListAsync(input);
    }

    public Task<GameResponse<GetPayTransactionRecordOutput>> GetPayTransactionRecordAsync(GetPayTransactionRecordInput input)
    {
        return this._Part3Game.GetPayTransactionRecordAsync(input);
    }

    public Task<GameResponse<LogOutAllOutput>> LogOutAllAsync(LogOutAllInput input)
    {
        return this._Part3Game.LogOutAllAsync(input);
    }

    public Task<GameResponse<LogOutOutput>> LogOutAsync(LogOutInput input)
    {
        return this._Part3Game.LogOutAsync(input);
    }

    public Task<GameResponse<SaveDepositOutput>> SaveDepositAsync(SaveDepositInput input)
    {
        return this._Part3Game.SaveDepositAsync(input);
    }

    public Task<GameResponse<WithdrawalOutput>> WithdrawalAsync(WithdrawalInput input)
    {
        return this._Part3Game.WithdrawalAsync(input);
    }

   
}