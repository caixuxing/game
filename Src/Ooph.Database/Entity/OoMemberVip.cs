using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// 会员 VIP
/// </summary>
[SugarTable("oo_member_vip", "会员 VIP")]
public partial class OoMemberVip : EntityTenantCurrency
{
    /// <summary>
    /// VIP等级名称
    /// </summary>
    [SugarColumn(ColumnDescription = "VIP等级名称", Length = 50)]
    public string? VipLevelName { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    [SugarColumn(ColumnDescription = "图标", Length = 20)]
    public string? Icon { get; set; }

    /// <summary>
    /// 每日提现金额上限
    /// </summary>
    [SugarColumn(ColumnDescription = "每日提现金额上限", ColumnDataType = "decimal(10, 2)", ColumnName = "DMWA")]
    public decimal? DailyMaxWithdrawalAmount { get; set; }

    /// <summary>
    /// 每日提现次数上限
    /// </summary>
    [SugarColumn(ColumnDescription = "每日提现次数上限", ColumnName = "DWCUL")]
    public short DailyWithdrawalCountUpperLimit { get; set; }

    /// <summary>
    /// 每日免手续费笔数
    /// </summary>
    [SugarColumn(ColumnDescription = "每日免手续费笔数", ColumnName = "DWCFFC")]
    public short DailyWithdrawalCommissionFeeFreeCount { get; set; }

    /// <summary>
    /// 晋级需再充值
    /// </summary>
    [SugarColumn(ColumnDescription = "晋级需再充值", ColumnDataType = "decimal(18, 4)")]
    public decimal? RetopupRequiredPromotion { get; set; }

    /// <summary>
    /// 晋级需再打码
    /// </summary>
    [SugarColumn(ColumnDescription = "晋级需再打码", ColumnDataType = "decimal(18, 4)")]
    public decimal? CodingRequiredPromotion { get; set; }

    /// <summary>
    /// 晋级奖金
    /// </summary>
    [SugarColumn(ColumnDescription = "晋级奖金", ColumnDataType = "decimal(18, 4)")]
    public decimal? PromotionBonus { get; set; }

    /// <summary>
    /// 保级上月充值
    /// </summary>
    [SugarColumn(ColumnDescription = "保级上月充值", ColumnDataType = "decimal(18, 4)")]
    public decimal? RelegationLastMonthRetopup { get; set; }

    /// <summary>
    /// 保级上月打码
    /// </summary>
    [SugarColumn(ColumnDescription = "保级上月打码", ColumnDataType = "decimal(18, 4)")]
    public decimal? RelegationLastMonthCoding { get; set; }
}
