using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CastRepositoryAsync : BaseRepositoryAsync<Cast>, ICastRepositoryAsync
{
    public CastRepositoryAsync(MovieDbContext context) : base(context) { }
}
