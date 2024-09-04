// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Furion.Localization;
using Ooph.AppFront.Dto.UserGameDto;
using Ooph.AppFront.Dto.UserPopularizeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ooph.AppFront.Service;

/// <summary>
/// 关于推广
/// </summary>
[ApiDescriptionSettings(Order = 100, Groups = new[] { AppConst.GroupName })]
public class UserPopularizeService : IDynamicApiController, ITransient
{
    public UserPopularizeService()
    {

    }

    /// <summary>
    /// 我的数据
    /// </summary>
    [HttpPost]
    [DisplayName("我的数据")]
    public async Task<GetMyPopularizeOutput> GetMyPopularizeAsync(GetMyPopularizeInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 全部数据
    /// </summary>
    [HttpPost]
    [DisplayName("全部数据")]
    public async Task<SqlSugarPagedList<GetAllPopularizeOutput>> GetAllPopularizeAsync(GetAllPopularizeInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 我的业绩
    /// </summary>
    [HttpPost]
    [DisplayName("我的业绩")]
    public async Task<GetMyAchievementOutput> GetMyAchievementAsync(GetMyAchievementInput input)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// 我的佣金
    /// </summary>
    [HttpPost]
    [DisplayName("我的佣金")]
    public async Task<GetMyCommissionOutput> GetMyCommissionAsync(GetMyCommissionInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 我的团队
    /// </summary>
    [HttpPost]
    [DisplayName("我的团队")]
    public async Task<GetMyTeamOutput> GetMyTeamAsync(GetMyTeamInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 直属数据
    /// </summary>
    [HttpPost]
    [DisplayName("直属数据")]
    public async Task<SqlSugarPagedList<GetImmediateDataOutput>> GetImmediateDataAsync(GetImmediateDataInput input)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// 直属投注
    /// </summary>
    [HttpPost]
    [DisplayName("直属投注")]
    public async Task<SqlSugarPagedList<GetImmediateBetListOutput>> GetImmediateBetListAsync(GetImmediateBetListInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 返佣比例
    /// </summary>
    [HttpPost]
    [DisplayName("返佣比例")]
    public async Task<RebatePercentageOutput> RebatePercentageAsync(RebatePercentageInput input)
    {
        throw new NotImplementedException();
    }
    
}