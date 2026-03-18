using SkillSwap.API.DTOs.Skill;
using SkillSwap.API.Models;
using SkillSwap.API.Repositories.Interfaces;
using SkillSwap.API.Services.Interfaces;

namespace SkillSwap.API.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repo;

        public SkillService(ISkillRepository repo)
        {
            _repo = repo;
        }

        public async Task AddSkillAsync(SkillCreateDTO dto, string userId)
        {
            var skill = new Skill
            {
                SkillName = dto.SkillName,
                Description = dto.Description,
                UserId = userId
            };

            await _repo.AddSkillAsync(skill);
        }

        public async Task<List<SkillResponseDTO>> GetAllSkillsAsync()
        {
            var skills = await _repo.GetAllSkillsAsync();

            return skills.Select(s => new SkillResponseDTO
            {
                SkillId = s.SkillId,
                SkillName = s.SkillName,
                Description = s.Description,
                UserName = s.User?.UserName
            }).ToList();
        }

        public async Task<List<SkillResponseDTO>> GetMySkillsAsync(string userId)
        {
            var skills = await _repo.GetUserSkillsAsync(userId);

            return skills.Select(s => new SkillResponseDTO
            {
                SkillId = s.SkillId,
                SkillName = s.SkillName,
                Description = s.Description
            }).ToList();
        }

        public async Task DeleteSkillAsync(int skillId, string userId)
        {
            await _repo.DeleteSkillAsync(skillId, userId);
        }
    }
}
