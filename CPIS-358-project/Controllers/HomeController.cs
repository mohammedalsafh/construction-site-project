using System.Diagnostics;
using CPIS_358_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPIS_358_project.Controllers
{
    public class HomeController : Controller
    {
        // Corresponds to HomePage.html
        public IActionResult Index()
        {
            return View();
        }

        // Corresponds to about.html
        public IActionResult About()
        {
            return View();
        }

        // Corresponds to product info.html
        public IActionResult ProductInfo()
        {
            return View();
        }
        // Corresponds to Services.html
        public IActionResult Services()
        {
            return View();
        }

        // Corresponds to contact.html
        public IActionResult Contact()
        {
            return View();
        }

        // Corresponds to log-in.html
        public IActionResult Login()
        {
            return View();
        }

        // Corresponds to sign-up.html (You didn't upload this, but I see it linked)
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (String.IsNullOrEmpty(user.FullName) || String.IsNullOrEmpty(user.UserE))
            {
                return View();
            }


            return RedirectToAction(nameof(Login));
        }
        // Corresponds to forgotPass.html
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // Corresponds to storePage.html (You didn't upload this, but it is linked)
        public IActionResult Store()
        {
            return View();
        }
        // Corresponds to payment.html
        public IActionResult Payment()
        {
            return View();
        }
    }
}
