// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Furion.RemoteRequest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game.GameCQ9;

public interface IHttpCQ9HDP : IHttpDispatchProxy
{
    // 全局拦截，类中每一个方法都会触发
    [Interceptor(InterceptorTypes.Request)]
    static void OnRequesting1(HttpClient client, HttpRequestMessage req)
    {
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyaWQiOiI2Njk4ZGQ3MGJiYWIyNDM3MGE5MTE5MzciLCJhY2NvdW50IjoiZnlnYW1lIiwib3duZXIiOiI2Njk4ZGQ3MGJiYWIyNDM3MGE5MTE5MzciLCJwYXJlbnQiOiJzZWxmIiwiY3VycmVuY3kiOiJVU0QiLCJicmFuZCI6ImNxOSIsImp0aSI6IjEzMjkxMzM2NiIsImlhdCI6MTcyMTI5NDE5MiwiaXNzIjoiQ3lwcmVzcyIsInN1YiI6IlNTVG9rZW4ifQ.fqg0R33oCtOWwp6D6UBrT6H8gAzdxpF9vuB31hHDQws";
        req.Headers.Remove("Authorization");
        req.Headers.Add("Authorization", token);

        var reqJson = req.Content?.ReadAsStringAsync().Result;
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
