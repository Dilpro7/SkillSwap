using SkillSwap.API.DTOs.Auth;

namespace SkillSwap.API.Services.Interfaces;

public interface IAuthService
{
    Task<string> Register(RegisterRequestDTO dto);
    Task<AuthResponseDTO> Login(LoginRequestDTO dto);
}

