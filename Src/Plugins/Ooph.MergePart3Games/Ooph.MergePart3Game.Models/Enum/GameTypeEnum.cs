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

namespace Ooph.MergePart3Game.Models.Enum;

/// <summary>
/// 游戏种类
/// </summary>
[Description("游戏种类")]
public enum GameTypeEnum
{
    /// <summary>
    /// 体育
    /// </summary>
    [Description("体育")]
    Physical ,

    /// <summary>
    /// 棋牌
    /// </summary>
    [Description("棋牌")]
    ChessCards,

    /// <summary>
    /// 捕鱼
    /// </summary>
    [Description("捕鱼")]
    CatchFish,

    /// <summary>
    /// 电子
    /// </summary>
    [Description("电子")]
    Electron ,
    
    /// <summary>
    /// 电竞
    /// </summary>
    [Description("电竞")]
    Esports,

    /// <summary>
    /// 区块链
    /// </summary>
    [Description("区块链")]
    Blockchain,

    /// <summary>
    /// 真人
    /// </summary>
    [Description("真人")]
    OogWay,

    /// <summary>
    /// 彩票
    /// </summary>
    [Description("彩票")]
    LotteryTicket,

    /// <summary>
    /// 其他
    /// </summary>
    [Description("其他")]
    Others,
}
