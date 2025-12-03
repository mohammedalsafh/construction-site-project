using Microsoft.AspNetCore.Mvc; 

namespace CPIS_358_project.Controllers 
{
    //this controller is made so that we handle everything related to the user account page 
    public class AccountController : Controller
    {
        //when we call this it return the index view for the account
        public IActionResult Index()//we create the function for the index page
        {
            return View();//this will show the actual page to the user
        }
    }
}