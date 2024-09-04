using Admin.NET.Core;
using Ooph.Database.Enum;
using Ooph.Database.TypeConverters;
using SqlSugar.DbConvert;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OBT = SqlSugar.OrderByType;

namespace Ooph.Database.Entity;

/// <summary>
/// 三方凭证类型(全局)
/// </summary>
[SugarTable("oo_party3_voucher", "三方凭证类型(全局)")]
[SugarIndex("index_{table}_TK_VK", [nameof(TypeKey), nameof(VoucherKey)], [OBT.Asc, OBT.Asc], isUnique: true)]
public partial class OoParty3Voucher : EntityBase
{
    /// <summary>
    /// 配置类型
    /// </summary>
    [SugarColumn(ColumnDescription = "配置类型", ColumnDataType = "varchar(15)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public ConfigTypeEnum Type { get; set; }

    /// <summary>
    /// 类型Key
    /// </summary>
    [SugarColumn(ColumnDescription = "类型Key", Length = 20, IsOnlyIgnoreUpdate = true)]
    public string? TypeKey { get; set; }

    /// <summary>
    /// 凭证Key
    /// </summary>
    [SugarColumn(ColumnDescription = "凭证Key", Length = 255, IsOnlyIgnoreUpdate = true)]
    public string VoucherKey { get; set; } = null!;

    /// <summary>
    /// 凭证名称
    /// </summary>
    [SugarColumn(ColumnDescription = "凭证名称", Length = 255)]
    public string? Name { get; set; }

    /// <summary>
    /// 凭证JSON 全局级别的凭证信息（不可编辑，不可显示）
    /// </summary>
    [SugarColumn(ColumnDescription = "全局级别的凭证信息（不可编辑，不可显示）", ColumnDataType = "json", IsJson = true, SqlParameterDbType = typeof(JsonDynamicConverter))]
    public dynamic? GloballyVoucher { get; set; }

    /// <summary>
    /// 简单描述
    /// </summary>
    [SugarColumn(ColumnDescription = "简单描述", Length = 255)]
    public string? Description { get; set; }

    /// <summary>
    /// 接口帮助
    /// </summary>
    [SugarColumn(ColumnDescription = "接口帮助", Length = 255)]
    public string? Help { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", ColumnDataType = "text")]
    public string? Remark { get; set; }

    /// <summary>
    /// 表单架构Json
    /// </summary>
    [SugarColumn(ColumnDescription = "表单架构Json", ColumnDataType = "json", IsJson = true, SqlParameterDbType = typeof(JsonDynamicConverter))]
    public dynamic? FormSchemaJson { get; set; }

    /// <summary>
    /// 总后台 是否可以编辑
    /// </summary>
    [SugarColumn(ColumnDescription = "总后台 是否可以编辑", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsCanEditer { get; set; }

    /// <summary>
    /// 是否有详情
    /// </summary>
    [SugarColumn(ColumnDescription = "是否有详情", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool HasDetail { get; set; }

    /// <summary>
    /// 详情 是否可以编辑
    /// </summary>
    [SugarColumn(ColumnDescription = "详情 是否可以编辑", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool DetailIsCanEditer { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序", DefaultValue = "1000")]
    public int Sort { get; set; } = 1000;

    /// <summary>
    /// 是否多个详情
    /// </summary>
    [SugarColumn(ColumnDescription = "是否多个详情", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsMultipleDetails { get; set; }

    /// <summary>
    /// 是否在租户后台显示
    /// </summary>
    [SugarColumn(ColumnDescription = "是否在租户后台显示", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool TenantIsShowed { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(ColumnDescription = "是否启用", ColumnDataType = "bit(1)", DefaultValue = "1")]
    public bool IsEnabled { get; set; }
}
