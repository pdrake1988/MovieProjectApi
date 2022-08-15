using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepositoryAsync : BaseRepositoryAsync<Genre>, IGenreRepositoryAsync
{
    public GenreRepositoryAsync(MovieDbContext context) : base(context) { }
}
