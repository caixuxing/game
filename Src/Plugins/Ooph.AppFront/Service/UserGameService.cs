// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Furion.Localization;
using Ooph.AppFront.Dto.UserGameDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ooph.AppFront.Service;

/// <summary>
/// 游戏
/// </summary>
[ApiDescriptionSettings(Order = 100, Groups = new[] { AppConst.GroupName })]
public class UserGameService : IDynamicApiController, ITransient
{
    public UserGameService()
    {

    }


    /// <summary>
    /// 游戏列表
    /// </summary>
    [HttpPost]
    [DisplayName("游戏列表")]
    public async Task<SqlSugarPagedList<PlayGameListOutput>> PlayGameListAsync(PlayGameListInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 登录游戏（游戏地址）
    /// </summary>
    [HttpPost]
    [DisplayName("登录游戏")]
    public async Task<PlayGameLoginOutput> PlayGameLoginAsync(PlayGameLoginInput input)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// 退出游戏
    /// </summary>
    [HttpPost]
    [DisplayName("退出游戏")]
    public async Task<LogOutGameOutput> LogOutGameAsync(LogOutGameInput input)
    {
        throw new NotImplementedException();
    }
}