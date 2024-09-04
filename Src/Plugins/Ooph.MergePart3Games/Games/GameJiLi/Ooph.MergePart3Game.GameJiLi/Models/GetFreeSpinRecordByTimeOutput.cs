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
public class GetFreeSpinRecordByTimeOutput : ResponseBase<GetFreeSpinRecordByTimeData?> { }

public class GetFreeSpinRecordByTimeData : GameJiliResponsePagination
{
    public List<GetFreeSpinRecordByTimeDataItem?>? GetFreeSpinRecordByTimeDataItems { get; set; }
}

public class GetFreeSpinRecordByTimeDataItem
{
    /// <summary>  
    /// 会员唯一识别值  
    /// </summary>  
    public string? Account { get; set; }

    /// <summary>  
    /// 游戏的唯一识别值  
    /// </summary>  
    public int? GameId { get; set; }

    /// <summary>  
    /// 在游戏内注单唯一值  
    /// </summary>  
    public long? WagersId { get; set; } // 注意：bigint 在 C# 中通常是 long 类型  

    /// <summary>  
    /// 投注金额  
    /// </summary>  
    public decimal? BetAmount { get; set; } // 假设精度为16位，小数点后4位  

    /// <summary>  
    /// 派彩金额  
    /// </summary>  
    public decimal? PayoffAmount { get; set; } // 同样，精度为16位，小数点后4位  

    /// <summary>  
    /// 投注时间（通常是Unix时间戳）  
    /// </summary>  
    public long? WagersTime { get; set; } // 注意：bigint 在 C# 中用于时间戳时通常是 long 类型  

    /// <summary>  
    /// 注单币别  
    /// 转账钱包时，这项为空字符串  
    /// </summary>  
    public string? Currency { get; set; }

}
