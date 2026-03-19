using Microsoft.AspNetCore.Identity;
using SkillSwap.API.Models;
using SkillSwap.API.Repositories.Interfaces;

namespace SkillSwap.API.Repositories.Implementations;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<User> _userManager;

    public AuthRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }
}