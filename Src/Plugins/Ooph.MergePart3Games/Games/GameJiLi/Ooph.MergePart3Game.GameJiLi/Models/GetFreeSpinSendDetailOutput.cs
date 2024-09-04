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
public class GetFreeSpinSendDetailOutput : ResponseBase<List<GetFreeSpinSendDetailData?>?> { }

public class GetFreeSpinSendDetailData
{
    /// <summary>  
    /// 会员唯一识别值  
    /// </summary>  
    public string? Account { get; set; }

    /// <summary>  
    /// 免费局数序号  
    /// </summary>  
    public string? ReferenceId { get; set; }

    /// <summary>  
    /// 免费局数赠送数量  
    /// </summary>  
    public int? SendAmount { get; set; }

    /// <summary>  
    /// 免费局数赠送时间  
    /// </summary>  
    public DateTime? SendTime { get; set; }

    /// <summary>  
    /// 免费局数过期时间  
    /// </summary>  
    public DateTime? ExpiredTime { get; set; }

    /// <summary>  
    /// 免费局数赠送游戏  
    /// </summary>  
    public string? SendGame { get; set; }

    /// <summary>  
    /// 免费局数使用数量  
    /// </summary>  
    public int? UsedAmount { get; set; }

    /// <summary>  
    /// 免费局数未使用数量  
    /// </summary>  
    public int? UnusedAmount { get; set; }

    /// <summary>  
    /// 免费局数绑定游戏 (0: 未绑定游戏)  
    /// </summary>  
    public int? ClaimGame { get; set; }

}
