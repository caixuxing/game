// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Wordprocessing;
using Furion.Localization;
using Furion.Schedule;
using Furion.TaskQueue;
using Ooph.Database.Entity;
using Ooph.MergePart3Game;
using Ooph.MergePart3Game.Models.Enum;
using Ooph.MergePart3Game.Models.FeatureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ooph.AppBackground.Service;

[ApiDescriptionSettings(Order = 100, Groups = new[] { AppConst.GroupName_Test })]
public class TestGameService : IDynamicApiController, ITransient
{
    Part3GameInfoFeature part3GameInfo = new Part3GameInfoFeature
    {
        Part3GamePlatformType = "CQ9"
    };
    
    private readonly SqlSugarRepository<OoGameGame> _ooGameGame;
    private readonly SqlSugarRepository<OoGameLang> _ooGameLang;

    public TestGameService(
        SqlSugarRepository<OoGameGame> ooGameGame,
        SqlSugarRepository<OoGameLang> ooGameLang
        )
    {
        this._ooGameGame = ooGameGame;
        this._ooGameLang = ooGameLang;
    }

    public async void SyncGame()
    {
        part3GameInfo.Part3GamePlatformType = "CQ9";
        App.HttpContext?.Features.Set(part3GameInfo);
        var _part3GameService = App.GetService<Part3GameService>();
        var addGameDataList = new List<OoGameGame>();
        var updateGameDataList = new List<OoGameGame>();
        var addGameLangList = new List<OoGameLang>();
        var updateGameLangList = new List<OoGameLang>();

        var data= await _part3GameService.GetGameListAsync(new MergePart3Game.Models.GetGameListInput {  });
        if (data.Result != null) {
            var gameList=await _ooGameGame.AsQueryable().ToListAsync();
            var gameLangList=await _ooGameLang.AsQueryable().ToListAsync(); 

            #region [游戏]
            foreach (var item in data.Result)
            {
                long gameCategoryId = handleGameType(item.GameType);
                var gameName = "";
                if (item.GameName!.ContainsKey("zh-Hans"))
                {
                    gameName = item.GameName["zh-Hans"];
                }
                var game = gameList.Where(x => x.GameCode == item.GameCode && x.GamePlatformCode == part3GameInfo.Part3GamePlatformType).FirstOrDefault();
                if (game != null)
                {
                    if (game.GameName != gameName || game.GameCategoryId != gameCategoryId)
                    {
                        var gameData = new OoGameGame
                        {
                            GamePlatformCode = part3GameInfo.Part3GamePlatformType,
                            GameCategoryId = gameCategoryId,
                            GameName = gameName,
                            GameCode = item.GameCode,
                            Id = game.Id,
                        };
                        updateGameDataList.Add(gameData);
                    }
                }
                else
                {
                    var gameData = new OoGameGame
                    {
                        GamePlatformCode = part3GameInfo.Part3GamePlatformType,
                        GameCategoryId = gameCategoryId,
                        GameName = gameName,
                        GameCode = item.GameCode,
                    };
                    addGameDataList.Add(gameData);
                }

            }
            await _ooGameGame.InsertRangeAsync(addGameDataList);
            await _ooGameGame.UpdateRangeAsync(updateGameDataList);
            #endregion

            var gameIds = await _ooGameGame.AsQueryable()
                .Where(x => x.GamePlatformCode == part3GameInfo.Part3GamePlatformType)
                .Select(x=>new { x.Id, x.GameCode, })
                .ToListAsync();  
            foreach (var game in addGameDataList) {
                var id = gameIds.FirstOrDefault(x => x.GameCode == game.GameCode)?.Id;
                if (id != null) { game.Id = id.Value; }
            }

            #region [语言]
            foreach (var item in data.Result)
            {
                var id = gameIds.FirstOrDefault(x => x.GameCode == item.GameCode)?.Id;
                if (item.GameName != null)
                {
                    foreach (var langItem in item.GameName)
                    {
                        var langData = gameLangList.Where(x => x.GameId == id && x.Lang == langItem.Key).FirstOrDefault();
                        if (langData != null)
                        {
                            if (langData.GameName != langItem.Value)
                            {
                                var lang = new OoGameLang
                                {
                                    Lang = langItem.Key,
                                    GameName = langItem.Value,
                                    GameId = langData?.GameId,
                                };
                                updateGameLangList.Add(lang);
                            }
                        }
                        else
                        {
                            var lang = new OoGameLang
                            {
                                Lang = langItem.Key,
                                GameName = langItem.Value,
                                GameId = id
                            };
                            addGameLangList.Add(lang);
                        }
                    }
                }
            }
            await _ooGameLang.InsertRangeAsync(addGameLangList);
            await _ooGameLang.UpdateRangeAsync(updateGameLangList);
        }

        #endregion

    }

    private long handleGameType(GameTypeEnum? gameTypeEnum)
    {
        #region MyRegion
        long gameCategoryId = 0;
        switch (gameTypeEnum)
        {
            case GameTypeEnum.Physical:
                gameCategoryId = 1300000000301;
                break;
            case GameTypeEnum.ChessCards:
                gameCategoryId = 1300000000302;
                break;
            case GameTypeEnum.CatchFish:
                gameCategoryId = 1300000000303;
                break;
            case GameTypeEnum.Electron:
                gameCategoryId = 1300000000304;
                break;
            case GameTypeEnum.Blockchain:
                gameCategoryId = 1300000000305;
                break;
            case GameTypeEnum.OogWay:
                gameCategoryId = 1300000000306;
                break;
            case GameTypeEnum.LotteryTicket:
                gameCategoryId = 1300000000307;
                break;
            case GameTypeEnum.Others:
                gameCategoryId = 1300000000308;
                break;
            case GameTypeEnum.Esports:
                gameCategoryId = 1300000000309;
                break;
            default:
                break;
        }
        return gameCategoryId;

        #endregion
    }
}