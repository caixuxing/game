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
public class TransactionHistoryOutput : ResponseBase<TransactionHistoryData?> { }

public class TransactionHistoryData
{
    /// <summary>  
    /// 总笔数，表示查询结果中的总记录数。  
    /// </summary>  
    public int? Total { get; set; }

    /// <summary>  
    /// 
    /// </summary>  
    public List<TransactionHistoryItem?>? List { get; set; }
}

public class TransactionHistoryItem
{

    /// <summary>  
    /// 交易代码，用于标识唯一的交易。  
    /// </summary>  
    public string? Mtcode { get; set; }

    /// <summary>  
    /// 币别，表示交易使用的货币类型。  
    /// </summary>  
    public string? Currency { get; set; }

    /// <summary>  
    /// 金额，表示交易的具体数额，使用float64类型表示。  
    /// </summary>  
    public decimal? Amount { get; set; }

    /// <summary>  
    /// 事件时间，表示交易发生的时间，格式为字符串。  
    /// </summary>  
    public DateTime? EventTime { get; set; }

    /// <summary>  
    /// 处理后余额，表示交易完成后账户中的余额。  
    /// </summary>  
    public decimal? Balance { get; set; }

    /// <summary>  
    /// 处理前余额，表示交易发生前账户中的余额。  
    /// </summary>  
    public decimal? Before { get; set; }

    /// <summary>  
    /// 动作，表示交易的类型，可取值为"cashin"（存款）、"cashout"（提款）、"rollin"（游戏转入）、  
    /// "rollout"（游戏转出）、"bet"（下注）、"win"（赢分）、"payoff"（派彩）、"refund"（退款）。  
    /// </summary>  
    public string? Action { get; set; }

    /// <summary>  
    /// 状态，表示交易的结果，可取值为"success"（成功）、"failed"（失败）、"pending"（尚未完成交易）、  
    /// "refund"（退款）。注意："refund"在这里同时作为状态和动作，具体含义需结合上下文判断。  
    /// </summary>  
    public string? Status { get; set; }
}
