using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ICastServiceAsync
{
    Task<CastModel> GetCastAsync(int id);
    Task<IEnumerable<CastModel>> GetCastsAsync();
    Task<int> CreateCastMemberAsync(CastModel cast);
}
