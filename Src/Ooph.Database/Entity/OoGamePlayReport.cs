using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 游戏投注报表（按游戏和日期分）
/// </summary>
[SugarTable("oo_game_play_report", "游戏投注报表（按游戏和日期分）")]
public partial class OoGamePlayReport : EntityTenantCurrency
{
    public long? GameId { get; set; }

    /// <summary>
    /// 年月日
    /// </summary>
    [SugarColumn(ColumnDescription = "年月日")]
    public DateOnly? Date { get; set; }

    /// <summary>
    /// 游玩记录
    /// </summary>
    [SugarColumn(ColumnDescription = "游玩记录", Length = 255)]
    public string? PlayRecordCount { get; set; }
}
