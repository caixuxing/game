using Admin.NET.Core;
using SqlSugar.DbConvert;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// VIP奖励
/// </summary>
[SugarTable("oo_vip_bound", "VIP奖励")]
public partial class OoVipBound : EntityTenant
{
    /// <summary>
    /// VIP等级Id
    /// </summary>
    [SugarColumn(ColumnDescription = "VIP等级Id")]
    public long MemberVipId { get; set; }

    /// <summary>
    /// 俸禄类型
    /// </summary>
    [SugarColumn(ColumnDescription = "俸禄类型", ColumnDataType = "varchar(15)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public SalaryTypeEnum SalaryType {  get; set; }


    /// <summary>
    /// 充值
    /// </summary>
    [SugarColumn(ColumnDescription = "充值", ColumnDataType = "decimal(18, 4)")]
    public decimal? Retopup { get; set; }

    /// <summary>
    /// 打码
    /// </summary>
    [SugarColumn(ColumnDescription = "打码", ColumnDataType = "decimal(18, 4)")]
    public decimal? Coding { get; set; }

    /// <summary>
    /// 俸禄
    /// </summary>
    [SugarColumn(ColumnDescription = "俸禄", ColumnDataType = "decimal(18, 4)")]
    public decimal? Salary { get; set; }

    /// <summary>
    /// 累计封顶
    /// </summary>
    [SugarColumn(ColumnDescription = "累计封顶")]
    public short? CumulativeCap { get; set; }
}
