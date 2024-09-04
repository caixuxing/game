using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 游戏分类
/// </summary>
[SugarTable("oo_game_category_lang", "游戏分类语言")]
public partial class OoGameCategoryLang : EntityTenant
{
    /// <summary>
    /// 游戏分类ID
    /// </summary>
    [SugarColumn(IsOnlyIgnoreUpdate = true)]
    public long? GameCategoryId { get; set; }

    /// <summary>
    /// 游戏分类名称，对应语言名称
    /// </summary>
    [SugarColumn(ColumnDescription = "游戏分类名称，对应语言名称", Length = 30, IsNullable = false)]
    public string? GameCategoryName { get; set; }
}