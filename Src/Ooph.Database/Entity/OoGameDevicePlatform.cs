using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 设备平台（可能这个表不需要）
/// </summary>
[SugarTable("oo_game_device_platform", "设备平台")]
public partial class OoGameDevicePlatform : EntityTenant
{
    [SugarColumn(Length = 7)]
    public string? DevicePlatformName { get; set; }

    [SugarColumn(Length = 10)]
    public string? DevicePlatformDescription { get; set; }
}
