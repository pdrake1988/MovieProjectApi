using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IGenreServiceAsync
{
    Task<int> CreateGenreAsync(GenreModel genre);
    Task<GenreModel> GetGenreByIdAsync(int id);
    Task<IEnumerable<GenreModel>> GetAllGenresAsync();
}
