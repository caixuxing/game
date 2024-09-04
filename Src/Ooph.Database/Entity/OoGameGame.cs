using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

[SugarTable("oo_game_game")]
public partial class OoGameGame : EntityTenant
{
    /// <summary>
    /// 游戏平台代码
    /// </summary>
    [SugarColumn(Length = 255)]
    public string? GamePlatformCode { get; set; }

    /// <summary>
    /// 游戏分类ID
    /// </summary>
    public long? GameCategoryId { get; set; }

    /// <summary>
    /// 游戏Code
    /// </summary>
    [SugarColumn(Length = 20)]
    public string? GameCode { get; set; }

    /// <summary>
    /// 游戏名称（中文，如果不支持中文则英文）
    /// </summary>
    [SugarColumn(Length = 255)]
    public string? GameName { get; set; }
}
