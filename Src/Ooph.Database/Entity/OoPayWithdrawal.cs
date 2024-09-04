using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 提现相关（未设计完）
/// </summary>
[SugarTable("oo_pay_withdrawal", "提现相关")]
public partial class OoPayWithdrawal : EntityTenant
{
    /// <summary>
    /// 提现方式（大类）如：银行卡提现、数字货币、第三方钱包
    /// </summary>
    [SugarColumn(ColumnDescription = "提现方式（大类）如：银行卡提现、数字货币、第三方钱包", ColumnDataType = "enum('VirtualCoin','BankCard','Party3Wallet')")]
    public string? WithdrawalWay { get; set; }

    /// <summary>
    /// 收款账户
    /// </summary>
    [SugarColumn(ColumnDescription = "收款账户", Length = 20)]
    public string? ReceivingAccount { get; set; }
}
