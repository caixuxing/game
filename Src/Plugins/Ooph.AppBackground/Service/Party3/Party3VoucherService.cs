
using Ooph.AppBackground.Service.Party3.Dto;
using Ooph.Database.Entity;

namespace Ooph.AppBackground.Service.Party3;


/// <summary>
/// 三方凭证类型
/// </summary>
[ApiDescriptionSettings(Order = 100, Groups = new[] { AppConst.GroupName_Test })]
public class Party3VoucherService : IDynamicApiController, ITransient
{

    private readonly SqlSugarRepository<OoParty3Voucher> _party3VoucherRep;
    private readonly SqlSugarRepository<OoParty3Voucherdetail> _party3VoucherdetailRep;
    private readonly UserManager _userManager;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="party3VoucherRep"></param>
    /// <param name="party3VoucherdetailRep"></param>
    /// <param name="userManager"></param>
    public Party3VoucherService(
        SqlSugarRepository<OoParty3Voucher> party3VoucherRep,
        SqlSugarRepository<OoParty3Voucherdetail> party3VoucherdetailRep,
        UserManager userManager
        )
    {
        _party3VoucherRep = party3VoucherRep;
        _party3VoucherdetailRep = party3VoucherdetailRep;
       _userManager = userManager;
    }


    /// <summary>
    /// 按Key条件查询三方凭证
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "findByKey")]
    [DisplayName("按Key条件查询三方凭证")]
    public async Task<OoParty3VoucherDto> FindParty3VoucherByKey(OoParty3VoucherInput input)
    {
        var voucherdetai = await _party3VoucherdetailRep.GetSingleAsync(x => x.TenantId == _userManager.TenantId && x.TypeKey == input.TypeKey && x.VoucherKey == input.VoucherKey);
        var voucher = await _party3VoucherRep.GetSingleAsync(x => x.TypeKey == input.TypeKey && x.VoucherKey == input.VoucherKey);
        if (voucher is null) throw new Exception("记录不存在！");
        return new OoParty3VoucherDto
        {
            FormSchemaJson = voucher.FormSchemaJson,
            Voucher = voucherdetai?.Voucher ?? voucher.GloballyVoucher
        };
    }

   
}