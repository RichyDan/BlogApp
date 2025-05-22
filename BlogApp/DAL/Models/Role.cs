using Microsoft.AspNetCore.Identity;

namespace BlogApp.DAL.Models
{
    public class Role : IdentityRole
    {
        public int? SecurityLvl { get; set; } = null;
    }
}
