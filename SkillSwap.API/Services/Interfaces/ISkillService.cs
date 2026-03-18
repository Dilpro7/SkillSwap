using SkillSwap.API.DTOs.Skill;

namespace SkillSwap.API.Services.Interfaces
{
    public interface ISkillService
    {
        Task AddSkillAsync(SkillCreateDTO dto, string userId);
        Task<List<SkillResponseDTO>> GetAllSkillsAsync();
        Task<List<SkillResponseDTO>> GetMySkillsAsync(string userId);
        Task DeleteSkillAsync(int skillId, string userId);
    }
}
