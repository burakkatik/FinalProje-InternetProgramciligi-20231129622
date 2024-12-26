using Microsoft.AspNetCore.Identity;

namespace AnketPortali.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
