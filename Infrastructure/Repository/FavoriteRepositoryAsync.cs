using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class FavoriteRepositoryAsync : BaseRepositoryAsync<Favorite>, IFavoriteRepositoryAsync
{
    public FavoriteRepositoryAsync(MovieDbContext context) : base(context) { }
}
