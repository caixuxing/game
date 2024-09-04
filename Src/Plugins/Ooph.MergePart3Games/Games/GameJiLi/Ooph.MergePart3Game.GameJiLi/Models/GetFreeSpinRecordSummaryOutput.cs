// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ooph.MergePart3Game.GameJiLi.Models;
public class GetFreeSpinRecordSummaryOutput : ResponseBase<GetFreeSpinRecordSummaryData?> { }

public class GetFreeSpinRecordSummaryData
{
    public List<GetFreeSpinRecordSummaryDataItem?>? GetFreeSpinRecordSummaryDataItems { get; set; }

    public GetFreeSpinRecordSummaryDataOverview? GetFreeSpinRecordSummaryDataOverview { get; set; }
}


public class GetFreeSpinRecordSummaryDataItem
{
    /// <summary>  
    /// 投注总金额 (根据描述，此项必为0)  
    /// </summary>  
    public decimal? BetAmount { get; set; }

    /// <summary>  
    /// 派彩总金额  
    /// </summary>  
    public decimal? PayoffAmount { get; set; }

    /// <summary>  
    /// 注单数量  
    /// </summary>  
    public int? WagersCount { get; set; }

    /// <summary>  
    /// 注单币别 (转账钱包这项为空字符串)  
    /// </summary>  
    public string? Currency { get; set; }

    /// <summary>  
    /// 派彩投注差值总金额  
    /// </summary>  
    public decimal? WinlossAmount { get; set; }
}

public class GetFreeSpinRecordSummaryDataOverview
{
    /// <summary>  
    /// 赠送总局数  
    /// </summary>  
    public int? TotalSend { get; set; }

    /// <summary>  
    /// 已使用总局数  
    /// </summary>  
    public int? TotalUsed { get; set; }

    /// <summary>  
    /// 未使用总局数  
    /// </summary>  
    public int? TotalUnused { get; set; }
}