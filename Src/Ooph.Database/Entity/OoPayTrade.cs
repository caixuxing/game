using Admin.NET.Core;
using Ooph.Database.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 支付订单
/// </summary>
[SugarTable("oo_pay_trade", "支付订单")]
public partial class OoPayTrade : EntityTenant
{
    /// <summary>
    /// 订单号
    /// </summary>
    [SugarColumn(ColumnDescription = "订单号", Length = 255)]
    public string? PayPlatformId { get; set; }

    /// <summary>
    /// 机器码或小程序上手机号
    /// </summary>
    [SugarColumn(ColumnDescription = "机器码或小程序上手机号")]
    public long? DeviceId { get; set; }

    /// <summary>
    /// 支付订单号（Self）
    /// </summary>
    [SugarColumn(ColumnDescription = "支付订单号（Self）", Length = 50)]
    public string? PayNo { get; set; }

    /// <summary>
    /// 发起支付时间
    /// </summary>
    [SugarColumn(ColumnDescription = "发起支付时间")]
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// 支付时间
    /// </summary>
    [SugarColumn(ColumnDescription = "支付时间")]
    public DateTime? PayTime { get; set; }

    /// <summary>
    /// 支付金额
    /// </summary>
    [SugarColumn(ColumnDescription = "支付金额", ColumnDataType = "decimal(18, 4)")]
    public decimal? TotalAmount { get; set; }

    /// <summary>
    /// 支付平台订单号
    /// </summary>
    [SugarColumn(ColumnDescription = "支付平台订单号", Length = 50)]
    public string? TradeNo { get; set; }

    /// <summary>
    /// 是否已支付成功
    /// </summary>
    [SugarColumn(ColumnDescription = "是否已支付成功",ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsPaySuccess { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", ColumnDataType = "text")]
    public string? Remark { get; set; }

    public long? Ver { get; set; }

    /// <summary>
    /// 附加信息 Json字符串
    /// </summary>
    [SugarColumn(ColumnDescription = "附加信息 Json字符串", ColumnDataType = "json", IsJson = true, SqlParameterDbType = typeof(JsonDynamicConverter))]
    public string? Attach { get; set; }

    /// <summary>
    /// 后台自己备注
    /// </summary>
    [SugarColumn(ColumnDescription = "后台自己备注", ColumnDataType = "text")]
    public string? SelfRemark { get; set; }

    /// <summary>
    /// 是否处理
    /// </summary>
    [SugarColumn(ColumnDescription = "是否处理", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsHandle { get; set; }
}
