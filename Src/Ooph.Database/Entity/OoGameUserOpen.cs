using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 游戏打开记录，表还未设计完
/// </summary>
[SugarTable("oo_game_user_open", "游戏打开记录，表还未设计完")]
public partial class OoGameUserOpen : EntityTenantCurrency
{
    [SugarColumn(Length = 100)]
    public string UserName { get; set; } = null!;

    public long UserId { get; set; }

    [SugarColumn(Length = 100)]
    public string GamePassword { get; set; } = null!;

    [SugarColumn(Length = 20)]
    public string GameCode { get; set; } = null!;

    public long GameId { get; set; }
}
