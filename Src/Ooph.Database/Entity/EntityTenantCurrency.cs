// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using SqlSugar.DbConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBT = SqlSugar.OrderByType;

namespace Ooph.Database.Entity;


/// <summary>
/// 租户币种实体基类
/// </summary>
[SugarIndex("index_{table}_tenantid", nameof(TenantId), OBT.Asc)]
[SugarIndex("index_{table}_C", nameof(Currency), OBT.Asc)]
[SugarIndex("index_{table}_TC", [nameof(TenantId), nameof(Currency)], [OBT.Asc, OBT.Asc])]
public abstract class EntityTenantCurrency : EntityTenant
{
    /// <summary>
    /// 币种
    /// </summary>
    [SugarColumn(ColumnDescription = "币种", IsOnlyIgnoreUpdate = true, ColumnDataType = "varchar(15)", SqlParameterDbType = typeof(EnumToStringConvert))]
    public virtual CurrencyTypeEnum? Currency { get; set; }
}

public interface IMultipleLang
{
    /// <summary>
    /// 租户Id
    /// </summary>
    string Lang { get; set; }
}

/// <summary>
/// 租户多语言实体基类
/// </summary>
public abstract class EntityTenantLang : EntityTenant, IMultipleLang
{
    /// <summary>
    /// 语言
    /// </summary>
    [SugarColumn(ColumnDescription = "语言", Length = 10, IsOnlyIgnoreUpdate = true)]
    public virtual string Lang { get; set; } = null!;
}