using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ICastServiceAsync
{
    Task<CastModel> GetCastMemberAsync(int id);
    Task<IEnumerable<CastModel>> GetCastAsync();
    Task<int> CreateCastMemberAsync(CastModel cast);
}
