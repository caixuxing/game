
using Admin.NET.Core.Service;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office.CustomUI;
using Furion.JsonSerialization;
using Furion.Schedule;
using MimeKit.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ooph.Database.Entity;
using System;

namespace Ooph.Core.Job;

/// <summary>
/// 币种汇率同步任务
/// </summary>
[JobDetail("job_CurrencyRateSync", Description = "币种汇率同步", GroupName = "default", Concurrent = false)]
[PeriodSeconds(60, TriggerId = "trigger_currencyRateSyncJob", Description = "币种汇率同步", MaxNumberOfRuns = 0, RunOnStart = true)]
public class CurrencyRateSyncJob : IJob
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IJsonSerializerProvider _jsonSerializer;
 

    public CurrencyRateSyncJob(IServiceScopeFactory scopeFactory, IJsonSerializerProvider jsonSerializer)
    {
        _scopeFactory = scopeFactory;
        _jsonSerializer = jsonSerializer;
    }

    public async Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
    {

        context.Result = $"{DateTime.UtcNow},asfdsafdfasdf";

        return;
        using var serviceScope = _scopeFactory.CreateScope();



        var db = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<OoParty3Voucher>>().AsSugarClient().CopyNew();
        var sysCacheService=serviceScope.ServiceProvider.GetRequiredService<SysCacheService>();

        //2.满足当前充值同步触发值条件 将汇率写入到汇率配置历史表
        var q1 = db.Queryable<OoParty3Voucher>().Where(x => x.TypeKey == "CurrencyRateSyncSet" && x.VoucherKey == "CurrencyRateSyncSet")
            .Select(x => new CurrencyRateSyncSetting { Voucher = x.GloballyVoucher, TenantId= SqlSugarConst.DefaultTenantId }); 
        var q2 = db.Queryable<OoParty3Voucherdetail>().Where(x => x.TypeKey == "CurrencyRateSyncSet" && x.VoucherKey == "CurrencyRateSyncSet")
            .Select(x => new CurrencyRateSyncSetting { Voucher = x.Voucher, TenantId = x.TenantId });
        var list = db.Union(q1, q2).ToList();

        List<long?> data = new ();
        //获取那些租户设置了汇率同步
        foreach (var item in list)
        {
            RateSyncSettingsDto formDto =JsonConvert.DeserializeObject<RateSyncSettingsDto>(item.Voucher);
            //手动同步跳出
            if (formDto.UpdateType == 2) continue;
            var lastExecTime=sysCacheService.GetOrAdd($"RateSyncValve:{item.TenantId}", (str) => { return DateTime.MinValue; });
            //计算当前时间与上次执行时间的间隔
            int interval = (DateTime.Now - lastExecTime).TotalMinutes.ToInt();
            if (interval < formDto.Frequency) continue;
            data.Add(item.TenantId);
            sysCacheService.Remove($"RateSyncValve:{item.TenantId}");
            sysCacheService.Set($"RateSyncValve:{item.TenantId}", DateTime.Now);
        }
        if (data.Count > 0)
        {
            db.Queryable<OoCurrencyRateConfig>()
              .Where(x => data.Contains(x.TenantId))
              .ForEach(item => {

              });
        }
        Console.ForegroundColor = ConsoleColor.Green;
        await Console.Out.WriteLineAsync($"【{DateTime.Now}】系统币种汇率同步任务执行已完成");
        Console.ForegroundColor = Console.ForegroundColor;
    }
}

class CurrencyRateSyncSetting
{
    public dynamic? Voucher { get; set; }
    public long? TenantId { get; set; }
}

/// <summary>
/// 汇率同步设置VFormDto
/// </summary>
public class RateSyncSettingsDto
{
    /// <summary>
    /// 汇率充提设置
    /// </summary>
    public int DepositsWithdrawalsSet { get; set; }

    /// <summary>
    /// 更新方式
    /// </summary>
    public int UpdateType { get; set; }

    /// <summary>
    /// 更新频率
    /// </summary>
    public int Frequency { get; set; }
}