// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Furion.RemoteRequest.Extensions;
using System.Transactions;
using Furion.RemoteRequest;
using Ooph.MergePart3Game.GameCQ9.Models;

namespace Ooph.MergePart3Game.GameCQ9;

/// <summary>
/// 系统动态插件服务 🧩
/// </summary>
[ApiDescriptionSettings(Order = 255, Groups = new[] { "[CQ9]" })]
[AllowAnonymous]
public class CQ9TestService : IDynamicApiController, ITransient
{
    private readonly IHttpCQ9Api _httpCQ9Api;

    public CQ9TestService(
        IHttpCQ9Api httpCQ9Api
        )
    {
        _httpCQ9Api = httpCQ9Api;
    }


    [HttpPost]
    public async Task<PlayerOutput> PlayerAsync(PlayerInput input)
    {
        var res = await _httpCQ9Api.PlayerAsync(new PlayerInput
        {
            Account = "test111",
            Nickname = "test111",
            Password = "test111"
        });
        return res;
    }

    [HttpPost]
    public async Task<GameHallsOutput> GameHallsAsync(GameHallsInput input)
    {
        var res = await _httpCQ9Api.GameHallsAsync(new GameHallsInput
        {

        });
        return res;
    }

    [HttpPost]
    public async Task<PlayerLoginOutput> PlayerLoginAsync(PlayerLoginInput input)
    {
        var res = await _httpCQ9Api.PlayerLoginAsync(new PlayerLoginInput
        {
            Account = "test111",
            Password = "111"
        });
        return res;
    }

    [HttpPost]
    public async Task<PlayerGamelinkOutput> PlayerGamelinkAsync(PlayerGamelinkInput input)
    {
        var res = await _httpCQ9Api.PlayerGamelinkAsync(new PlayerGamelinkInput
        {
            UserToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJicmFuZCI6ImNxOSIsImFjY291bnQiOiJ0ZXN0MTExIiwib3duZXIiOiI2Njk4ZGQ3MGJiYWIyNDM3MGE5MTE5MzciLCJjdXJyZW5jeSI6IlVTRCIsInBhcmVudCI6IjY2OThkZDcwYmJhYjI0MzcwYTkxMTkzNyIsInVzZXJpZCI6IjY2OWI3YTYyYmJhYjI0MzcwYTkxNGY4NSIsIm5pY2tuYW1lIjoidGVzdDExMSIsInR5cGUiOiJQTEFZRVIiLCJtYXhpbXVtIjowLCJtaW5pbXVtIjowLCJkZWZhdWx0IjowLCJyb2xlIjoiIiwid3VybCI6Imh0dHA6Ly90cmFuc2FjdGlvbjoxMzI0Iiwid3Rva2VuIjoiIiwiaXAiOiIxMC4wLjEuMTg3IiwibG9jYXRpb24iOiJ0YWl3YW4iLCJnYW1ldGVhbSI6IiIsIkJldFRocmVzaG9sZHMiOiIiLCJqdGkiOiI0MDg3NTY4NzQiLCJpYXQiOjE3MjE2MTQ0MzcsImlzcyI6IkN5cHJlc3MiLCJzdWIiOiJVc2VyVG9rZW4ifQ.MLg1T0Ua14szOMVY9CusGnzm6LpP2ouVCjPGg25fpww",
            GameHall = "cq9",
            App = "N",
            Detect = "N",
            GameCode = "GB7",
            GamePlat = "web",
            Lang = "zh-cn",
            Dollarsign = "N"
        });
        return res;
    }



    [HttpPost]
    public async Task<PlayerDepositOutput> PlayerDepositAsync(PlayerDepositInput input)
    {
        var res = await _httpCQ9Api.PlayerDepositAsync(new PlayerDepositInput
        {
            Account = "test111",
            Amount = 1111,
            MtCode = "454545454451"
        });
        return res;
    }



    [HttpPost]
    public async Task<GameListOutput> GameListAsync(GameListlInput input)
    {
        var res = await _httpCQ9Api.GameListAsync(new GameListlInput
        {
            GameHall = "cq9"
        });
        return res;
    }

    [HttpPost]
    public async Task<PlayerBalanceOutput> PlayerBalanceAsync(PlayerBalanceInput input)
    {
        var res = await _httpCQ9Api.PlayerBalanceAsync(new PlayerBalanceInput
        {
            Account = "test111"
        });
        return res;
    }

    [HttpPost]
    public async Task<PlayerWithDrawOutput> PlayerWithdrawAsync(PlayerWithDrawInput input)
    {
        var res = await _httpCQ9Api.PlayerWithdrawAsync(new PlayerWithDrawInput
        {
            Account = "test111",
            Amount = 100,
            MtCode = new Guid().ToString(),
        });
        return res;
    }

    [HttpPost]
    public async Task<PlayerPwdOutput> PlayerPwdAsync(PlayerPwdInput input)
    {
        var res = await _httpCQ9Api.PlayerPwdAsync(new PlayerPwdInput
        {
            Account = "test111",
            Password = "111"
        });
        return res;
    }

    [HttpPost]
    public async Task<OrderViewOutput> OrderViewAsync(OrderViewInput input)
    {
        var res = await _httpCQ9Api.OrderViewAsync(new OrderViewInput
        {
            Account = "test111",
            EndTime = input.EndTime,
            StartTime = input.StartTime,
            GameType = "slot",
            Page = 1,
            PageSize = 500,
        });
        return res;
    }

    [HttpPost]
    public async Task<OrderRecordOutput> OrderRecordAsync(OrderRecordInput input)
    {
        var res = await _httpCQ9Api.OrderRecordAsync(new OrderRecordInput
        {
            GameCode = "GB7",
            GamneHall = "cq9",
            RoundId = new Guid().ToString()
        });
        return res;
    }

    [HttpPost]
    public async Task<OrderSummaryOutput> OrderSummaryAsync(OrderSummaryInput input)
    {
        var res = await _httpCQ9Api.OrderSummaryAsync(new OrderSummaryInput
        {
            Account = "test111",
            EndTime = DateTime.Now.AddHours(1),
            StartTime = DateTime.Now,
            GameType = "slot"
        });
        return res;
    }

    [HttpPost]
    public async Task<TransactionViewOutput> TransactionViewAsync(TransactionViewInput input)
    {
        var res = await _httpCQ9Api.TransactionViewAsync(new TransactionViewInput
        {
            Account = "test111",
            EndTime = DateTime.Now.AddHours(1),
            StartTime = DateTime.Now,
            Page = 1,
            PageSize = 500,
        });
        return res;
    }

    [HttpPost]
    public async Task<TransactionRecordOutput> TransactionRecordAsync(TransactionRecordInput input)
    {
        var res = await _httpCQ9Api.TransactionRecordAsync(new TransactionRecordInput
        {
            MtCode = "454545454451"
        });
        return res;
    }

    [HttpPost]
    public async Task<PlayerLogoutOutput> PlayerLogoutAsync(PlayerLogoutInput input)
    {
        var res = await _httpCQ9Api.PlayerLogoutAsync(new PlayerLogoutInput
        {
            Account = "test111"
        });
        return res;
    }

    [HttpPost]
    public async Task<LogoutAllOutput> LogoutAllAsync(LogoutAllInput input)
    {
        var res = await _httpCQ9Api.LogoutAllAsync(new LogoutAllInput
        {
            Account = new List<string?> { "test111" },
            IsAll = false
        });
        return res;
    }

    [HttpPost]
    public async Task<PlayerTokenOutput> PlayerTokenAsync(PlayerTokenInput input)
    {
        var res = await _httpCQ9Api.PlayerTokenAsync(new PlayerTokenInput
        {
            Account = "test111"
        });
        return res;
    }

    [HttpPost]
    public async Task<PlayerCheckOutput> PlayerCheckAsync(PlayerCheckInput input)
    {
        var res = await _httpCQ9Api.PlayerCheckAsync(new PlayerCheckInput
        {
            Account = "test111"
        });
        return res;
    }

    [HttpPost]
    public async Task<PlayerMslinkOutput> PlayerMslinkAsync(PlayerMslinkInput input)
    {
        var res = await _httpCQ9Api.PlayerMslinkAsync(new PlayerMslinkInput
        {
            Lang = "zh-en",
            UserToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJicmFuZCI6ImNxOSIsImFjY291bnQiOiJ0ZXN0MTExIiwib3duZXIiOiI2Njk4ZGQ3MGJiYWIyNDM3MGE5MTE5MzciLCJjdXJyZW5jeSI6IlVTRCIsInBhcmVudCI6IjY2OThkZDcwYmJhYjI0MzcwYTkxMTkzNyIsInVzZXJpZCI6IjY2OWI3YTYyYmJhYjI0MzcwYTkxNGY4NSIsIm5pY2tuYW1lIjoidGVzdDExMSIsInR5cGUiOiJQTEFZRVIiLCJtYXhpbXVtIjowLCJtaW5pbXVtIjowLCJkZWZhdWx0IjowLCJyb2xlIjoiIiwid3VybCI6Imh0dHA6Ly90cmFuc2FjdGlvbjoxMzI0Iiwid3Rva2VuIjoiIiwiaXAiOiIxMC4wLjEuMTg3IiwibG9jYXRpb24iOiJ0YWl3YW4iLCJnYW1ldGVhbSI6IiIsIkJldFRocmVzaG9sZHMiOiIiLCJqdGkiOiI0MDg3NTY4NzQiLCJpYXQiOjE3MjE2MTQ0MzcsImlzcyI6IkN5cHJlc3MiLCJzdWIiOiJVc2VyVG9rZW4ifQ.MLg1T0Ua14szOMVY9CusGnzm6LpP2ouVCjPGg25fpww",

        });
        return res;
    }

}