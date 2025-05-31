using Microsoft.AspNetCore.Identity;

namespace API.DATA.Models.Response
{
    public class Role : IdentityRole
    {
        public int? SecurityLvl { get; set; } = null;
    }
}
