using Microsoft.AspNetCore.Identity;
namespace CPIS_358_project.Models
{
    public class User : IdentityUser//creating user class it connects to IdentityUser so we get all the built in stuff like email and password automatically
    {
        public required string FullName { get; set; }//we added this variable because the default user doesnt have a name field
        //required means it has to be filled

    }
}