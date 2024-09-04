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

namespace Ooph.MergePart3Game.GameCQ9.Models;
public class GameListOutput : ResponseBase<List<GameHallData?>?> { }

public class GameHallData
{
    /// <summary>
    /// 游戏厂商
    /// </summary>
    public string? Gamehall { get; set; }

    /// <summary>
    /// 游戏种类
    /// </summary>
    public string? GameType { get; set; }

    /// <summary>
    /// 游戏代码
    /// </summary>
    public string? GameCode { get; set; }

    /// <summary>
    /// 游戏名称
    /// </summary>
    public string? GameName { get; set; }

    /// <summary>
    /// 游戏技术
    /// </summary>
    public string? GameTech { get; set; }

    /// <summary>
    /// 游玩平台
    /// </summary>
    public string? GamePlat { get; set; }

    /// <summary>
    /// 支援语系
    /// </summary>
    public List<string?>? Lang { get; set; }

    /// <summary>
    /// 游戏状态
    /// </summary>
    public bool? Status { get; set; }

    /// <summary>
    /// 维护状态
    /// </summary>
    public bool? MainTain { get; set; }

    /// <summary>
    /// 游戏名称阵列
    /// </summary>
    public List<Nameset?>? Nameset { get; set; }
}

/// <summary>
/// 游戏名称阵列
/// </summary>
public class Nameset
{
    /// <summary>
    /// 游戏名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 游戏名称语系
    /// </summary>
    public string? Lang { get; set; }
}
