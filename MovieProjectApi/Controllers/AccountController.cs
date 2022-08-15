using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MovieProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepositoryAsync _accountRepository;
        private readonly IConfiguration _configuration;

        public AccountController(
            IAccountRepositoryAsync accountRepository,
            IConfiguration configuration
        )
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> SignUpAsync(SignUpModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _accountRepository.RegisterUserAsync(model);
            if (result.Succeeded)
            {
                return Ok(new { message = "User created successfully" });
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description);
                }
                return BadRequest(new { message = sb.ToString() });
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(SignInModel model)
        {
            var result = await _accountRepository.LoginUserAsync(model);
            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.Country, "USA"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"])
            );
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    authSigningKey,
                    SecurityAlgorithms.HmacSha256Signature
                )
            );
            var authToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = authToken });
        }
    }
}
