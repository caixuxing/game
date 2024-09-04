using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 会员联系方式
/// </summary>
[SugarTable("oo_member_contactinfo", "会员联系方式")]
public partial class OoMemberContactinfo : EntityTenant
{
    /// <summary>
    /// 邮箱
    /// </summary>
    [SugarColumn(ColumnDescription = "邮箱", Length = 100)]
    public string? Email { get; set; }

    /// <summary>
    /// Phone
    /// </summary>
    [SugarColumn(ColumnDescription = "Phone", Length = 100)]
    public string? Phone { get; set; }

    /// <summary>
    /// 微信
    /// </summary>
    [SugarColumn(ColumnDescription = "微信", Length = 100)]
    public string? Wechat { get; set; }

    /// <summary>
    /// Telegram
    /// </summary>
    [SugarColumn(ColumnDescription = "Telegram", Length = 100)]
    public string? Telegram { get; set; }

    /// <summary>
    /// Facebook
    /// </summary>
    [SugarColumn(ColumnDescription = "Facebook", Length = 100)]
    public string? Facebook { get; set; }

    /// <summary>
    /// Line
    /// </summary>
    [SugarColumn(ColumnDescription = "Line", Length = 100)]
    public string? Line { get; set; }

    /// <summary>
    /// Twitter
    /// </summary>
    [SugarColumn(ColumnDescription = "Twitter", Length = 100)]
    public string? Twitter { get; set; }

    /// <summary>
    /// Whatsapp
    /// </summary>
    [SugarColumn(ColumnDescription = "Whatsapp", Length = 100)]
    public string? Whatsapp { get; set; }

    /// <summary>
    /// CPF
    /// </summary>
    [SugarColumn(ColumnDescription = "CPF", Length = 100, ColumnName = "CPF")]
    public string? Cpf { get; set; }

    /// <summary>
    /// Zalo
    /// </summary>
    [SugarColumn(ColumnDescription = "Zalo", Length = 100)]
    public string? Zalo { get; set; }
}
