// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Ooph.MergePart3Game.GameJiLi;

public class SignRequestBody : ISingleton
{
    /// <summary>
    ///Url签名参数字典
    /// </summary>
    private static readonly Lazy<Dictionary<List<string>, Func<NameValueCollection, string, string>>> _InitData = new(() => new() {
             {new List<string>(){ "/CreateMember","/CancelFreeSpinByAccount","/KickMember" },(data,agentId) => new { Account = data.Get("Account"), AgentId = agentId }.ObjToUriParam() },
             {new List<string>(){ "/LoginWithoutRedirect", "/Login" },(data,agentId)=>new { Account = data.Get("Account"), GameId = data.Get("GameId"), Lang = data.Get("Lang"), AgentId = agentId }.ObjToUriParam() },
             {new List<string>(){ "/CreateFreeSpinForMany" },(data,agentId)=>new{Account=data.Get("Account"),Currency=data.Get("Currency"),ReferenceIds=data.Get("ReferenceIds"), FreeSpinValidity=data.Get("FreeSpinValidity"),NumberOfRounds=data.Get("NumberOfRounds"),GameIds=data.Get("GameIds"),AgentId=agentId}.ObjToUriParam() },
             {new List<string>(){ "/CreateFreeSpin" },(data,agentId)=>new{Account=data.Get("Account"),Currency=data.Get("Currency"),ReferenceId=data.Get("ReferenceId"),FreeSpinValidity=data.Get("FreeSpinValidity"),NumberOfRounds=data.Get("NumberOfRounds"),GameIds=data.Get("GameIds"),AgentId=agentId}.ObjToUriParam() },
             {new List<string>(){ "/GetOnlineMember","/GetMustHitBy","/GetGameList" },(data,agentId)=>new{AgentId=agentId }.ObjToUriParam() },
             {new List<string>(){ "/GetMemberInfo" },(data,agentId)=>new{Accounts=data.Get("Accounts"),AgentId=agentId }.ObjToUriParam() },
             {new List<string>(){ "/CheckTransferByTransactionId" },(data,agentId)=>new{TransactionId=data.Get("TransactionId"),AgentId=agentId }.ObjToUriParam() },
             {new List<string>(){ "/ExchangeTransferByAgentId" },(data,agentId)=>new{Account=data.Get("Account"),TransactionId=data.Get("TransactionId"),Amount=data.Get("Amount"),TransferType=data.Get("TransferType"),AgentId=agentId }.ObjToUriParam() },
             {new List<string>(){ "/GetGameDetailUrl" },(data,agentId)=>new{ WagersId=data.Get("WagersId"),AgentId=agentId}.ObjToUriParam() },
             {new List<string>(){ "/GetTransferRecordByTime","/GetBetRecordByTime","/GetFreeSpinRecordByTime","/GetUserBetRecordByTime" },(data,agentId)=>new{StartTime=data.Get("StartTime"),EndTime=data.Get("EndTime"),Page=data.Get("Page"),PageLimit=data.Get("PageLimit"),AgentId=agentId }.ObjToUriParam() },
             {new List<string>(){ "/GetFreeSpinRecordSummary","/GetFreeSpinSendDetail" },(data,agentId)=>new{StartTime=data.Get("StartTime"),EndTime=data.Get("EndTime"),AgentId=agentId }.ObjToUriParam() },
             {new List<string>(){ "/GetFreeSpinDashflow" },(data,agentId)=>new{UpdateTime=data.Get("UpdateTime"),AgentId=agentId}.ObjToUriParam() },
             {new List<string>(){ "/CancelFreeSpin" },(data,agentId) =>new {ReferenceId=data.Get("ReferenceId"),AgentId=agentId }.ObjToUriParam() },
             {new List<string>(){ "/KickMemberAll" },(data,agentId) =>new {GameId=data.Get("GameId"),AgentId=agentId }.ObjToUriParam() }
    });

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public static string CalcDate()
    {
        return $"{DateTime.UtcNow.AddHours(-4):yyMMd}";
    }

    /// <summary>
    /// Md5加密
    /// </summary>
    public static string MD5(string s, string input_charset = "UTF-8")
    {
        char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
         'A', 'B', 'C', 'D', 'E', 'F' };
        try
        {
            byte[] btInput = Encoding.GetEncoding(input_charset).GetBytes(s);
            MD5 mdInst = System.Security.Cryptography.MD5.Create();
            mdInst.ComputeHash(btInput);
            if (mdInst.Hash == null) { return "mdInst.Hash is null"; }
            byte[] md = mdInst.Hash;
            int j = md.Length;
            char[] str = new char[j * 2];
            int k = 0;
            for (int i = 0; i < j; i++)
            {
                byte byte0 = md[i];
                str[k++] = hexDigits[byte0 >> 4 & 0xf];
                str[k++] = hexDigits[byte0 & 0xf];
            }
            return new string(str).ToLower();
        }
        catch (Exception ex)
        {
            return $"{ex}";
        }
    }

    /// <summary>
    /// 生成Sign签名字符串
    /// </summary>
    /// <param name="path"></param>
    /// <param name="dic"></param>
    /// <param name="agentId"></param>
    /// <param name="agentKey"></param>
    /// <returns></returns>
    public static string Sign(string path, NameValueCollection dic, string agentId, string agentKey)
    {
        var str = (_InitData.Value.SingleOrDefault(x => x.Key.Contains(path)).Value
            ?? throw new("没有找到合适的签名方法"))(dic, agentId);
        var date = CalcDate();
        var keyG_Old = $"{date}{agentId}{agentKey}";
        var keyG = MD5(keyG_Old);
        var requstBody = $"{str}{keyG}";
        var md5string = MD5(requstBody);
        var key = $"{getRandom()}{md5string}{getRandom()}";
        return key;
    }

    /// <summary>
    /// 生成随机数
    /// </summary>
    /// <returns></returns>
    private static string getRandom()
    {
        var randomNum = "";
        //生成验证码
        for (int i = 0; i < 6; i++)
        {
            if (i == 0)
            {
                randomNum += Random.Shared.Next(1, 9);
                continue;
            }
            randomNum += Random.Shared.Next(9);
        }
        return randomNum;
    }
}

/// <summary>
///
/// </summary>
public static class CustomExtend
{
    /// <summary>
    /// Obj对象转HttpUrl参数字符串
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>返回Url参数字符串</returns>
    public static string ObjToUriParam(this object obj)
    {
        var collection = HttpUtility.ParseQueryString(string.Empty);
        foreach (var property in obj.GetType().GetProperties())
        {
            var value = property.GetValue(obj)?.ToString();
            if (value is null) continue;
            collection.Add(property.Name, value);
        }
        return collection?.ToString() ?? string.Empty;
    }
}