// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Ooph.MergePart3Game.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game.Models;
public class GetGameRecordBetSlipsCodeOutput
{
    /// <summary>
    /// 账号
    /// </summary>
    public string? Account { get; set; }

    /// <summary>
    /// 注单号
    /// </summary>
    public long? BetSlipsCode { get; set; }

    /// <summary>
    /// 游戏编码
    /// </summary>
    public string? GameCode { get; set; }

    /// <summary>
    /// 游戏种类
    /// </summary>
    public GameTypeEnum? GameType { get; set; }

    /// <summary>
    /// 游戏平台
    /// </summary>
    public string? GamePlatForm { get; set; }

    /// <summary>
    /// 投注时间
    /// </summary>
    public DateTime? BetTime { get; set; }

    /// <summary>
    /// 投注金额
    /// </summary>
    public decimal? BetAmount { get; set; }

    /// <summary>
    /// 有效投注金额 
    /// </summary>
    public decimal? ValidBetAmount { get; set; }

    /// <summary>
    /// 赢分金额
    /// </summary>
    public decimal? WinsAmount { get; set; }

    /// <summary>
    /// 损益金额
    /// </summary>
    public decimal? IncomeAmount { get; set; }

    /// <summary>
    /// 注单状态：
    ///1: 赢 2: 输 3: 平局
    /// </summary>
    public int? Status { get; set; }


    /// <summary>
    /// 注单类型
    /// </summary>
    public int? BetType { get; set; }


    ///// <summary>
    ///// 派彩时间
    ///// </summary>
    //public DateTime? PayoffTime { get; set; }

    ///// <summary>
    ///// 派彩金额
    ///// </summary>
    //public decimal? PayoffAmount { get; set; }
}
