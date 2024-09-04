// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using DbLocalizationProvider.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLF;

/// <summary>
/// App 底部
/// </summary>
[LocalizedResource(KeyPrefix = "AF.App.Comm")]
public class LangAppFornt_AppCommon
#region MyRegion
{

} 
#endregion

/// <summary>
/// 全局错误
/// </summary>
[LocalizedResource(KeyPrefix = "AF.Err")]
public class LangAppFornt_Error
#region MyRegion
{
    /// <summary>
    /// 网络开小差了，请检查您的网络连接
    /// </summary>
    [TranslationForCulture("The network is down, please check your network connection", "en")]
    public static string NetworkError => "网络开小差了，请检查您的网络连接";
}
#endregion

/// <summary>
/// App 顶部
/// </summary>
[LocalizedResource(KeyPrefix = "AF.App.Header")]
public class LangAppFornt_AppHeader
#region MyRegion
{
    /// <summary>
    /// 登录
    /// </summary>
    [TranslationForCulture("Login", "en")]
    public static string Login => "登录";

    /// <summary>
    /// 注册
    /// </summary>
    [TranslationForCulture("Register", "en")]
    public static string Register => "注册";

    /// <summary>
    /// 当前余额
    /// </summary>
    [TranslationForCulture("Current Balance", "en")]
    public static string CurrentBalance => "当前余额";


    /// <summary>
    /// 若余额丢失，可点击
    /// </summary>
    [TranslationForCulture("If the balance is lost, you can click", "en")]
    public static string TooltipLostBalance => "若余额丢失，可点击";

    /// <summary>
    /// 找回余额
    /// </summary>
    [TranslationForCulture("Retrieve balance", "en")]
    public static string RetrieveBalance => "找回余额";

    /// <summary>
    /// 充值
    /// </summary>
    [TranslationForCulture("Deposit", "en")]
    public static string Deposit => "充值";

    /// <summary>
    /// 充值
    /// </summary>
    [TranslationForCulture("Withdraw", "en")]
    public static string Withdraw => "提现";
}
#endregion

/// <summary>
/// App 底部
/// </summary>
[LocalizedResource(KeyPrefix = "AF.App.Footer")]
public class LangAppFornt_AppFooter
#region MyRegion
{
    /// <summary>
    /// 网络开小差了，请检查您的网络连接
    /// </summary>
    [TranslationForCulture("Home", "en")]
    public static string HomePage => "首页";

    /// <summary>
    /// 优惠
    /// </summary>
    [TranslationForCulture("Offers", "en")]
    public static string Offers => "优惠";

    /// <summary>
    /// 登录
    /// </summary>
    [TranslationForCulture("Login", "en")]
    public static string Login => "登录";

    /// <summary>
    /// 注册
    /// </summary>
    [TranslationForCulture("Register", "en")]
    public static string Register => "注册";

    /// <summary>
    /// 我的
    /// </summary>
    [TranslationForCulture("Profile", "en")]
    public static string Profile => "我的";
}
#endregion

/// <summary>
/// App 左菜单
/// </summary>
[LocalizedResource(KeyPrefix = "AF.App.Menu")]
public class LangAppFornt_AppMenu
#region MyRegion
{
    /// <summary>
    /// App 下载
    /// </summary>
    [TranslationForCulture("App Download", "en")]
    public static string AppDownload => "App 下载";

    /// <summary>
    /// 客服
    /// </summary>
    [TranslationForCulture("Customer Service", "en")]
    public static string CustomerService => "客服";

    /// <summary>
    /// 优惠中心
    /// </summary>
    [TranslationForCulture("Offer Center", "en")]
    public static string OfferCenter => "优惠中心";

    /// <summary>
    /// 活动
    /// </summary>
    [TranslationForCulture("Event", "en")]
    public static string Offer_Event => "活动";

    /// <summary>
    /// 任务
    /// </summary>
    [TranslationForCulture("Mission", "en")]
    public static string Offer_Mission => "任务";

    /// <summary>
    /// 待领取
    /// </summary>
    [TranslationForCulture("Reward", "en")]
    public static string Offer_Reward => "待领取";

    /// <summary>
    /// 领取记录
    /// </summary>
    [TranslationForCulture("Reward History", "en")]
    public static string Offer_RewardHistory => "领取记录";

    /// <summary>
    /// VIP
    /// </summary>
    [TranslationForCulture("VIP", "en")]
    public static string Offer_Vip => "VIP";

    /// <summary>
    /// 代理 [推广赚钱]
    /// </summary>
    [TranslationForCulture("Offer Agent", "en")]
    public static string Offer_Agent => "推广赚钱";

    /// <summary>
    /// 投注记录
    /// </summary>
    [TranslationForCulture("Bet Records", "en")]
    public static string BetRecords => "投注记录";
}
#endregion

/// <summary>
/// App 账号相关
/// </summary>
[LocalizedResource(KeyPrefix = "AF.Account")]
public class LangAppFornt_Account
#region MyRegion
{
    /// <summary>
    /// 登 录
    /// </summary>
    [TranslationForCulture("Login", "en")]
    public static string Login => "登 录";

    /// <summary>
    /// 请输入账号
    /// </summary>
    [TranslationForCulture("Please enter your account", "en")]
    public static string UserNameRequired => "请输入账号";

    /// <summary>
    /// 用户名
    /// </summary>
    [TranslationForCulture("UserName", "en")]
    public static string UserName => "用户名";

    /// <summary>
    /// 请输入账号
    /// </summary>
    [TranslationForCulture("Please enter your account", "en")]
    public static string PasswordRequired => "请输入密码";

    /// <summary>
    /// 密码
    /// </summary>
    [TranslationForCulture("Password", "en")]
    public static string Password => "密 码";

    /// <summary>
    /// 注册
    /// </summary>
    [TranslationForCulture("Register", "en")]
    public static string Register => "注册";
} 
#endregion

/// <summary>
/// 游戏分类 (附加)
/// </summary>
[LocalizedResource(KeyPrefix = "AF.App.GameType")]
public class LangAppFornt_AppGameCategorize
#region MyRegion
{
    /// <summary>
    /// 热 门
    /// </summary>
    [TranslationForCulture("Hot", "en")]
    public static string Hot => "热 门";

    [TranslationForCulture("Recent", "en")]
    public static string Recent => "最近";

    /// <summary>
    /// 收藏
    /// </summary>
    [TranslationForCulture("Favorite", "en")]
    public static string Favorite => "收藏";
} 
#endregion