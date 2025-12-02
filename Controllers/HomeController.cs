using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using CPIS_358_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPIS_358_project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                SetCookies("userName", User.Identity.Name);
            }
            else
            {
                SetCookies("userName", "guest");
            }

                return View();
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult ProductInfo()
        {
            return View();
        }


        public IActionResult Services()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (String.IsNullOrEmpty(user.FullName) || String.IsNullOrEmpty(user.Email))
            {
                return View();
            }


            return RedirectToAction(nameof(Store));
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }


        public IActionResult Store()
        {
            return View();
        }


        public IActionResult Payment()
        {
            return View();
        }

        //setting up cookies
        public IActionResult SetCookies(string cookieName, string cookieValue)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true,
                Secure = true,
            };
            Response.Cookies.Append(cookieName, cookieValue);
            return Ok();
        }
    }
}