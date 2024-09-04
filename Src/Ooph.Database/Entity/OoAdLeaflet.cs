using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 广告 宣传
/// </summary>
[SugarTable("oo_ad_leaflet", "广告 宣传")]
public partial class OoAdLeaflet : EntityTenant
{
    /// <summary>
    /// 语言
    /// </summary>
    [SugarColumn(ColumnDescription = "语言", Length = 255)]
    public string? Langs { get; set; }

    /// <summary>
    /// 宣传名称
    /// </summary>
    [SugarColumn(ColumnDescription = "宣传名称", Length = 255)]
    public string? Name { get; set; }

    /// <summary>
    /// 宣传类型
    /// </summary>
    [SugarColumn(ColumnDescription = "宣传类型", ColumnDataType = "enum('大厅弹窗','大厅Banner','加载页轮播','个人中心')")]
    public string? LeafletType { get; set; }

    /// <summary>
    /// 展示开始时间
    /// </summary>
    [SugarColumn(ColumnDescription = "展示开始时间")]
    public DateTime? DisplayStartTime { get; set; }

    /// <summary>
    /// 展示结束时间
    /// </summary>
    [SugarColumn(ColumnDescription = "展示结束时间")]
    public DateTime? DisplayEndTime { get; set; }

    /// <summary>
    /// 收件人（全部会员【AllUser】、自定义会员【Members:user1;user2;...;user3;】、会员等级【Viplevel:vip1;vip2;vip5;】）
    /// </summary>
    [SugarColumn(ColumnDescription = "收件人", Length = 255)]
    public string? Receiver { get; set; }

    /// <summary>
    /// 主题样式（HTML富文本:&apos;HtmlRichText&apos;,图片:&apos;Image&apos;,纯文本:&apos;PreText&apos;,视频:&apos;Video&apos;,Md文本:&apos;MarkdownText&apos;）
    /// </summary>
    [SugarColumn(ColumnDescription = "主题样式", ColumnDataType = "enum('HtmlRichText','Image','PreText','Video','MarkdownText')")]
    public string? Theme { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [SugarColumn(ColumnDescription = "内容", ColumnDataType = StaticConfig.CodeFirst_BigString)]
    public string? Content { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", ColumnDataType = "enum('待发布','已取消','生效中','已过期')")]
    public string? Status { get; set; }

}
