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
public class CreateFreeSpinForManyInput
{

    /// <summary>  
    /// 玩家账号，新玩家则会自动创立账号。超过一笔时以逗号分隔（最多200笔账号）  
    /// </summary>  
    public string? Accounts { get; set; }

    /// <summary>  
    /// 转账钱包，这项请填空字符串  
    /// </summary>  
    public string? Currency { get; set; } 

    /// <summary>  
    /// 免费局数序号，长度上限50，超过一笔时以逗号分隔（最多200笔序号）  
    /// </summary>  
    public string? ReferenceIds { get; set; }

    /// <summary>  
    /// 有效期限，格式为 YYYY-MM-DDTHH:MM:SS (2006-01-02T15:04:05)，时区为 GMT-4  
    /// </summary>  
    // 注意：这里假设您已经处理了时区转换，或者数据库/服务器已经存储为GMT-4时间  
    public DateTime? FreeSpinValidity { get; set; }

    /// <summary>  
    /// 局数  
    /// </summary>  
    public int? NumberOfRounds { get; set; }

    /// <summary>  
    /// 可使用游戏ID，超过一笔时以逗号分隔；长度（含逗号）上限200  
    /// </summary>  
    public string? GameIds { get; set; }

    /// <summary>  
    /// 指定投注额；未指定时，一律使用游戏中的最小投注额  
    /// 注意：这里使用0作为默认值表示未指定  
    /// </summary>  
    public decimal? BetValue { get; set; } 

    /// <summary>  
    /// 免费游戏局数可使用的开始时间，格式为 YYYY-MM-DDTHH:MM:SS (2006-01-02T15:04:05)，时区为 GMT-4  
    /// 未带此参数时，赠送后玩家可以立即使用  
    /// 注意：这个属性在计算key时被忽略  
    /// </summary>  
    // 注意：由于P.S.中说明计算key时请忽视，所以这里只是作为一个可选属性存在  
    public DateTime? StartTime { get; set; }

}
