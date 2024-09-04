using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 代理模式
/// </summary>
[SugarTable("oo_agent_model", "代理模式")]
public partial class OoAgentModel : EntityTenant
{
    /// <summary>
    /// 模式名称
    /// </summary>
    [SugarColumn(ColumnDescription = "模式名称", Length = 255)]
    public string? ModelName { get; set; }

    /// <summary>
    /// 模式来源
    /// </summary>
    [SugarColumn(ColumnDescription = "模式来源", Length = 255)]
    public string? ModelSource { get; set; }

    /// <summary>
    /// 结算周期
    /// </summary>
    [SugarColumn(ColumnDescription = "结算周期", ColumnDataType = "enum('EveryDay','Weekly','Monthly')")]
    public string? SettlementCycle { get; set; }

    /// <summary>
    /// 代理佣金计算层数
    /// </summary>
    [SugarColumn(ColumnDescription = "代理佣金计算层数", Length = 50)]
    public string? AgentKickbackCalcLayerLevelCount { get; set; }
}
