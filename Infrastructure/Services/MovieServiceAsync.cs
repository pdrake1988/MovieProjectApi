﻿using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class MovieServiceAsync : IMovieServiceAsync
{
    private readonly IMovieRepositoryAsync _movieRepository;

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
                Cast = movie.Cast.ToList()
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
                    Cast = movie.Cast.ToList()
                };
                movieModels.Add(movieModel);
            }
            return movieModels;
        }
    }

    public Task<int> CreateMovieAsync(MovieModel movie)
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
            Genres = movie.Genres,
            Cast = movie.Cast
        };
        return _movieRepository.InsertAsync(newMovie);
    }
}