using SkillSwap.API.Models;
using SkillSwap.API.Repositories.Interfaces;

namespace SkillSwap.API.Repositories.Implementations
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _context;

        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddSkillAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Skill>> GetAllSkillsAsync()
        {
            return await _context.Skills
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<List<Skill>> GetUserSkillsAsync(string userId)
        {
            return await _context.Skills
                .Where(s => s.UserId == userId)
                .ToListAsync();
        }

        public async Task DeleteSkillAsync(int skillId, string userId)
        {
            var skill = await _context.Skills
                .FirstOrDefaultAsync(s => s.SkillId == skillId && s.UserId == userId);

            if (skill == null)
                throw new Exception("Skill not found or unauthorized");

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }
    }
}
