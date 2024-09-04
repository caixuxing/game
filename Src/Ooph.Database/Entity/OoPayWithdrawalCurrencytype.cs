using Admin.NET.Core;
using Ooph.Database.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 提现相关，设计未完成
/// </summary>
[SugarTable("oo_pay_withdrawal_currencytype", "提现相关，设计未完成")]
public partial class OoPayWithdrawalCurrencytype : EntityTenant
{
    /// <summary>
    /// 提现大类
    /// </summary>
    [SugarColumn(ColumnDescription = "提现大类", ColumnDataType = "enum('现金','Coin')")]
    public string? Category { get; set; }

    /// <summary>
    /// 提现币种
    /// </summary>
    [SugarColumn(ColumnDescription = "提现币种", Length = 50)]
    public string? WithdrawalCurrencyType { get; set; }

    /// <summary>
    /// 表单架构
    /// </summary>
    [SugarColumn(ColumnDescription = "表单架构", ColumnDataType = "json", IsJson = true, SqlParameterDbType = typeof(JsonDynamicConverter))]
    public dynamic? FormSchema { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [SugarColumn(ColumnDescription = "描述", Length = 255)]
    public string? Description { get; set; }
}
