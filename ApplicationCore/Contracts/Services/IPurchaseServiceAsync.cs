using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IPurchaseServiceAsync
{
    Task<PurchaseModel> GetPurchaseAsync(int id);
    Task<IEnumerable<PurchaseModel>> GetPurchasesAsync();
    Task<int> MakePurchaseAsync(PurchaseModel purchase);
}
