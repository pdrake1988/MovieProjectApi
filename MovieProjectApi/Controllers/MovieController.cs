using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServiceAsync _movieServiceAsync;

        public MovieController(IMovieServiceAsync movieServiceAsync)
        {
            _movieServiceAsync = movieServiceAsync;
        }

        [HttpGet]
        [Authorize]
        [Route("GetMovies")]
        public async Task<IEnumerable<MovieModel>> GetMovies()
        {
            return await _movieServiceAsync.GetAllMoviesAsync();
        }

        [HttpGet]
        [Authorize]
        [Route("GetMovie/{id}")]
        public async Task<MovieModel> GetMovie(int id)
        {
            return await _movieServiceAsync.GetMovieByIdAsync(id);
        }

        [HttpPost]
        [Authorize]
        [Route("CreateMovie")]
        public async Task<int> CreateMovie(MovieModel Movie)
        {
            return await _movieServiceAsync.CreateMovieAsync(Movie);
        }
    }
}
