using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class GenreServiceAsync : IGenreServiceAsync
{
    private readonly IGenreRepositoryAsync _genreRepository;

    public GenreServiceAsync(IGenreRepositoryAsync genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public Task<int> CreateGenreAsync(GenreModel genre)
    {
        Genre genreEntity = new Genre { Id = genre.Id, Name = genre.Name, };
        return _genreRepository.InsertAsync(genreEntity);
    }

    public async Task<GenreModel> GetGenreByIdAsync(int id)
    {
        var genreEntity = await _genreRepository.GetByIdAsync(id);
        GenreModel genre = new GenreModel { Id = genreEntity.Id, Name = genreEntity.Name };
        return genre;
    }

    public async Task<IEnumerable<GenreModel>> GetAllGenresAsync()
    {
        var genreEntities = await _genreRepository.GetAllAsync();
        {
            List<GenreModel> genres = new List<GenreModel>();
            foreach (var genre in genreEntities)
            {
                GenreModel genreModel = new GenreModel { Id = genre.Id, Name = genre.Name };
                genres.Add(genreModel);
            }

            return genres;
        }
    }
}
