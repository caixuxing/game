using Furion.DataValidation;
using Newtonsoft.Json.Linq;
using Ooph.AppBackground.Service.Party3.Dto;
using Ooph.Database.Entity;

namespace Ooph.AppBackground.Service.Party3;



/// <summary>
/// 三方凭证详细
/// </summary>
[ApiDescriptionSettings(Order = 100, Groups = new[] { AppConst.GroupName_Test })]
public class Party3VoucherdetailService : IDynamicApiController, ITransient
{

    private readonly SqlSugarRepository<OoParty3Voucher> _party3VoucherRep;
    private readonly SqlSugarRepository<OoParty3Voucherdetail> _party3VoucherdetailRep;
    private readonly UserManager _userManager;
    
    public Party3VoucherdetailService(
        SqlSugarRepository<OoParty3Voucher> party3VoucherRep,
        SqlSugarRepository<OoParty3Voucherdetail> party3VoucherdetailRep,
        UserManager userManager
        )
    {
        _party3VoucherRep = party3VoucherRep;
        _party3VoucherdetailRep = party3VoucherdetailRep;
        _userManager = userManager;
    }


    [HttpPost]
    [ApiDescriptionSettings(Name = "save")]
    [DisplayName("保存三方凭证信息")]
    public async Task SaveParty3Voucherdetail(Party3VoucherdetailInput input)
    {
        var voucherdetail = await _party3VoucherdetailRep
            .GetFirstAsync(x => x.TypeKey == input.TypeKey && x.VoucherKey == input.VoucherKey && x.TenantId == _userManager.TenantId);
        if (voucherdetail is not null)
            voucherdetail.Voucher = JObject.Parse(input.Voucher);
        else
        {
            voucherdetail = input.Adapt<OoParty3Voucherdetail>();
            voucherdetail.Voucher = JObject.Parse(input.Voucher);
        }
        await _party3VoucherdetailRep.InsertOrUpdateAsync(voucherdetail);
    }
}
