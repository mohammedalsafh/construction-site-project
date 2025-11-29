using System.Diagnostics;
using CPIS_358_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPIS_358_project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
    }
}
