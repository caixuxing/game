using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 会员信息
/// </summary>
[SugarTable("oo_member_userinfo", "会员信息")]
public partial class OoMemberUserinfo : EntityTenantCurrency
{
    /// <summary>
    /// 币种ID
    /// </summary>
    [SugarColumn(ColumnDescription = "币种ID")]
    public long? CurrencyTypeId { get; set; }

    /// <summary>
    /// 会员用户名
    /// </summary>
    [SugarColumn(ColumnDescription = "会员用户名", Length = 20)]
    public string? MemberUserName { get; set; }

    /// <summary>
    /// 会员姓名
    /// </summary>
    [SugarColumn(ColumnDescription = "会员姓名", Length = 50)]
    public string? MemberName { get; set; }

    /// <summary>
    /// 注册来源（推广链接，直接注册，后台创建，代理创建）
    /// </summary>
    [SugarColumn(ColumnDescription = "注册来源（推广链接，直接注册，后台创建，代理创建）", Length = 50)]
    public string? RegisterSource { get; set; }

    /// <summary>
    /// 上级代理ID
    /// </summary>
    [SugarColumn(ColumnDescription = "上级代理ID")]
    public int? ParentAgentId { get; set; }

    /// <summary>
    /// 会员等级ID
    /// </summary>
    [SugarColumn(ColumnDescription = "会员等级ID")]
    public int? VipLevelId { get; set; }

    /// <summary>
    /// 会员层级
    /// </summary>
    [SugarColumn(ColumnDescription = "会员层级")]
    public int? MemberRankId { get; set; }

    /// <summary>
    /// 充值次数
    /// </summary>
    [SugarColumn(ColumnDescription = "充值次数")]
    public int? RechargeCount { get; set; }

    /// <summary>
    /// 累计充值金额
    /// </summary>
    [SugarColumn(ColumnDescription = "累计充值金额", ColumnDataType = "decimal(18, 4)")]
    public decimal? TotalRechargeAmount { get; set; }

    [SugarColumn(ColumnName = "Login2FA", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool Login2FA { get; set; }

    [SugarColumn(Length = 50, ColumnName = "Login2FASecret")]
    public string? Login2FAsecret { get; set; }

    [SugarColumn(Length = 50)]
    public string? PasswordProtectQuestion { get; set; }

    [SugarColumn(Length = 50)]
    public string? PasswordProtectAnswer { get; set; }

    [SugarColumn(ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsAgent { get; set; }
}
