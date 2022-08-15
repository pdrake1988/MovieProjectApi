using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repository;

public class AccountRepositoryAsync : IAccountRepositoryAsync
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountRepositoryAsync(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public Task<IdentityResult> RegisterUserAsync(SignUpModel user)
    {
        var newUser = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.Email
        };
        return _userManager.CreateAsync(newUser, user.Password);
    }

    public Task<SignInResult> LoginUserAsync(SignInModel user)
    {
        return _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);
    }
}
