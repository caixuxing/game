using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 三方类型(全局)
/// </summary>
[SugarTable("oo_party3_type", "三方类型(全局)")]
public partial class OoParty3Type : EntityBase
{
    /// <summary>
    /// 接口类型ID
    /// </summary>
    [SugarColumn(ColumnDescription = "接口类型ID", Length = 20, IsOnlyIgnoreUpdate = true)]
    public string TypeKey { get; set; } = null!;

    /// <summary>
    /// 接口类型名称
    /// </summary>
    [SugarColumn(ColumnDescription = "接口类型名称", Length = 50)]
    public string? TypeName { get; set; }

    /// <summary>
    /// 简单描述
    /// </summary>
    [SugarColumn(ColumnDescription = "简单描述", Length = 255)]
    public string? Description { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", ColumnDataType = "text")]
    public string? Remark { get; set; }

    /// <summary>
    /// 排序号
    /// </summary>
    [SugarColumn(ColumnDescription = "排序号", DefaultValue = "1000")]
    public int Sort { get; set; } = 1000;

    /// <summary>
    /// 是否可以编辑
    /// </summary>
    [SugarColumn(ColumnDescription = "是否可以编辑", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsCanEditer { get; set; }

    /// <summary>
    /// 是否在后台显示
    /// </summary>
    [SugarColumn(ColumnDescription = "是否在后台显示", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsShowed { get; set; }

}
