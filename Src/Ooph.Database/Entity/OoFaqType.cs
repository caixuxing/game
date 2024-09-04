using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 问题类型
/// </summary>
[SugarTable("oo_faq_type", "问题类型")]
public partial class OoFaqType : EntityTenantLang
{
    /// <summary>
    /// 问题类型名称
    /// </summary>
    [SugarColumn(ColumnDescription = "问题类型名称", Length = 255)]
    public string TypeName { get; set; } = null!;
}
