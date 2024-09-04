// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game.GameJiLi.Models;
public class GetGameListOutput : ResponseBase<List<GetGameListData?>?> { }

public class GetGameListData
{
    /// <summary>  
    /// 游戏的唯一识别值  
    /// </summary>  
    public int? GameId { get; set; }

    /// <summary>  
    /// 游戏名称，支持多种语言  
    /// 字典的键为语言代码（如"zh-CN"、"zh-TW"、"en-US"），值为对应的游戏名称  
    /// </summary>  
    //public GetGameListData_NameObject? Name { get; set; }
    public Dictionary<string,string>? Name { get; set; }

    /// <summary>  
    /// 游戏类型, 请参考附录 – 游戏类型  
    /// </summary>  
    public int? GameCategoryId { get; set; }

    /// <summary>  
    /// true: 此款游戏内建 JP  
    /// false: 无内建 JP  
    /// </summary>  
    public bool? JP { get; set; }

    /// <summary>  
    /// true: 此款游戏支持免费游戏 (§3.2);  
    /// false: 不支持免费游戏  
    /// </summary>  
    public bool? Freespin { get; set; }
}
