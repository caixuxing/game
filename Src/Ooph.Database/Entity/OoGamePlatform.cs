using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 游戏平台
/// </summary>
[SugarTable("oo_game_platform", "游戏平台")]
[SugarIndex("index_{table}_PCode", nameof(PlatformCode), OrderByType.Asc, IsUnique = true)]
public partial class OoGamePlatform : EntityBase
{
    /// <summary>
    /// 平台代码
    /// </summary>
    [SugarColumn(ColumnDescription = "平台代码", Length = 10)]
    [DbLang("DB.Ogp.GamePlatformName","")]
    public string? PlatformCode { get; set; }

    /// <summary>
    /// 游戏平台名称（中文，如果不支持中文则英文）
    /// </summary>
    [SugarColumn(ColumnDescription = "游戏平台名称", Length = 50)]
    public string? GamePlatformName { get; set; }

    /// <summary>
    /// 默认图片地址（相对或绝对地址）如果所属语言图片不存在则使用默认图片
    /// </summary>
    [SugarColumn(ColumnDescription = "默认图片地址（相对或绝对地址）如果所属语言图片不存在则使用默认图片", Length = 255)]
    public string? DefaultImage { get; set; }
}
