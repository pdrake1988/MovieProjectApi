using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieServiceAsync
{
    Task<MovieModel> GetMovieByIdAsync(int id);
    Task<IEnumerable<MovieModel>> GetAllMoviesAsync();
    Task<int> CreateMovieAsync(MovieModel movie);
}
