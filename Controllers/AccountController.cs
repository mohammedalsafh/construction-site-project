using Microsoft.AspNetCore.Mvc;

namespace CPIS_358_project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
