using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class FavoriteServiceAsync : IFavoriteServiceAsync
{
    private readonly IFavoriteRepositoryAsync _favoriteRepository;

    public FavoriteServiceAsync(IFavoriteRepositoryAsync favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    public async Task<FavoriteModel> GetFavorite(int id)
    {
        var favorite = await _favoriteRepository.GetByIdAsync(id);
        FavoriteModel favoriteModel = new FavoriteModel()
        {
            Id = favorite.Id,
            UserId = favorite.UserId,
            MovieId = favorite.MovieId
        };
        return favoriteModel;
    }

    public async Task<IEnumerable<FavoriteModel>> GetFavorites()
    {
        var favorites = await _favoriteRepository.GetAllAsync();
        List<FavoriteModel> listOfFavorites = new List<FavoriteModel>();
        foreach (var favorite in favorites)
        {
            FavoriteModel favoriteModel = new FavoriteModel()
            {
                Id = favorite.Id,
                UserId = favorite.UserId,
                MovieId = favorite.MovieId
            };
            listOfFavorites.Add(favoriteModel);
        }
        return listOfFavorites;
    }

    public Task<int> AddFavorite(FavoriteModel favorite)
    {
        Favorite favoriteEntity = new Favorite()
        {
            UserId = favorite.UserId,
            MovieId = favorite.MovieId
        };
        return _favoriteRepository.InsertAsync(favoriteEntity);
    }
}
