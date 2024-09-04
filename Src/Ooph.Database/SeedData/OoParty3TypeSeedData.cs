// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Core;
using Ooph.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.Database.SeedData;

/// <summary>
/// 
/// </summary>
public class OoParty3TypeSeedData : ISqlSugarEntitySeedData<OoParty3Type>
{

    public IEnumerable<OoParty3Type> HasData()
    {
        return new[]
        {
            new OoParty3Type { Id = 110001, TypeKey = "Part3Game",TypeName = "三方游戏",Description = null,Sort = 1000,IsCanEditer = false,IsShowed = false, },
            new OoParty3Type { Id = 110002, TypeKey = "OnlinePay",TypeName = "在线支付",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
            new OoParty3Type { Id = 110003, TypeKey = "OnlineKeFu",TypeName = "在线客服",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
            new OoParty3Type { Id = 110004, TypeKey = "OnlineTa",TypeName = "在线统计",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
            new OoParty3Type { Id = 110005, TypeKey = "MsgPush",TypeName = "消息推送",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
            new OoParty3Type { Id = 110006, TypeKey = "MsgNotice",TypeName = "消息通知",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
            new OoParty3Type { Id = 110007, TypeKey = "PartyLogin",TypeName = "三方登录",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
            new OoParty3Type { Id = 110008, TypeKey = "EmailNotice",TypeName = "邮箱通知",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
            new OoParty3Type { Id = 110009, TypeKey = "VCoinTransferPay",TypeName = "虚拟币转账",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
            new OoParty3Type { Id = 110010,  TypeKey = "CurrencyRateSyncSet",TypeName="币种汇率同步设置",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
            new OoParty3Type { Id = 110011,  TypeKey = "Sms",TypeName="短信",Description = null,Sort = 1000,IsCanEditer = true,IsShowed = true, },
        };
    }
}