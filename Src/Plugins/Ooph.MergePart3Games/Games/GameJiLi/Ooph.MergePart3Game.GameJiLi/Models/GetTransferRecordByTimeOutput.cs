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
public class GetTransferRecordByTimeOutput : ResponseBase<GetTransferRecordByTimeData?> { }
public class GetTransferRecordByTimeData : GameJiliResponsePagination
{
    public List<GetTransferRecordByTimeDataItem?>? TransferRecordByTimeDataResult { get; set; }

}


public class GetTransferRecordByTimeDataItem
{
    /// <summary>
    /// 会员唯一识别值
    /// </summary>
    public string? Account { get; set; }

    /// <summary>
    /// 交易序号，额度转移纪录唯一值
    /// </summary>
    public string? TransactionId { get; set; }

    /// <summary>
    /// 交易时间
    /// </summary>
    public DateTime? TransferTime { get; set; }

    /// <summary>
    /// 交易金额
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// 转账类型
    ///1: 从 游戏商 转移额度到 平台商
    ///2: 从 平台商 转移额度到 游戏商
    /// </summary>
    public int? TransferType { get; set; }

    /// <summary>
    /// 状态：
    ///1: 成功
    ///2: 失败
    /// </summary>
    public int? Status { get; set; }
}
