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
/// 游戏平台表种子数据
/// </summary>
public class OoGameCategorySeedData : ISqlSugarEntitySeedData<OoGameCategory>
{
    public IEnumerable<OoGameCategory> HasData()
    {
        return new[]
        {
            new OoGameCategory { Id = 1300000000301,  GameCategory = "体育"  , TenantId=SqlSugarConst.DefaultTenantId },
            new OoGameCategory { Id = 1300000000302,  GameCategory = "棋牌" ,  TenantId=SqlSugarConst.DefaultTenantId },
            new OoGameCategory { Id = 1300000000303,  GameCategory = "捕鱼" ,  TenantId=SqlSugarConst.DefaultTenantId },
            new OoGameCategory { Id = 1300000000304,  GameCategory = "电子" ,  TenantId=SqlSugarConst.DefaultTenantId },
            new OoGameCategory { Id = 1300000000305,  GameCategory = "区块链" ,TenantId=SqlSugarConst.DefaultTenantId },
            new OoGameCategory { Id = 1300000000306,  GameCategory = "真人" ,  TenantId=SqlSugarConst.DefaultTenantId },
            new OoGameCategory { Id = 1300000000307,  GameCategory = "彩票"  , TenantId=SqlSugarConst.DefaultTenantId },
            new OoGameCategory { Id = 1300000000308,  GameCategory = "其他"  , TenantId=SqlSugarConst.DefaultTenantId },
            new OoGameCategory { Id = 1300000000309,  GameCategory = "电竞"  , TenantId=SqlSugarConst.DefaultTenantId },
        };
    }
}
