// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Diagnostics.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion.DependencyInjection;
using Furion.Extensions;

namespace Ooph.ICore.Extension;

/// <summary>
/// HttpRequestMessage 拓展
/// </summary>
[SuppressSniffer]
public static class HttpRequestMessageExtensions
{
    /// <summary>
    /// 追加 application/x-www-form-urlencoded 参数
    /// </summary>
    public static void Append_x_www_form_urlencodeds(this HttpRequestMessage httpRequest, IDictionary<string, object> queries, bool isEncode = true, bool ignoreNullValue = true)
    {
        if (queries == null || queries.Count == 0) return;

        // 获取原始 form-urlencoded
        var strFormUrlEncoded = httpRequest.Content?.ReadAsStringAsync().Result ?? string.Empty;

        // 拼接
        var urlParameters = ExpandQueries(queries, isEncode, ignoreNullValue);
        strFormUrlEncoded = $"{strFormUrlEncoded}{"&"}{string.Join("&", urlParameters)}";

        // 重新设置 form-urlencoded
        httpRequest.Content = new StringContent(strFormUrlEncoded, Encoding.UTF8, "application/x-www-form-urlencoded");
    }

    /// <summary>
    /// 追加 application/x-www-form-urlencoded 参数
    /// </summary>
    public static void Append_x_www_form_urlencodeds(this HttpRequestMessage httpRequest, object queries, bool isEncode = true, bool ignoreNullValue = true)
    {
        if (queries == null) return;

        var dic = Furion.ClayObject.Extensions.DictionaryExtensions.ToDictionary(queries);
        httpRequest.Append_x_www_form_urlencodeds(dic, isEncode, ignoreNullValue);
    }


    /// <summary>
    /// 展开 Url 参数
    /// </summary>
    /// <param name="queries"></param>
    /// <param name="isEncode"></param>
    /// <param name="ignoreNullValue"></param>
    /// <returns></returns>
    private static IEnumerable<string> ExpandQueries(IDictionary<string, object> queries, bool isEncode = true, bool ignoreNullValue = true)
    {
        var items = new List<string>();

        foreach (var (key, value) in queries)
        {
            // 处理忽略 null 值问题
            //if (ignoreNullValue && value == null) continue;
            if (ignoreNullValue && (value == null || $"{value}" == string.Empty)) continue;

            var paramBuilder = new StringBuilder();
            paramBuilder.Append(key);
            paramBuilder.Append('=');

            var type = value?.GetType();
            if (type == null) items.Add(paramBuilder.ToString());
            // 处理基元类型
            else if (type.IsRichPrimitive()
                && (!type.IsArray || type == typeof(string)))
            {
                paramBuilder.Append(isEncode ? Uri.EscapeDataString(value.ToString()) : value.ToString());
                items.Add(paramBuilder.ToString());
            }
            // 处理集合类型
            else if (type.IsArray
                || typeof(System.Collections.IEnumerable).IsAssignableFrom(type)
                    && type.IsGenericType && type.GenericTypeArguments.Length == 1)
            {
                var valueList = ((System.Collections.IEnumerable)value)?.Cast<object>();

                // 这里不进行递归，只处理一级
                foreach (var val in valueList)
                {
                    var childBuilder = new StringBuilder();
                    childBuilder.Append(key);
                    childBuilder.Append('=');
                    childBuilder.Append(isEncode ? Uri.EscapeDataString(val.ToString()) : val.ToString());
                    items.Add(childBuilder.ToString());
                }
            }
            else throw new InvalidOperationException("Unsupported type.");
        }

        return items;
    }

    /// <summary>
    /// 判断是否是富基元类型
    /// </summary>
    /// <param name="type">类型</param>
    /// <returns></returns>
    // Token: 0x060010DF RID: 4319 RVA: 0x0002FA78 File Offset: 0x0002DC78
    internal static bool IsRichPrimitive(this Type type)
    {
        if (type.IsValueTuple())
        {
            return false;
        }
        if (type.IsArray)
        {
            return type.GetElementType().IsRichPrimitive();
        }
        return type.IsPrimitive || type.IsValueType || type == typeof(string) || type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && type.GenericTypeArguments[0].IsRichPrimitive();
    }
}
