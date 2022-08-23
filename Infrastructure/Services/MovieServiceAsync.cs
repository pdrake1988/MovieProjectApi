using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class MovieServiceAsync : IMovieServiceAsync
{
    private readonly IMovieRepositoryAsync _movieRepository;
    private readonly IGenreRepositoryAsync _genreRepository;
    private readonly ICastRepositoryAsync _castRepository;

    public MovieServiceAsync(IMovieRepositoryAsync movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<MovieModel> GetMovieByIdAsync(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);
        {
            MovieModel movieModel = new MovieModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Revenue = movie.Revenue,
                Budget = movie.Budget,
                ImdbUrl = movie.ImdbUrl,
                PosterUrl = movie.PosterUrl,
                OriginalLanguage = movie.OriginalLanguage,
                ReleaseDate = movie.ReleaseDate,
                Runtime = movie.Runtime,
                Price = movie.Price,
                Genres = movie.Genres.ToList(),
                Cast = movie.Cast.ToList(),
                Purchases = movie.Purchases.ToList(),
                Favorites = movie.Favorites.ToList()
            };
            return movieModel;
        }
    }

    public async Task<IEnumerable<MovieModel>> GetAllMoviesAsync()
    {
        var movies = await _movieRepository.GetAllAsync();
        {
            List<MovieModel> movieModels = new List<MovieModel>();
            foreach (var movie in movies)
            {
                MovieModel movieModel = new MovieModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Overview = movie.Overview,
                    Tagline = movie.Tagline,
                    Revenue = movie.Revenue,
                    Budget = movie.Budget,
                    ImdbUrl = movie.ImdbUrl,
                    PosterUrl = movie.PosterUrl,
                    OriginalLanguage = movie.OriginalLanguage,
                    ReleaseDate = movie.ReleaseDate,
                    Runtime = movie.Runtime,
                    Price = movie.Price,
                    Genres = movie.Genres.ToList(),
                    Cast = movie.Cast.ToList(),
                    Purchases = movie.Purchases.ToList(),
                    Favorites = movie.Favorites.ToList()
                };
                movieModels.Add(movieModel);
            }
            return movieModels;
        }
    }

    public async Task<int> CreateMovieAsync(MovieModel movie)
    {
        Movie newMovie = new Movie()
        {
            Id = movie.Id,
            Title = movie.Title,
            Overview = movie.Overview,
            Tagline = movie.Tagline,
            Revenue = movie.Revenue,
            PosterUrl = movie.PosterUrl,
            OriginalLanguage = movie.OriginalLanguage,
            ReleaseDate = movie.ReleaseDate,
            Runtime = movie.Runtime,
            Price = movie.Price,
            Genres = new List<Genre>(),
            Cast = new List<Cast>()
        };
        newMovie.Genres.Add(await _genreRepository.GetByIdAsync(movie.GenreId));
        newMovie.Cast.Add(await _castRepository.GetByIdAsync(movie.CastId));
        return await _movieRepository.InsertAsync(newMovie);
    }
}
