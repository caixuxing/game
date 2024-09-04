using Admin.NET.Core;
using Ooph.Database.TypeConverters;

namespace Ooph.Database.Entity;

/// <summary>
/// 临时表，一般用于存取7天内可用的数据，本表只保留七天内的数据
/// </summary>
[SugarTable("oo_temp_data", "临时表，一般用于存取7天内可用的数据，本表只保留七天内的数据")]
[SugarIndex("Index_{table}_Key", nameof(TempKey), OrderByType.Asc)]
public partial class OoTempData : EntityTenant
{
    /// <summary>
    /// Key
    /// </summary>
    [SugarColumn(ColumnDescription = "标题", Length = 32)]
    public string? TempKey { get; set; }

    /// <summary>
    /// 日期
    /// </summary>
    [SugarColumn(ColumnDescription = "日期", ColumnDataType = "date", SqlParameterDbType = typeof(TypeConverters.DateOnlyConverter))]
    public DateOnly? Date { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [SugarColumn(ColumnDescription = "数据", ColumnDataType = "json", IsJson = true, SqlParameterDbType = typeof(JsonDynamicConverter))]
    public dynamic? Data { get; set; }

    /// <summary>
    /// 有效期
    /// </summary>
    [SugarColumn(ColumnDescription = "有效期", IsOnlyIgnoreUpdate = true)]
    public DateTime? ExpireTime { get; set; }
}
