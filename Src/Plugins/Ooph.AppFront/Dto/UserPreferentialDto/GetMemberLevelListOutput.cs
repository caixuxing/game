// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.AppFront.Dto.UserPreferentialDto;
public class GetMemberLevelListOutput
{
    /// <summary>
    /// Vip等级名称
    /// </summary>
    public string? VipLevelName { get; set; }

    /// <summary>
    /// 晋级奖金
    /// </summary>
    public decimal? PromotionAmount { get; set; }

    /// <summary>
    /// 晋级再投注金额
    /// </summary>
    public decimal? PromotionBetAmount { get; set; }

    /// <summary>
    /// 月俸禄
    /// </summary>
    public decimal? MouthSalaryAmount { get; set; }

    /// <summary>
    /// 周俸禄
    /// </summary>
    public decimal? WeekSalaryAmount { get; set; }

    /// <summary>
    /// 每日提现总额上限
    /// </summary>
    public decimal? PayoutsTotalCeiling { get; set; }

    /// <summary>
    /// 每日提现次数上限
    /// </summary>
    public int? PayoutsNumberCeiling { get; set; }

    /// <summary>
    /// 每日免手续费笔数
    /// </summary>
    public int? FreeOfChargeNumber { get; set; }

}
