using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class MovieRepositoryAsync : BaseRepositoryAsync<Movie>, IMovieRepositoryAsync
{
    public MovieRepositoryAsync(MovieDbContext context) : base(context) { }
}
