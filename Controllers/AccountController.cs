using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace CPIS_358_project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.sessionId = HttpContext.Session.GetString("id");
            ViewBag.sessionUserName = HttpContext.Session.GetString("username");
            return View();
        }
    }
}
