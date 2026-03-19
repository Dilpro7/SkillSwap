using SkillSwap.API.Models;

namespace SkillSwap.API.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<User> GetUserByEmail(string email);
}