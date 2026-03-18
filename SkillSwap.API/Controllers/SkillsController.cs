using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.API.DTOs.Skill;
using SkillSwap.API.Services.Interfaces;
using System.Security.Claims;

namespace SkillSwap.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _service;

        public SkillsController(ISkillService service)
        {
            _service = service;
        }

        // 🔐 Add Skill
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddSkill([FromBody] SkillCreateDTO dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized(new { success = false, message = "Invalid token" });

            await _service.AddSkillAsync(dto, userId);

            return StatusCode(201, new
            {
                success = true,
                message = "Skill added successfully"
            });
        }

        // 🌍 Get All Skills
        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var data = await _service.GetAllSkillsAsync();

            return Ok(new
            {
                success = true,
                data
            });
        }

        // 👤 Get My Skills
        [Authorize]
        [HttpGet("my")]
        public async Task<IActionResult> GetMySkills()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized(new { success = false, message = "Invalid token" });

            var data = await _service.GetMySkillsAsync(userId);

            return Ok(new
            {
                success = true,
                data
            });
        }

        // ❌ Delete Skill
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized(new { success = false, message = "Invalid token" });

            await _service.DeleteSkillAsync(id, userId);

            return Ok(new
            {
                success = true,
                message = "Skill deleted successfully"
            });
        }
    }
}
