using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 代理层级关系
/// </summary>
[SugarTable("oo_agent_tree_path", "代理层级关系")]
public partial class OoAgentTreePath : EntityTenant
{
    /// <summary>
    /// 会员ID
    /// </summary>
    [SugarColumn(ColumnDescription = "会员ID")]
    public long? NodeId { get; set; }

    /// <summary>
    /// 根节点ID
    /// </summary>
    [SugarColumn(ColumnDescription = "根节点ID")]
    public long? RootId { get; set; }

    /// <summary>
    /// 父节点ID
    /// </summary>
    [SugarColumn(ColumnDescription = "父节点ID")]
    public long? ParentId { get; set; }

    /// <summary>
    /// 深度（第几层深度）
    /// </summary>
    [SugarColumn(ColumnDescription = "深度（第几层深度）")]
    public short? Depth { get; set; }

    /// <summary>
    /// 路径（除自已外的路径）
    /// </summary>
    [SugarColumn(ColumnDescription = "路径（除自已外的路径）")]
    public string? Path { get; set; }

    /// <summary>
    /// 左值
    /// </summary>
    [SugarColumn(ColumnDescription = "左值", Length = 255)]
    public string? Lft { get; set; }

    /// <summary>
    /// 右值
    /// </summary>
    [SugarColumn(ColumnDescription = "右值", Length = 255)]
    public string? Rgt { get; set; }
}
