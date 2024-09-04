using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ooph.Database.Entity;

/// <summary>
/// App包管理
/// </summary>
[SugarTable("oo_app_package", "App包管理")]
public partial class OoAppPackage : EntityTenant
{
    /// <summary>
    /// 包名称
    /// </summary>
    [SugarColumn(ColumnDescription = "包名称", Length = 20)]
    public string? AppName { get; set; }

    /// <summary>
    /// 苹果包名
    /// </summary>
    [SugarColumn(ColumnDescription = "苹果包名", Length = 50)]
    public string? IosPackageName { get; set; }

    /// <summary>
    /// 安卓包名 注意事项：一般不建议更改，否则很多三方将失效，需重新配置！
    /// </summary>
    [SugarColumn(ColumnDescription = "安卓包名 注意事项：一般不建议更改，否则很多三方将失效，需重新配置！", Length = 50)]
    public string? AndroidPackageName { get; set; }

    /// <summary>
    /// App 安卓版本号
    /// </summary>
    [SugarColumn(ColumnDescription = "App 安卓版本号", Length = 50)]
    public string? AndroidAppVersion { get; set; }

    /// <summary>
    /// App 苹果版本号
    /// </summary>
    [SugarColumn(ColumnDescription = "App 苹果版本号", Length = 50)]
    public string? AppIosVersion { get; set; }

    /// <summary>
    /// Android 签名密码 注意事项：配置后打包会生成新的证书指纹，需要Google后台重新配置“SHA-1 证书指纹”！
    /// </summary>
    [SugarColumn(ColumnDescription = "Android 签名密码 注意事项：配置后打包会生成新的证书指纹，需要Google后台重新配置“SHA-1 证书指纹”！", Length = 50)]
    public string? AndroidSignPwd { get; set; }

    /// <summary>
    /// APP 图标
    /// </summary>
    [SugarColumn(ColumnDescription = "APP 图标", Length = 255)]
    public string? AppIcon { get; set; }

    /// <summary>
    /// APP 修复图标（可与app一致）
    /// </summary>
    [SugarColumn(ColumnDescription = "APP 修复图标（可与app一致）", Length = 255)]
    public string? AppIconRepair { get; set; }

    /// <summary>
    /// APP 启动页
    /// </summary>
    [SugarColumn(ColumnDescription = "APP 启动页", Length = 255)]
    public string? AppStartupPageImage { get; set; }

    /// <summary>
    /// APP 启动页背景色
    /// </summary>
    [SugarColumn(ColumnDescription = "APP 启动页背景色", Length = 255)]
    public string? AppStartupPageBackgroundColor { get; set; }

    /// <summary>
    /// 是否强制安装
    /// </summary>
    [SugarColumn(ColumnDescription = "是否强制安装", ColumnDataType = "bit(1)", DefaultValue = "0")]
    public bool IsForceInstall { get; set; }

    [SugarColumn(ColumnDataType = "enum('None','InstallApp','InstallShortcut')")]
    public string? FooterGuideOrForceInstall { get; set; }

    /// <summary>
    /// 底部引导文案
    /// </summary>
    [SugarColumn(ColumnDescription = "底部引导文案", Length = 255)]
    public string? FooterGuideDescription { get; set; }

    /// <summary>
    /// 语言
    /// </summary>
    [SugarColumn(ColumnDescription = "语言", Length = 255)]
    public string? Languages { get; set; }
}
