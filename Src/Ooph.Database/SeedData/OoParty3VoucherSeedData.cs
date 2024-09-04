using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace Ooph.Database.SeedData;

public class OoParty3VoucherSeedData : ISqlSugarEntitySeedData<OoParty3Voucher>
{
    public  IEnumerable<OoParty3Voucher> HasData()
    {
        return new[]
        {
            new OoParty3Voucher(){ Id = 120001,Type = ConfigTypeEnum.GlobalVouch, TypeKey = "Party3Game", VoucherKey = "CQ9",Name = "CQ9",
                FormSchemaJson = ReadJsonFile("Party3Game.CQ9"), IsCanEditer = false, HasDetail = false, IsEnabled = true, },
            new(){ Id = 120002,Type = ConfigTypeEnum.GlobalVouch, TypeKey = "Party3Game", VoucherKey = "JiLi",Name = "吉利",
                FormSchemaJson = ReadJsonFile("Party3Game.JiLi"), IsCanEditer = false, HasDetail = false, IsEnabled = true, },

            new(){ Id = 120003,Type = ConfigTypeEnum.TenantVouch, TypeKey = "OnlinePay", VoucherKey = "ETH-ERC-20",Name = "USDT",
                FormSchemaJson = null, IsCanEditer = false, HasDetail = false, IsEnabled = true, Description = "在配置表单中需设定最底和最高金额", },
            



            new(){ Id = 120004,Type = ConfigTypeEnum.TenantVouch, TypeKey = "OnlineKeFu", VoucherKey = "cskefu",Name = "春松客服，开源客服系统",
                FormSchemaJson = null, IsCanEditer = false, HasDetail = false, IsEnabled = false, },
            new(){ Id = 120005,Type = ConfigTypeEnum.TenantVouch, TypeKey = "OnlineKeFu", VoucherKey = "live-helper-chat",Name = "Live Helper Chat",
                FormSchemaJson = null, IsCanEditer = false, HasDetail = false, IsEnabled = false, Description = "多语言带翻译 开源在线客服，google 排第一页", Help = "https://livehelperchat.com/", Remark = "实时助手聊天\r\n它是一款开源应用程序，集简单性和易用性于一身。使用 Live Helper Chat，您可以免费为您的网站提供实时支持。http://livehelperchat.com/\r\n\r\n\r\n\r\nDocumentation - https://doc.livehelperchat.com\r\nForum/Discussions - https://github.com/LiveHelperChat/livehelperchat/discussions\r\nChat (Discord) https://discord.gg/YsZXQVh\r\nLaravel version of Live Helper Chat\r\n\r\nDemo\r\nhttp://livehelperchat.com/demo-12c.html\r\n\r\n扩展\r\nhttps://github.com/LiveHelperChat\r\n\r\n\r\n\r\nhttps://github.com/LiveHelperChat/livehelperchat/releases\r\n\r\n\r\n", },
            new(){ Id = 120006,Type = ConfigTypeEnum.TenantVouch, TypeKey = "OnlineKeFu", VoucherKey = "SW",Name = "升讯威在线客服与营销系统",
                FormSchemaJson = null, IsCanEditer = false, HasDetail = false, IsEnabled = false, Description = "多语言带翻译",Help="https://kf.shengxunwei.com/", },
            new(){ Id = 120007,Type = ConfigTypeEnum.TenantVouch, TypeKey = "OnlineKeFu", VoucherKey = "AiCan",Name = "Ai CAN 爱挚能",
                FormSchemaJson = null, IsCanEditer = false, HasDetail = false, IsEnabled = false, Description = "多语言带翻译 专业游戏行业知识库", Help = "https://aicanlive.com/price.html", },
            new(){ Id = 120008,Type = ConfigTypeEnum.TenantVouch, TypeKey = "OnlineKeFu", VoucherKey = "Go-Fly",Name = "Go-Fly",
                FormSchemaJson = null, IsCanEditer = false, HasDetail = false, IsEnabled = false, Description = "GO语言开源客服系统", Help = "https://gitee.com/wallet9527/go-fly", },

            new(){ Id = 120009,Type = ConfigTypeEnum.TenantVouch, TypeKey = "Party3Login", VoucherKey = "GoogleLogin", Name = "Google", FormSchemaJson = JsonConvert.DeserializeObject("{\"IOS\": {\"AppId\": \"\", \"AppSecret\": \"\"}, \"WebH5\": {\"AppId\": \"\", \"AppSecret\": \"\"}, \"Android\": {\"AppId\": \"\", \"AppSecret\": \"\"}}"), IsCanEditer = false, HasDetail = false, IsEnabled = false, Help = "https://www.google.com/", TenantIsShowed = true, },
            new(){ Id = 120010,Type = ConfigTypeEnum.TenantVouch, TypeKey = "Party3Login", VoucherKey = "FacebookLogin", Name = "Facebook", FormSchemaJson = JsonConvert.DeserializeObject("{\"IOS\": {\"AppId\": \"\", \"AppSecret\": \"\"}, \"WebH5\": {\"AppId\": \"\", \"AppSecret\": \"\"}, \"Android\": {\"AppId\": \"\", \"AppSecret\": \"\"}}"), IsCanEditer = false, HasDetail = false, IsEnabled = false, Help = "https://www.facebook.com/", },
            new(){ Id = 120011,Type = ConfigTypeEnum.TenantVouch, TypeKey = "Party3Login", VoucherKey = "LineLogin", Name = "Line", FormSchemaJson = JsonConvert.DeserializeObject("{\"IOS\": {\"AppId\": \"\", \"AppSecret\": \"\"}, \"WebH5\": {\"AppId\": \"\", \"AppSecret\": \"\"}, \"Android\": {\"AppId\": \"\", \"AppSecret\": \"\"}}"), IsCanEditer = false, HasDetail = false, IsEnabled = false, Help = "https://line.me/", },

            new(){ Id = 120012,Type = ConfigTypeEnum.TenantVouch, TypeKey = "EmailPush", VoucherKey = "Gmail", Name = "谷歌邮箱",
                FormSchemaJson = JsonConvert.DeserializeObject("{\"Sort\": 100, \"SmtpPort\": 53, \"IsEnabled\": true, \"IsEncrypt\": false, \"SmtpServer\": \"\", \"SmtpAccount\": \"\", \"SmtpPassword\": \"\", \"DailyCapCount\": 200}"),IsCanEditer = false, HasDetail = false, IsEnabled = true, TenantIsShowed = true, },
            new(){ Id = 120013,Type = ConfigTypeEnum.TenantVouch, TypeKey = "EmailPush", VoucherKey = "Outlook", Name = "Outlook",
                FormSchemaJson = JsonConvert.DeserializeObject("{\"Sort\": 100, \"SmtpPort\": 53, \"IsEnabled\": true, \"IsEncrypt\": false, \"SmtpServer\": \"\", \"SmtpAccount\": \"\", \"SmtpPassword\": \"\", \"DailyCapCount\": 200}"),IsCanEditer = false, HasDetail = false, IsEnabled = true, TenantIsShowed = true, },

            new() { Id = 120014,Type=ConfigTypeEnum.GlobalConfig, TypeKey = "CurrencyRateSyncSet", VoucherKey = "CurrencyRateSyncSet", Name = "币种汇率同步设置", GloballyVoucher=JsonConvert.DeserializeObject("{\"DepositsWithdrawalsSet\":2,\"UpdateType\":1,\"Frequency\":\"10\"}"),
                FormSchemaJson = ReadJsonFile("CurrencyRateSyncSet.CurrencyRateSyncSet"), IsEnabled = true, TenantIsShowed = true, },

        };
    }
    private object ReadJsonFile(string name)
    {
       string fullyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource", "FormSchemas", $"{name}.json");
        if (!File.Exists(fullyFilePath))
        {
            throw new Exception($"{nameof(OoParty3Voucher)}表FormSchema架构字段Json数据文件{fullyFilePath}不存在");
        }
        string[] lines = File.ReadAllLines(fullyFilePath, Encoding.UTF8);
        string jsonContent = string.Join("", lines.Select(line => line.Replace("\n", "")));
        JObject jsonObject = JObject.Parse(jsonContent);
        return jsonObject;
    }
}