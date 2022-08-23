using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly ICastServiceAsync _castService;

        public CastController(ICastServiceAsync castService)
        {
            _castService = castService;
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllCastMembers")]
        public async Task<IEnumerable<CastModel>> GetAllCastMembers()
        {
            return await _castService.GetCastAsync();
        }

        [HttpGet]
        [Authorize]
        [Route("GetCastMemberById/{id}")]
        public async Task<CastModel> GetCastMemberById(int id)
        {
            return await _castService.GetCastMemberAsync(id);
        }

        [HttpPost]
        [Authorize]
        [Route("AddCastMember/{CastMember}")]
        public async Task<int> AddCastMember(CastModel castMember)
        {
            return await _castService.CreateCastMemberAsync(castMember);
        }
    }
}
