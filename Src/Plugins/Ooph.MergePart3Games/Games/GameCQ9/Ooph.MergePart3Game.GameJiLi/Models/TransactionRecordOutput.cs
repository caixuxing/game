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
public class TransactionRecordOutput : ResponseBase<TransactionRecordData?> { }

public class TransactionRecordData
{
    /// <summary>  
    /// 交易代码，用于标识唯一的交易。  
    /// </summary>  
    public string? MtCode { get; set; }

    /// <summary>  
    /// 币别，表示交易使用的货币类型。  
    /// </summary>  
    public string? Currency { get; set; }

    /// <summary>  
    /// 金额，表示交易的具体数额。  
    /// </summary>  
    public decimal? Amount { get; set; }

    /// <summary>  
    /// 事件时间，表示交易发生的时间。  
    /// </summary>  
    public string? EventTime { get; set; }

    /// <summary>  
    /// 余额，表示交易后的账户余额。  
    /// </summary>  
    public decimal? Balance { get; set; }

    /// <summary>  
    /// 动作，表示交易的类型，可取值为"cashin"（充值）或"cashout"（提现）。  
    /// </summary>  
    public string? Action { get; set; }

    /// <summary>  
    /// 状态，表示交易的结果，可取值为"success"（成功）、"failed"（失败）或"pending"（尚未完成交易）。  
    /// </summary>  
    public string? Status { get; set; }
}
