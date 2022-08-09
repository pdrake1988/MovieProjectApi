using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepositoryAsync : BaseRepositoryAsync<Genre>, IGenreRepositoryAsync
{
    protected GenreRepositoryAsync(MovieDbContext context) : base(context) { }
}
