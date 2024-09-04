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
public class GetFreeSpinRecordSummaryInput
{

    /// <summary>  
    /// 查询开始时间  
    /// </summary>  
    public DateTime? StartTime { get; set; }

    /// <summary>  
    /// 查询结束时间  
    /// </summary>  
    public DateTime? EndTime { get; set; }

    /// <summary>  
    /// 查询货币代码  
    /// 未指定时，回传结果将包含所有币别的个别加总  
    /// </summary>  
    public string? Currency { get; set; }

    /// <summary>  
    /// 是否只查询所指定代理（AgentId）下的注单统计  
    /// 未指定时，回传结果为所有代理的加总  
    /// 注意：在计算key时，此属性应被忽略（但通常这是逻辑层处理的问题，而不是实体类的职责）  
    /// </summary>  
    public bool? FilterAgent { get; set; }
}
