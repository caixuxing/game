using Admin.NET.Core;
using Ooph.Database.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 游戏投注记录
/// </summary>
[SugarTable("oo_game_play_record", "游戏投注记录")]
public partial class OoGamePlayRecord : EntityTenantCurrency
{
    public long? GameId { get; set; }

    public long? UserId { get; set; }

    [SugarColumn(Length = 255)]
    public string? TraceId { get; set; }

    public DateTime? PlayTime { get; set; }

    public DateTime? EndPlayTime { get; set; }

    /// <summary>
    /// 投注结果 json
    /// </summary>
    [SugarColumn(ColumnDescription = "投注结果 json", ColumnDataType = "json", IsJson = true, SqlParameterDbType = typeof(JsonDynamicConverter))]
    public dynamic? Details { get; set; }
}
