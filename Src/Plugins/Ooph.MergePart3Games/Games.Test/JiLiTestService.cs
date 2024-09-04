// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Furion.RemoteRequest.Extensions;
using System.Transactions;
using Ooph.MergePart3Game.GameJiLi;
using Furion.RemoteRequest;
using Ooph.MergePart3Game.GameJiLi.Models;

namespace Ooph.MergePart3Game.GameJiLi;


/// <summary>
/// 系统动态插件服务 🧩
/// </summary>
[ApiDescriptionSettings(Order = 245, Groups = new[] { "[吉利]" })]
[AllowAnonymous]
public class JiLiTestService : IDynamicApiController, ITransient
{
    //private readonly SqlSugarRepository<SysPlugin> _sysPluginRep;
    //private readonly SqlSugarRepository<SysPlugin> _sysPluginRep;
    private readonly SignRequestBody _requestBodySign;
    private readonly IHttpJiLiApi _httpJiLiApi;

    public JiLiTestService(
        //SqlSugarRepository<SysPlugin> sysPluginRep
        SignRequestBody requestBodySign,
        IHttpJiLiApi httpJiLiApi
        )
    {
        _requestBodySign = requestBodySign;
        _httpJiLiApi = httpJiLiApi;
        //_sysPluginRep = sysPluginRep;
    }

    [HttpPost]
    public async Task<object> JiLiTest()
    {
        //var res = await _httpJiLiApi.LoginWithoutRedirectAsync(new Ooph.MergePart3Game.GameJiLi.IHttpApi.Models.LoginWithoutRedirectInput
        //{
        //    Account = "hh123456888",
        //    GameId = 1,
        //    Lang = "zh-CN"
        //});
        var res = await _httpJiLiApi.GetGameListAsync(new GetGameListInput
        {

        });
        return res;

        //var path = "/GetGameList";
        //var dic = new Dictionary<string, object> {
        //    //{ "Account", "test0123" },
        //    //{ "GameId", "1" },
        //    //{ "Lang", "zh-CN" },

        //};
        //var agentId = "fygming_CNY";
        //var agentKey = "fa7cd7663b99a45be467d23b08fbe05d2fe0a4ef";

        //var key = "";//_requestBodySign.Sign(path,dic, agentId, agentKey);

        //dic.Add("AgentId", agentId);
        //dic.Add("Key", key);

        //var url = $"{BaseUrl}{path}";

        //return await url
        //    .SetBody(dic, "application/x-www-form-urlencoded")
        //    .PostAsStringAsync();
    }

    [HttpPost]
    public async Task<LoginWithoutRedirectOutput> LoginWithoutRedirectAsync(LoginWithoutRedirectInput input)
    {
        var res = new LoginWithoutRedirectOutput();
        res = await _httpJiLiApi.LoginWithoutRedirectAsync(new LoginWithoutRedirectInput
        {
            Account = "abcd123",
            GameId = 1,
            Lang = "zh-CN"
        });
        return res;
    }

    [HttpPost]
    public async Task<CreateMemberOutput> CreateMemberAsync(CreateMemberInput input)
    {
        var res = new CreateMemberOutput();
        res = await _httpJiLiApi.CreateMemberAsync(new CreateMemberInput
        {
            Account = "abcd123"
        });
        return res;
    }

    [HttpPost]
    public async Task<KickMemberOutput> KickMemberAsync(KickMemberInput input)
    {
        var res = new KickMemberOutput();
        res = await _httpJiLiApi.KickMemberAsync(new KickMemberInput
        {
            Account = "abcd123"
        });
        return res;
    }

    [HttpPost]
    public async Task<KickMemberAllOutput> KickMemberAllAsync(KickMemberAllInput input)
    {
        var res = new KickMemberAllOutput();
        res = await _httpJiLiApi.KickMemberAllAsync(new KickMemberAllInput
        {
            GameId = 1,
        });
        return res;
    }

    [HttpPost]
    public async Task<GetMemberInfoOutput> GetMemberInfoAsync(GetMemberInfoInput input)
    {
        var res = new GetMemberInfoOutput();
        res = await _httpJiLiApi.GetMemberInfoAsync(new GetMemberInfoInput
        {
            Accounts = "abcd123,hh123456888"
        });
        return res;
    }

    [HttpPost]
    public async Task<GetOnlineMemberOutput> GetOnlineMemberAsync(GetOnlineMemberInput input)
    {
        var res = new GetOnlineMemberOutput();
        res = await _httpJiLiApi.GetOnlineMemberAsync(new GetOnlineMemberInput
        {

        });
        return res;
    }

    [HttpPost]
    public async Task<CheckTransferByTransactionIdOutput> CheckTransferByTransactionIdAsync(CheckTransferByTransactionIdInput input)
    {
        var res = new CheckTransferByTransactionIdOutput();
        res = await _httpJiLiApi.CheckTransferByTransactionIdAsync(new CheckTransferByTransactionIdInput
        {
            TransactionId = ""
        });
        return res;
    }

    [HttpPost]
    public async Task<GetTransferRecordByTimeOutput> GetTransferRecordByTimeAsync(GetTransferRecordByTimeInput input)
    {
        var res = new GetTransferRecordByTimeOutput();
        res = await _httpJiLiApi.GetTransferRecordByTimeAsync(new GetTransferRecordByTimeInput
        {
            Account = "hh123456888",
            EndTime = DateTime.UtcNow,
            StartTime = DateTime.UtcNow,
            Page = 1,
            PageLimit = 10
        });
        return res;
    }

    [HttpPost]
    public async Task<GetBetRecordByTimeOutput> GetBetRecordByTimeAsync(GetBetRecordByTimeInput input)
    {
        var res = new GetBetRecordByTimeOutput();
        res = await _httpJiLiApi.GetBetRecordByTimeAsync(new GetBetRecordByTimeInput
        {
            EndTime = DateTime.UtcNow,
            StartTime = DateTime.UtcNow,
            PageLimit = 1000,
            Page = 1,
            GameId = 1,
            FilterAgent = 1

        });
        return res;
    }
    [HttpPost]
    public async Task<GetGameListOutput> GetGameListAsync(GetGameListInput input)
    {
        var res = new GetGameListOutput();
        res = await _httpJiLiApi.GetGameListAsync(new GetGameListInput
        {

        });
        return res;
    }

    [HttpPost]
    public async Task<GetGameDetailUrlOutput> GetGameDetailUrlAsync(GetGameDetailUrlInput input)
    {
        var res = new GetGameDetailUrlOutput();
        res = await _httpJiLiApi.GetGameDetailUrlAsync(new GetGameDetailUrlInput
        {
            WagersId = 154545,
        });
        return res;
    }

    [HttpPost]
    public async Task<ExchangeTransferByAgentIdOutput> ExchangeTransferByAgentIdAsync(ExchangeTransferByAgentIdInput input)
    {
        var res = new ExchangeTransferByAgentIdOutput();
        res = await _httpJiLiApi.ExchangeTransferByAgentIdAsync(new ExchangeTransferByAgentIdInput
        {
            Account = "abcd123",
            Amount = 1000,
            TransactionId = new Guid().ToString(),
            TransferType = 3
        });
        return res;
    }

    [HttpPost]
    public async Task<GetMustHitByOutput> GetMustHitByAsync(GetMustHitByInput input)
    {
        var res = new GetMustHitByOutput();
        res = await _httpJiLiApi.GetMustHitByAsync(new GetMustHitByInput
        {
            GameId = 1,
        });
        return res;
    }

    [HttpPost]
    public async Task<GetUserBetRecordByTimeOutput> GetUserBetRecordByTimeAsync(GetUserBetRecordByTimeInput input)
    {
        var res = new GetUserBetRecordByTimeOutput();
        res = await _httpJiLiApi.GetUserBetRecordByTimeAsync(new GetUserBetRecordByTimeInput
        {
            Account = "abcd123",
            GameId = 1,
            EndTime = DateTime.UtcNow,
            GameType = 1,
            Page = 1,
            StartTime = DateTime.UtcNow,
            PageLimit = 1000
        });
        return res;
    }

    [HttpPost]
    public async Task<CreateFreeSpinOutput> CreateFreeSpinAsync(CreateFreeSpinInput input)
    {
        var res = new CreateFreeSpinOutput();
        res = await _httpJiLiApi.CreateFreeSpinAsync(new CreateFreeSpinInput
        {
            Account = "abcd123",
            StartTime = DateTime.UtcNow,
            BetValue = 1,
            Currency = "",
            FreeSpinValidity = DateTime.UtcNow.AddHours(1),
            GameIds = "1",
            NumberOfRounds = 1,
            ReferenceId = "1",
        });
        return res;
    }

    [HttpPost]
    public async Task<GetFreeSpinRecordSummaryOutput> GetFreeSpinRecordSummaryAsync(GetFreeSpinRecordSummaryInput input)
    {
        var res = new GetFreeSpinRecordSummaryOutput();
        res = await _httpJiLiApi.GetFreeSpinRecordSummaryAsync(new GetFreeSpinRecordSummaryInput
        {
            Currency = "",
            EndTime = DateTime.UtcNow.AddHours(1),
            StartTime = DateTime.UtcNow,
            FilterAgent = true,
        });
        return res;
    }

    [HttpPost]
    public async Task<GetFreeSpinSendDetailOutput> GetFreeSpinSendDetailAsync(GetFreeSpinSendDetailInput input)
    {
        var res = new GetFreeSpinSendDetailOutput();
        res = await _httpJiLiApi.GetFreeSpinSendDetailAsync(new GetFreeSpinSendDetailInput
        {
            EndTime = DateTime.UtcNow.AddHours(1),
            FilterAgent = true,
            StartTime = DateTime.UtcNow,
        });
        return res;
    }

    [HttpPost]
    public async Task<GetFreeSpinRecordByTimeOutput> GetFreeSpinRecordByTimeAsync(GetFreeSpinRecordByTimeInput input)
    {
        var res = new GetFreeSpinRecordByTimeOutput();
        res = await _httpJiLiApi.GetFreeSpinRecordByTimeAsync(new GetFreeSpinRecordByTimeInput
        {
            EndTime = DateTime.UtcNow.AddHours(1),
            StartTime = DateTime.UtcNow,
            FilterAgent = 1,
            GameId = 1,
            Page = 1,
            PageLimit = 1000
        });
        return res;
    }

    [HttpPost]
    public async Task<GetFreeSpinDashflowOutput> GetFreeSpinDashflowAsync(GetFreeSpinDashflowInput input)
    {
        var res = new GetFreeSpinDashflowOutput();
        res = await _httpJiLiApi.GetFreeSpinDashflowAsync(new GetFreeSpinDashflowInput
        {
            UpdateTime = DateTime.UtcNow,
        });
        return res;
    }

    [HttpPost]
    public async Task<GetFreeSpinRecordByReferenceIDOutput> GetFreeSpinRecordByReferenceIDAsync(GetFreeSpinRecordByReferenceIDInput input)
    {
        var res = new GetFreeSpinRecordByReferenceIDOutput();
        res = await _httpJiLiApi.GetFreeSpinRecordByReferenceIDAsync(new GetFreeSpinRecordByReferenceIDInput
        {
            ReferenceId = "1",
        });
        return res;
    }

    [HttpPost]
    public async Task<CancelFreeSpinOutput> CancelFreeSpinAsync(CancelFreeSpinInput input)
    {
        var res = new CancelFreeSpinOutput();
        res = await _httpJiLiApi.CancelFreeSpinAsync(new CancelFreeSpinInput
        {
            ReferenceId = "1",
        });
        return res;
    }

    [HttpPost]
    public async Task<CancelFreeSpinByAccountOutput> CancelFreeSpinByAccountAsync(CancelFreeSpinByAccountInput input)
    {
        var res = new CancelFreeSpinByAccountOutput();
        res = await _httpJiLiApi.CancelFreeSpinByAccountAsync(new CancelFreeSpinByAccountInput
        {
            Account = "abcd123",
        });
        return res;
    }

    [HttpPost]
    public async Task<CreateFreeSpinForManyOutput> CreateFreeSpinForManyAsync(CreateFreeSpinForManyInput input)
    {
        var res = new CreateFreeSpinForManyOutput();
        res = await _httpJiLiApi.CreateFreeSpinForManyAsync(new CreateFreeSpinForManyInput
        {
            Accounts = "abcd123",
            StartTime = DateTime.UtcNow,
            BetValue = 1,
            Currency = "",
            FreeSpinValidity = DateTime.UtcNow.AddHours(1),
            GameIds = "1",
            NumberOfRounds = 1,
            ReferenceIds = "1",

        });
        return res;
    }
}