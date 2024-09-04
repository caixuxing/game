using Newtonsoft.Json;

namespace Ooph.Database.Entity;

/// <summary>
/// 充值提现银行
/// </summary>
[SugarTable("Oo_Recharge_Withdraw_Bank", "充值提现银行")]
public class OoRechargeWithdrawBank : EntityTenant
{
    /// <summary>
    /// 币种ID
    /// </summary>
    [SugarColumn(ColumnDescription = "币种ID")]
    public long CurrencyTypeId { get; set; }


    /// <summary>
    /// 游戏币种
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    [Navigate(NavigateType.OneToOne, nameof(CurrencyTypeId))]
    [JsonIgnore]
    public OoGameCurrencytype? GameCurrencytype { get; set; }


    /// <summary>
    /// 银行ID
    /// </summary>
    [SugarColumn(ColumnDescription = "银行ID")]
    public long BankId { get; set; }

    /// <summary>
    /// 前台显示名称
    /// </summary>
    [SugarColumn(ColumnDescription = "前台显示名称", Length = 50)]
    public string? FrontendName { get; set; }

    /// <summary>
    /// 银行图标
    /// </summary>
    [SugarColumn(ColumnDescription = "银行图标", Length = 255)]
    public string? Icon { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态")]
    public StatusEnum Status { get; set; }=StatusEnum.Enable;
}