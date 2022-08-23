using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreServiceAsync _genreService;

        public GenreController(IGenreServiceAsync genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllGenres")]
        public async Task<IActionResult> GetAllGenres()
        {
            var result = await _genreService.GetAllGenresAsync();
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("GetGenreById/{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var result = await _genreService.GetGenreByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [Route("CreateGenre")]
        public async Task<int> CreateGenre(GenreModel genre)
        {
            return await _genreService.CreateGenreAsync(genre);
        }
    }
}
