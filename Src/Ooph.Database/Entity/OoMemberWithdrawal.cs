using Admin.NET.Core;
using Ooph.Database.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

[SugarTable("oo_member_withdrawal")]
public partial class OoMemberWithdrawal : EntityTenant
{
    /// <summary>
    /// 接收账号（如：数字钱包地址、银行卡号、发卡银行、开户行地区、三方钱包地址）
    /// 如：
    /// {&quot;TrxTrc20Address&quot;:&quot;Txasfdwqerqwreasdfwer&quot;}
    /// {&quot;UsdtTrc20Address&quot;:&quot;Txasfdwqerqwreasdfwer&quot;}
    /// {&quot;UsdtErc20Address&quot;:&quot;Txasfdwqerqwreasdfwer&quot;}
    /// {&quot;BankCardNo&quot;:&quot;123654789654&quot;,&quot;BankName&quot;:&quot;ABCD 银行&quot;,&quot;UName&quot;:&quot;test name&quot;,&quot;BankRegion&quot;:&quot;test address&quot;}
    /// {&quot;OkPayAddress&quot;:&quot;Txasfdwqerqwreasdfwer&quot;}
    /// </summary>
    [SugarColumn(ColumnDescription = "接收账号（如：数字钱包地址、银行卡号、发卡银行、开户行地区、三方钱包地址）", ColumnDataType = "json", IsJson = true, SqlParameterDbType = typeof(JsonDynamicConverter))]
    public dynamic? ReceiveAccount { get; set; }
}
