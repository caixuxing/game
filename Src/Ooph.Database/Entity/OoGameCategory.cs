using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 游戏分类
/// </summary>
[SugarTable("oo_game_category", "游戏分类")]
public partial class OoGameCategory : EntityTenant
{
    /// <summary>
    /// 游戏分类名称，默认中文名称
    /// </summary>
    [SugarColumn(ColumnDescription = "游戏分类名称，默认中文名称", Length = 20)]
    public string? GameCategory { get; set; }
}
