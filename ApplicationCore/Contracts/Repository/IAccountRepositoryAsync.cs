using ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Contracts.Repository;

public interface IAccountRepositoryAsync
{
    Task<IdentityResult> RegisterUserAsync(SignUpModel user);
    Task<SignInResult> LoginUserAsync(SignInModel user);
}
