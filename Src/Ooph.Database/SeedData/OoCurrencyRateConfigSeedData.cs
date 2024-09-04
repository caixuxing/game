using Ooph.Core.Util;


namespace Ooph.Database.SeedData;

/// <summary>
/// 币种汇率配置种子数据
/// </summary>
public  class OoCurrencyRateConfigSeedData : ISqlSugarEntitySeedData<OoCurrencyRateConfig>
{
    public IEnumerable<OoCurrencyRateConfig> HasData()
    {
        //虚拟币
        var virtualCurrency = EnumUtil.GetEnumType<CurrencyTypeEnum>().Where(i => i.ParentId == (int)CurrencyCategoryEnum.Virtual).ToList();
        var EnumNames = virtualCurrency.Select(x => x.EnumName).ToList();
        var data = System.Enum.GetValues(typeof(CurrencyTypeEnum)).OfType<CurrencyTypeEnum>()
            .Where(x=>!EnumNames.Contains(x.ToString()!))
            .ToList();

        long Id = 1300000000001;

        foreach (var item in virtualCurrency)
        {
            foreach (var item2 in data)
            {
               var originalCurrency=(CurrencyTypeEnum)System.Enum.Parse(typeof(CurrencyTypeEnum), item.EnumName);
                //根据原币种 兑换币种 找出市场汇率
                var currentMarketRate = MarketRateDataList() .FirstOrDefault(x => x.OriginalCurrency == originalCurrency && x.ExchangeCurrency == item2)?.MarketRate ?? 0.00m;
                yield return new OoCurrencyRateConfig
                {
             /*       Id = Id++,
                    OriginalCurrency = originalCurrency,
                    ExchangeCurrency = item2,
                    RateSource = RateSourceEnum.IntlOffshore,
                    MarketRate = currentMarketRate,
                    RechargeRateDiffUnit = RateDiffUnitTypeEnum.Percentage,
                    RechargePolar = PolarTypeEnum.Positive,
                    RechargeRateDiff = 0.00m,
                    RechargeValidRate = ComputeValidRate(currentMarketRate, RateDiffUnitTypeEnum.Percentage, PolarTypeEnum.Positive, 0.00m),
                    RechargeSyncUnit = RateDiffUnitTypeEnum.Percentage,
                    RechargeSyncTrigger = 0.00m,
                    PayRateDiffUnit = RateDiffUnitTypeEnum.Percentage,
                    PayPolar = PolarTypeEnum.Positive,
                    PayRateDiff = 0.00m,
                    PayValidRate = ComputeValidRate(currentMarketRate, RateDiffUnitTypeEnum.Percentage, PolarTypeEnum.Positive, 0.00m),
                    PaySyncUnit = RateDiffUnitTypeEnum.Percentage,
                    PaySyncTrigger = 0.00m,
                    TenantId = SqlSugarConst.DefaultTenantId*/
                };
            }
        }

        //市场汇率
        IEnumerable<dynamic> MarketRateDataList()
        {
             return new []{
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.RUB, MarketRate = 85.7114769064m },
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.TRX, MarketRate = 8.6582139035m },
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.TRY, MarketRate = 32.6418026619m },
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.NGN, MarketRate = 1489.8435294472m },
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.BDT, MarketRate = 117.2396177159m },
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.USDC, MarketRate = 0.9996495375m },
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.ETH, MarketRate = 0.0006118784m },
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.BTC, MarketRate = 0.0000444551m },
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.KHR, MarketRate = 4110.9559033856m },
                new { OriginalCurrency = CurrencyTypeEnum.USDT, ExchangeCurrency = CurrencyTypeEnum.RUB, MarketRate = 85.7415260970m }
            };
        }
    }
    /// <summary>
    /// 生效汇率计算
    /// </summary>
    /// <param name="marketRate">市场汇率</param>
    /// <param name="diffUnitTypeMnum">单位</param>
    /// <param name="polarTypeEnum">正负极</param>
    /// <param name="rateDiff">汇率差</param>
    /// <returns></returns>
    private decimal ComputeValidRate(decimal marketRate, RateDiffUnitTypeEnum diffUnitTypeMnum,
                                      PolarTypeEnum polarTypeEnum, decimal rateDiff)
    {

        if (diffUnitTypeMnum == RateDiffUnitTypeEnum.Percentage && polarTypeEnum == PolarTypeEnum.Positive)
            return marketRate + rateDiff / 100m;

        if (diffUnitTypeMnum == RateDiffUnitTypeEnum.Percentage && polarTypeEnum == PolarTypeEnum.Negative)
            return marketRate - rateDiff / 100m;

        if (diffUnitTypeMnum == RateDiffUnitTypeEnum.FixedValue && polarTypeEnum == PolarTypeEnum.Positive)
            return marketRate + rateDiff;

        if (diffUnitTypeMnum == RateDiffUnitTypeEnum.FixedValue && polarTypeEnum == PolarTypeEnum.Negative)
            return marketRate - rateDiff;

        return 0.00m;
    }

}