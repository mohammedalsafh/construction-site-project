using System.Diagnostics; 
using Microsoft.AspNetCore.Identity; 
using CPIS_358_project.Models; 
using Microsoft.AspNetCore.Mvc; 

namespace CPIS_358_project.Controllers 
{
    public class HomeController : Controller//this is the main controller that will handle the home pages
    {
        public IActionResult Index()//this is the function that runs when someone visits the home page
        {
            if (User.Identity.IsAuthenticated)//this will check if the user is currently logged in
            {
                SetCookies("userName", User.Identity.Name);//if they are then we save their name in a cookie so we remember them
            }
            else// if they are not logged in
            {
                SetCookies("userName", "guest");//then we just save them as a guest in the cookies
            }

            return View();//this will show the home page view to the user
        }

        public IActionResult About()//this is the function that runs when someone clicks on about us
        {
            return View();//this will return the about us page view
        }


        public IActionResult ProductInfo()//this is the function that runs when someone clicks on product information page
        {
            return View();//this will return the product info page view
        }


        public IActionResult Services()//this is the function that runs when someone clicks on services
        {
            return View();//this will return the services page view
        }


        public IActionResult Contact()//this is the function that runs when someone clicks on contact us page
        {
            return View();//this will return the contact page view
        }


        public IActionResult Login()//this is the function that runs when someone clicks on login page
        {
            return View();//this will return the login page view
        }

        public IActionResult SignUp()//this is the function that runs when someone clicks on sign up page 
        {
            return View();//this will return the sign up page view
        }

        [HttpPost]
        public IActionResult SignUp(User user)//this will handle the actual sign up data when the user click on submit
        {
            if (String.IsNullOrEmpty(user.FullName) || String.IsNullOrEmpty(user.Email))//this will check if the name or email is empty
            {
                return View();//if something is missing then we show the form again so they can fix it
            }


            return RedirectToAction(nameof(Store));//if everything is good we send them directly to the store page
        }

        public IActionResult ForgotPassword()//this is the function that runs when someone clicks on forgot password page
        {
            return View();//this will return the forgot password page view
        }


        public IActionResult Store()//this function will handles the request for the store page
        {
            return View();//this will return the store page view
        }


        public IActionResult Payment()//this is the function that runs when someone clicks on payment page
        {
            return View();//this will return the payment page view
        }

        //setting up the cookies
        public IActionResult SetCookies(string cookieName, string cookieValue)//creating a helper function to make the cookies for us
        {
            CookieOptions options = new CookieOptions//we set up the rules for how this cookie behaves
            {
                Expires = DateTime.Now.AddDays(1),//make the cookie expire in exactly one day
                HttpOnly = true,//make sure the cookie cant be accessed by client side scripts for safety
                Secure = true,//make sure the cookie only works on secure connections
            };
            Response.Cookies.Append(cookieName, cookieValue);//adding the cookie to the response so the browser saves it
            return Ok();//return ok status to say that the cookie was set successfully
        }
    }
}