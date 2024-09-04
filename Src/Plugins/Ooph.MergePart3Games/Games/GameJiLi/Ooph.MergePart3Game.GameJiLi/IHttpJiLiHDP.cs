// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Furion.RemoteRequest;
using Newtonsoft.Json;
using Ooph.ICore.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game.GameJiLi;

public interface IHttpJiLiHDP : IHttpDispatchProxy
{
    // 全局拦截，类中每一个方法都会触发
    [Interceptor(InterceptorTypes.Request)]
    static void OnRequesting1(HttpClient client, HttpRequestMessage req)
    {
        var agentId = "fygming_CNY";
        var agentKey = "fa7cd7663b99a45be467d23b08fbe05d2fe0a4ef";
        var reqJson = req.Content?.ReadAsStringAsync().Result ?? string.Empty;


        var path = $"/{req.RequestUri}";

        var dic = System.Web.HttpUtility.ParseQueryString(reqJson);
        var key = SignRequestBody.Sign(path, dic, agentId, agentKey);
        reqJson = req.Content?.ReadAsStringAsync().Result;
        //追加更多参数
        req.Append_x_www_form_urlencodeds(new { Key = key, AgentId = agentId });

        reqJson = req.Content?.ReadAsStringAsync().Result;
    }

    // 全局拦截，类中每一个方法都会触发
    [Interceptor(InterceptorTypes.Response)]
    static void OnResponsing1(HttpClient client, HttpResponseMessage res)
    {
        var re = res.Content?.ReadAsStringAsync().Result;
    }

    // 全局拦截，类中每一个方法都会触发
    [Interceptor(InterceptorTypes.Exception)]
    static void OnException1(HttpClient client, HttpResponseMessage res, string errors)
    {

    }

}
