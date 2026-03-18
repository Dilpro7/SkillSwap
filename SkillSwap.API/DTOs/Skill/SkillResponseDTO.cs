namespace SkillSwap.API.DTOs.Skill
{
    public class SkillResponseDTO
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }

        public int SkillLevel { get; set; } 
    }
}
