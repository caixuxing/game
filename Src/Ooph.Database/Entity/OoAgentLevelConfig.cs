using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 代理等级配置
/// </summary>
[SugarTable("oo_agent_level_config", "代理等级配置")]
public partial class OoAgentLevelConfig : EntityTenant
{
    /// <summary>
    /// 图标
    /// </summary>
    [SugarColumn(ColumnDescription = "图标", Length = 255)]
    public string? Icon { get; set; }

    /// <summary>
    /// 等级名称
    /// </summary>
    [SugarColumn(ColumnDescription = "等级名称", Length = 20)]
    public string? Name { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    [SugarColumn(ColumnDescription = "显示名称", Length = 20)]
    public string? DisplayName { get; set; }

    /// <summary>
    /// 晋升条件（晋级需再获得佣金）
    /// </summary>
    [SugarColumn(ColumnDescription = "晋升条件")]
    public int? UpgradeConditions { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [SugarColumn(ColumnDescription = "描述", Length = 255)]
    public string? Description { get; set; }

}
