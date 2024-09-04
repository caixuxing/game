// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Furion.Localization;
using Ooph.AppFront.Dto.UserPreferentialDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ooph.AppFront.Service;

/// <summary>
/// 优惠中心
/// </summary>
[ApiDescriptionSettings(Order = 100, Groups = new[] { AppConst.GroupName })]
public class UserPreferentialService : IDynamicApiController, ITransient
{
    public UserPreferentialService()
    {

    }

    /// <summary>
    /// 查询活动列表
    /// </summary>
    [HttpPost]
    [DisplayName("查询活动列表")]
    public async Task<SqlSugarPagedList<GetActivityListOutput>> GetActivityListAsync(GetActivityListInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 查询任务列表（可传参数：新人福利、每日任务）
    /// </summary>
    [HttpPost]
    [DisplayName("查询任务列表（新人福利、每日任务）")]
    public async Task<SqlSugarPagedList<GetMissionListOutput>> GetMissionListAsync(GetMissionListInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 查询领取记录
    /// </summary>
    [HttpPost]
    [DisplayName("查询领取记录")]
    public async Task<SqlSugarPagedList<GetReceiveRecordListOutput>> GetReceiveRecordListAsync(GetReceiveRecordListInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 查询待领取奖励
    /// </summary>
    [HttpPost]
    [DisplayName("查询待领取奖励")]
    public async Task<SqlSugarPagedList<GetWaitreWardListOutput>> GetWaitreWardListAsync(GetWaitreWardListInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 查询会员VIP等级列表
    /// </summary>
    [HttpPost]
    [DisplayName("查询VIP等级")]
    public async Task<GetMemberLevelListOutput> GetMemberLevelListAsync(GetMemberLevelListInput input)
    {
        throw new NotImplementedException();
    }
}