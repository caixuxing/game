using Admin.NET.Core;
using Ooph.Database.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 三方凭证详情(租户级)
/// </summary>
[SugarTable("oo_party3_voucherdetail", "三方凭证详情(租户级)")]
public partial class OoParty3Voucherdetail : EntityTenant
{
    /// <summary>
    /// 类型Key
    /// </summary>
    [SugarColumn(ColumnDescription = "类型Key", Length = 20, IsOnlyIgnoreUpdate = true)]
    public string? TypeKey { get; set; }

    /// <summary>
    /// 凭证Key
    /// </summary>
    [SugarColumn(ColumnDescription = "凭证Key", Length = 255, IsOnlyIgnoreUpdate = true)]
    public string? VoucherKey { get; set; }

    /// <summary>
    /// 租户级别凭证信息（可编辑，可显示）
    /// </summary>
    [SugarColumn(ColumnDescription = "租户级别凭证信息（可编辑，可显示）", ColumnDataType = "json", IsJson = true, SqlParameterDbType = typeof(JsonDynamicConverter))]
    public dynamic? Voucher { get; set; }

    /// <summary>
    /// 凭证标识，一般不用填，主要用于辅助查询用
    /// </summary>
    [SugarColumn(ColumnDescription = "凭证标识，一般不用填，主要用于辅助查询用", Length = 255)]
    public string? VouchFlag { get; set; }

    /// <summary>
    /// 描述 或 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "描述 或 备注", Length = 255)]
    public string? Description { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序", DefaultValue = "1000")]
    public int Sort { get; set; } = 1000;

}
