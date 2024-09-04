using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 广告 跑马灯
/// </summary>
[SugarTable("oo_ad_hall_marquee", "广告 跑马灯")]
public partial class OoAdHallMarquee : EntityTenant
{
    [SugarColumn(Length = 255)]
    public string? Langs { get; set; }

    [SugarColumn(Length = 255)]
    public string? Content { get; set; }


    public DateTime? StartTime { get; set; }


    public DateTime? EndTime { get; set; }

    public int? SleepSeconds { get; set; }

    [SugarColumn(ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsEnabled { get; set; }

    [SugarColumn(DefaultValue = "1000")]
    public int Sort { get; set; } = 1000;
}
