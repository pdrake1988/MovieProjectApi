using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IFavoriteServiceAsync
{
    Task<FavoriteModel> GetFavorite(int id);
    Task<IEnumerable<FavoriteModel>> GetFavorites();
    Task<int> AddFavorite(FavoriteModel favorite);
}
