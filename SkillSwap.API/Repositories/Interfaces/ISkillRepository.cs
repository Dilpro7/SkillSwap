using SkillSwap.API.Models;

namespace SkillSwap.API.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task AddSkillAsync(Skill skill);
        Task<List<Skill>> GetAllSkillsAsync();
        Task<List<Skill>> GetUserSkillsAsync(string userId);
        Task DeleteSkillAsync(int skillId, string userId);
    }
}
