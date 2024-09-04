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

namespace Ooph.MergePart3Game.GameCQ9.Models;
public class LogoutAllInput
{
    /// <summary>
    /// 是否登出全部代理的玩家
    ///※总代为选填，若仅登出总代理玩家，此栏位勿填。
    ///預設為false，若為true則會登出包含總代之全部代理的玩家※子代不應填此參數(會返回錯誤代碼38)
    /// </summary>
    public bool? IsAll { get; set; }

    /// <summary>
    /// 指定代理帐号
    ///※总代为选填，若仅登出总代理玩家，此栏位勿填。
    ///若isall為true時無效，因為登出的玩家已包含總代下所有子代的玩家※子代不應填此參數(會返回錯誤代碼38)
    /// </summary>
    public List<string?>? Account { get; set; }
}
