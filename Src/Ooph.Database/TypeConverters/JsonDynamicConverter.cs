// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.Database.TypeConverters;

public class JsonDynamicConverter : ISugarDataConverter
{
    public SugarParameter ParameterConverter<T>(object value, int i)
    {
        //该功能ORM自带的IsJson就能实现这里只是用这个用例来给大家学习
        var name = "@myp" + i;
        var str = "null";
        if (value != null && value.GetType() == typeof(string))
        {
            str = $"{value}";
        }
        else
        {
            //str = new SerializeService().SerializeObject(value);
            str = JsonConvert.SerializeObject(value, NewtonsoftJsonSerializerProviderExt.Newtosoft_Json_JsonSerializerSettings);
        }

        //可以更改DbType=System.Data.DbType.XXX
        //PgSql中可以使用:CustomDbType=NpgsqlDbType.XXX;
        return new SugarParameter(name, str);
    }

    public T? QueryConverter<T>(IDataRecord dr, int i)
    {
        var str = $"{dr.GetValue(i)}".Trim();
        if (str.StartsWith("\""))
        {
            //str = new SerializeService().DeserializeObject<string>(str);
            str = JsonConvert.DeserializeObject<string>(str, NewtonsoftJsonSerializerProviderExt.Newtosoft_Json_JsonSerializerSettings);
        }
        //return new SerializeService().DeserializeObject<T>(str);
        return JsonConvert.DeserializeObject<T>(str, NewtonsoftJsonSerializerProviderExt.Newtosoft_Json_JsonSerializerSettings);
    }
}

public class NewtonsoftJsonSerializerProviderExt
{
    /// <summary>
    /// 
    /// </summary>
    public static JsonSerializerSettings Newtosoft_Json_JsonSerializerSettings { get; }
    static NewtonsoftJsonSerializerProviderExt()
    {
        var jsonSerializerSettings = new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Local,
            ContractResolver = new CamelCasePropertyNamesContractResolver(), // 首字母小写（驼峰样式）
            DateFormatString = "yyyy-MM-dd HH:mm:ss", // 时间格式化
            // options.SerializerSettings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
            // options.SerializerSettings.DateParseHandling = DateParseHandling.None;
            //StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
            StringEscapeHandling = StringEscapeHandling.Default,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore, // 忽略循环引用
            NullValueHandling = NullValueHandling.Ignore, // 忽略空值
            MaxDepth = 20, // 设置序列化的最大层数
#if DEBUG
            Formatting = Formatting.Indented,
#endif
        };

        jsonSerializerSettings.Converters.Add(new StringEnumConverter() { AllowIntegerValues = true });
        jsonSerializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss", /*DateTimeStyles = System.Globalization.DateTimeStyles.AssumeUniversal*/ });
        jsonSerializerSettings.Converters.AddLongTypeConverters(); // long转string（防止js精度溢出） 超过16位开启

        Newtosoft_Json_JsonSerializerSettings = jsonSerializerSettings;
    }
}