using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

[SugarTable("oo_game_lang")]
public partial class OoGameLang : EntityTenant
{
    /// <summary>
    /// 游戏ID
    /// </summary>
    public long? GameId { get; set; }

    /// <summary>
    /// 语言
    /// </summary>
    [SugarColumn(Length = 10)]
    public string? Lang { get; set; }


    /// <summary>
    /// 游戏名称（中文，如果不支持中文则英文）
    /// </summary>
    [SugarColumn(Length = 255)]
    public string? GameName { get; set; }
}
