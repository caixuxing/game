using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 常见问题
/// </summary>
[SugarTable("oo_faq_question", "常见问题")]
public partial class OoFaqQuestion : EntityTenantLang
{
    /// <summary>
    /// 问题类型
    /// </summary>
    [SugarColumn(ColumnDescription = "问题类型")]
    public int? FaqTypeId { get; set; }

    /// <summary>
    /// 问题
    /// </summary>
    [SugarColumn(ColumnDescription = "问题", Length = 255)]
    public string? Question { get; set; }

    /// <summary>
    /// 问题状态
    /// </summary>
    [SugarColumn(ColumnDescription = "问题状态", ColumnDataType = "enum('已发布','待发布')")]
    public string? Status { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序", DefaultValue = "1000")]
    public int Sort { get; set; } = 1000;
}
