using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 游戏币种
/// </summary>
[SugarTable("oo_game_currencytype", "游戏币种")]
public partial class OoGameCurrencytype : EntityTenant
{
    /// <summary>
    /// 游戏ID
    /// </summary>
    public long? GameId { get; set; }

    /// <summary>
    /// 币种名称
    /// </summary>
    [SugarColumn(ColumnDescription = "币种名称", Length = 10)]
    public string? CurrencyTypeName { get; set; }

    ///// <summary>
    ///// 币种描述
    ///// </summary>
    //[SugarColumn(ColumnDescription = "币种描述", Length = 10)]
    //public string? CurrencyTypeDescription { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnDescription = "是否启用", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsEnabled { get; set; }
}
