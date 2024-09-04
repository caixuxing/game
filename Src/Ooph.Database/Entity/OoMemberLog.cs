using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 会员日志
/// </summary>
[SugarTable("oo_member_log", "会员日志")]
public partial class OoMemberLog : EntityTenant
{
    /// <summary>
    /// 会员ID
    /// </summary>
    [SugarColumn(ColumnDescription = "会员ID")]
    public int? MemberId { get; set; }

    /// <summary>
    /// 操作类型
    /// </summary>
    [SugarColumn(ColumnDescription = "操作类型", Length = 20)]
    public string? OperaterType { get; set; }

    /// <summary>
    /// 操作方法
    /// </summary>
    [SugarColumn(ColumnDescription = "内容", Length = 255)]
    public string? OperaterAction { get; set; }

    /// <summary>
    /// 旧值
    /// </summary>
    [SugarColumn(ColumnDescription = "旧值", Length = 255)]
    public string? OldVal { get; set; }

    /// <summary>
    /// 新值
    /// </summary>
    [SugarColumn(ColumnDescription = "新值", Length = 255)]
    public string? NewVal { get; set; }

    /// <summary>
    /// UserAgent
    /// </summary>
    [SugarColumn(ColumnDescription = "UserAgent", Length = 500, ColumnName = "DeviceUA")]
    public string? DeviceUA { get; set; }

    /// <summary>
    /// 设备信息
    /// </summary>
    [SugarColumn(ColumnDescription = "设备信息", Length = 255)]
    public string? DeviceInfo { get; set; }
}
