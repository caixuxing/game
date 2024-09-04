// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Furion.Localization;
using Ooph.AppFront.Dto.UserMessageDto;
using Ooph.AppFront.Dto.UserPreferentialDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ooph.AppFront.Service;

/// <summary>
/// 消息通知
/// </summary>
[ApiDescriptionSettings(Order = 100, Groups = new[] { AppConst.GroupName })]
public class UserMessageService : IDynamicApiController, ITransient
{
    public UserMessageService()
    {

    }

    /// <summary>
    /// 查询跑马灯
    /// </summary>
    [HttpPost]
    [DisplayName("查询跑马灯")]
    public async Task<SqlSugarPagedList<GetAdHallMarqueeListOutput>> GetAdHallMarqueeListAsync(GetAdHallMarqueeListInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 查询宣传列表
    /// </summary>
    [HttpPost]
    [DisplayName("查询宣传列表")]
    public async Task<SqlSugarPagedList<GetAdLeafletListOutput>> GetAdLeafletListAsync(GetAdLeafletListInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 查询公告、通知列表
    /// </summary>
    [HttpPost]
    [DisplayName("查询公告、通知列表")]
    public async Task<SqlSugarPagedList<GetNoticeListOutput>> GetNoticeListAsync(GetNoticeListInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 查询常见问题
    /// </summary>
    [HttpPost]
    [DisplayName("查询常见问题")]
    public async Task<GetFaqQuestionOutput> GetFaqQuestionAsync(GetFaqQuestionInput input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 查询在线客服
    /// </summary>
    [HttpPost]
    [DisplayName("查询在线客服")]
    public async Task<GetOnlineCustomerOutput> GetOnlineCustomerAsync(GetOnlineCustomerInput input)
    {
        throw new NotImplementedException();
    }
}