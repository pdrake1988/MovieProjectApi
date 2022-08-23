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
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteServiceAsync _favoriteService;

        public FavoriteController(IFavoriteServiceAsync favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllFavorites")]
        public async Task<IEnumerable<FavoriteModel>> GetAllFavorites()
        {
            return await _favoriteService.GetFavorites();
        }

        [HttpGet]
        [Authorize]
        [Route("GetFavoriteById")]
        public async Task<FavoriteModel> GetFavoriteById(int id)
        {
            return await _favoriteService.GetFavorite(id);
        }

        [HttpPost]
        [Authorize]
        [Route("AddFavorite")]
        public Task<int> AddFavorite(FavoriteModel favorite)
        {
            return _favoriteService.AddFavorite(favorite);
        }
    }
}
