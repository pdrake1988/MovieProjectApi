using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class CastServiceAsync : ICastServiceAsync
{
    private readonly ICastRepositoryAsync _castRepository;

    public CastServiceAsync(ICastRepositoryAsync castRepository)
    {
        _castRepository = castRepository;
    }

    public async Task<CastModel> GetCastAsync(int id)
    {
        Cast cast = await _castRepository.GetByIdAsync(id);
        if (cast != null)
        {
            CastModel model = new CastModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
            };
            return model;
        }
        return null;
    }

    public async Task<IEnumerable<CastModel>> GetCastsAsync()
    {
        var cast = await _castRepository.GetAllAsync();
        if (cast != null)
        {
            List<CastModel> castMembers = new List<CastModel>();
            foreach (var item in cast)
            {
                CastModel model = new CastModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Gender = item.Gender,
                    TmdbUrl = item.TmdbUrl
                };
                castMembers.Add(model);
            }
            return castMembers;
        }
        return null;
    }

    public async Task<int> CreateCastMemberAsync(CastModel cast)
    {
        Cast newCast = new Cast()
        {
            Id = cast.Id,
            Name = cast.Name,
            Gender = cast.Gender,
            TmdbUrl = cast.TmdbUrl,
            Movies = cast.Movies.ToList(),
        };
        return await _castRepository.InsertAsync(newCast);
    }
}
