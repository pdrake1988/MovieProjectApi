using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseServiceAsync _purchaseService;

        public PurchaseController(IPurchaseServiceAsync purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        [Authorize]
        [Route("GetPurchaseById/{id}")]
        public async Task<PurchaseModel> GetPurchase(int id)
        {
            return await _purchaseService.GetPurchaseAsync(id);
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllPurchases")]
        public async Task<IEnumerable<PurchaseModel>> GetPurchases()
        {
            return await _purchaseService.GetPurchasesAsync();
        }

        [HttpPost]
        [Authorize]
        [Route("MakePurchase")]
        public Task<int> MakePurchase(PurchaseModel purchase)
        {
            return _purchaseService.MakePurchaseAsync(purchase);
        }
    }
}
