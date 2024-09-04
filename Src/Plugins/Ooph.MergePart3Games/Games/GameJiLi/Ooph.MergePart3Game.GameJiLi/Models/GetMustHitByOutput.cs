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

namespace Ooph.MergePart3Game.GameJiLi.Models;
public class GetMustHitByOutput : ResponseBase<List<GetMustHitByData?>?> { }

public class GetMustHitByData
{
    /// <summary>  
    /// 币别名称  
    /// </summary>  
    public string? Currency { get; set; }

    /// <summary>  
    /// 游戏名称  
    /// </summary>  
    public string? Game { get; set; }

    /// <summary>  
    /// 游戏ID识别值  
    /// </summary>  
    public int? GameId { get; set; }

    /// <summary>  
    /// 满额必开水箱（可能是指某种游戏机制下，当达到某个金额或条件时，必须触发的奖励或事件）  
    /// </summary>  
    public decimal? MustHitByPool { get; set; }

    /// <summary>  
    /// 满额必开数值（与MustHitByPool配合使用，指定了必须达到的具体数值或条件）  
    /// </summary>  
    public decimal? MustHitByValue { get; set; }
}
