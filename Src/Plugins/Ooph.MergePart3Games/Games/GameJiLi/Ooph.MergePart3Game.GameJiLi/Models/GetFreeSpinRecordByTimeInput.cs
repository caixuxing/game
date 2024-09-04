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
public class GetFreeSpinRecordByTimeInput
{

    /// <summary>  
    /// 查询开始时间  
    /// 格式: YYYY-MM-DDThh:mm:ss, 使用GMT-4时区的时间  
    /// </summary>  
    public DateTime? StartTime { get; set; }

    /// <summary>  
    /// 查询结束时间  
    /// 格式同StartTime  
    /// 注意事项: 由于游戏纪录会有写入延迟, 建议使用5到10分钟前的时间作为EndTime  
    /// </summary>  
    public DateTime? EndTime { get; set; }

    /// <summary>  
    /// 页数(从1开始)  
    /// </summary>  
    public int? Page { get; set; }

    /// <summary>  
    /// 每页资料笔数, 最多20,000, 最少10000  
    /// </summary>  
    public int? PageLimit { get; set; }

    /// <summary>  
    /// 游戏的唯一识别值  
    /// 注意事项: 在计算key时请忽略此字段  
    /// </summary>  
    public int? GameId { get; set; }

    /// <summary>  
    /// 过滤条件: 只捞取该站长(AgentId)代理的注单  
    /// 1: 只捞取该站长(AgentId)代理的注单  
    /// 0 或不带值: 捞取所有站长代理的注单  
    /// 注意事项: 在计算key时请忽略此字段  
    /// </summary>  
    public int? FilterAgent { get; set; }
}
