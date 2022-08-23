using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class PurchaseServiceAsync : IPurchaseServiceAsync
{
    private readonly IPurchaseRepositoryAsync _purchaseRepository;

    public PurchaseServiceAsync(IPurchaseRepositoryAsync purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<PurchaseModel> GetPurchaseAsync(int id)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(id);
        PurchaseModel purchaseModel = new PurchaseModel()
        {
            Id = purchase.Id,
            TotalPrice = purchase.TotalPrice,
            UserId = purchase.UserId,
            MovieId = purchase.MovieId,
        };
        return purchaseModel;
    }

    public async Task<IEnumerable<PurchaseModel>> GetPurchasesAsync()
    {
        var purchases = await _purchaseRepository.GetAllAsync();
        List<PurchaseModel> PurchaseList = new List<PurchaseModel>();
        foreach (var purchase in purchases)
        {
            PurchaseList.Add(
                new PurchaseModel()
                {
                    Id = purchase.Id,
                    TotalPrice = purchase.TotalPrice,
                    UserId = purchase.UserId,
                    MovieId = purchase.MovieId,
                }
            );
        }

        return PurchaseList;
    }

    public Task<int> MakePurchaseAsync(PurchaseModel purchase)
    {
        Purchase purchaseEntity = new Purchase()
        {
            Id = purchase.Id,
            TotalPrice = purchase.TotalPrice,
            PurchaseNumber = purchase.PurchaseId,
            UserId = purchase.UserId,
            MovieId = purchase.MovieId,
        };
        return _purchaseRepository.InsertAsync(purchaseEntity);
    }
}
