namespace SkillSwap.API.Models
{
    public class Skill
    {
        public int SkillId { get; set; }

        public string SkillName { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }   // From Identity

        public User User { get; set; }
    }
}
