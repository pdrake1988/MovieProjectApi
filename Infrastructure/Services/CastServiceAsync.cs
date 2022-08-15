using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services;

public class CastServiceAsync : ICastServiceAsync
{
    private readonly IMovieRepositoryAsync _movieRepository;
    private readonly ICastRepositoryAsync _castRepository;

    public CastServiceAsync(
        ICastRepositoryAsync castRepository,
        IMovieRepositoryAsync movieRepository
    )
    {
        _castRepository = castRepository;
        _movieRepository = movieRepository;
    }

    public async Task<CastModel> GetCastMemberAsync(int id)
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

    public async Task<IEnumerable<CastModel>> GetCastAsync()
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
            Movies = new List<Movie>()
        };
        newCast.Movies.Add(await _movieRepository.GetByIdAsync(cast.MovieId));
        return await _castRepository.InsertAsync(newCast);
    }
}
