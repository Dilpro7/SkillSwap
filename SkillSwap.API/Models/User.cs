using Microsoft.AspNetCore.Identity;

namespace SkillSwap.API.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}