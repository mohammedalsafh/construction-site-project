using Microsoft.AspNetCore.Identity;

namespace CPIS_358_project.Models
{
    public class User : IdentityUser
    {
        public required string FullName { get; set; }
        
    }
}
