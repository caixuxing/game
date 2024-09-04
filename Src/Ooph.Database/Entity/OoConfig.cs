using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 配置
/// </summary>
[SugarTable("oo_config", "配置")]
public partial class OoConfig : EntityTenant
{
    [SugarColumn(Length = 20)]
    public string? Menu { get; set; }

    /// <summary>
    /// 配置组
    /// </summary>
    [SugarColumn(ColumnDescription = "配置组", Length = 20)]
    public string? ConfigGroup { get; set; }

    /// <summary>
    /// 配置名称
    /// </summary>
    [SugarColumn(ColumnDescription = "配置名称", Length = 50)]
    public string? ConfigName { get; set; }

    /// <summary>
    /// 配置值
    /// </summary>
    [SugarColumn(ColumnDescription = "配置值", Length = 255)]
    public string? ConfigValue { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [SugarColumn(ColumnDescription = "描述", Length = 255)]
    public string? Description { get; set; }
}
