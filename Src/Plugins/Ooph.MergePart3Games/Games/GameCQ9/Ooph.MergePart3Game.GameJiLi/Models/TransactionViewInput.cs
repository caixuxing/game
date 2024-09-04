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
public class TransactionViewInput
{
    /// 查询日期开始时间，格式为RFC3339，例如：2017-06-01T00:00:00-04:00  
    /// 时区请使用UTC-4  
    public DateTime? StartTime { get; set; }

    // 查询日期结束时间，格式为RFC3339，例如：2017-06-02T00:00:00-04:00  
    // 时区请使用UTC-4  
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// 帐号，字符串长度限制为36个字符  
    /// </summary>
    public string? Account { get; set; }

    /// <summary>
    /// 查询页数，必填  
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// 每页笔数，可选，默认值为500，最大值为2000  
    /// </summary>
    public int? PageSize { get; set; }
}
