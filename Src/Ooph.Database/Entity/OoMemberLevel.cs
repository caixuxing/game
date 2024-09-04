using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 会员等级（层级）
/// </summary>
[SugarTable("oo_member_level", "会员等级（层级）")]
public partial class OoMemberLevel : EntityTenantCurrency
{
    /// <summary>
    /// 层级名称
    /// </summary>
    [SugarColumn(ColumnDescription = "层级名称", Length = 50)]
    public string? LevelName { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [SugarColumn(ColumnDescription = "描述", Length = 255)]
    public string? Description { get; set; }

    /// <summary>
    /// 充值次数
    /// </summary>
    [SugarColumn(ColumnDescription = "充值次数")]
    public int? RechargeCount { get; set; }

    /// <summary>
    /// 累计充值金额
    /// </summary>
    [SugarColumn(ColumnDescription = "累计充值金额", ColumnDataType = "decimal(18, 4)")]
    public decimal? RechargeAmountTotal { get; set; }

    [SugarColumn(DefaultValue = "100")]
    public short Sort { get; set; } = 100;
}
