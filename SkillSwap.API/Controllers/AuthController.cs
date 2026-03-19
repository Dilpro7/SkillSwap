using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.API.DTOs.Auth;
using SkillSwap.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDTO dto)
    {
        var result = await _service.Register(dto);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDTO dto)
    {
        var result = await _service.Login(dto);
        return Ok(result);
    }

    [Authorize]

    [HttpGet("test")]
    public IActionResult Test()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok(new
        {
            message = "Authorized",
            userId = userId
        });
    }


}