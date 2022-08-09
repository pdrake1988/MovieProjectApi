using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
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
        [Route("GetAllCastsMembers")]
        public async Task<IEnumerable<CastModel>> GetAllCastsMembers()
        {
            return await _castService.GetCastsAsync();
        }

        [HttpGet]
        [Route("GetCastMemberById/{id}")]
        public async Task<CastModel> GetCastMemberById(int id)
        {
            return await _castService.GetCastAsync(id);
        }

        [HttpPost]
        [Route("AddCastMember/{CastMember}")]
        public async Task<int> AddCastMember(CastModel castMember)
        {
            return await _castService.CreateCastMemberAsync(castMember);
        }
    }
}
