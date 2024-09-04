using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 配置分组
/// </summary>
[SugarTable("oo_config_group", "配置分组")]
public partial class OoConfigGroup : EntityTenant
{
    /// <summary>
    /// 分组名称
    /// </summary>
    [SugarColumn(ColumnDescription = "分组名称", Length = 20)]
    public string? GroupName { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [SugarColumn(ColumnDescription = "描述", Length = 255)]
    public string? Description { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序", DefaultValue = "100")]
    public short Sort { get; set; } = 100;
}
