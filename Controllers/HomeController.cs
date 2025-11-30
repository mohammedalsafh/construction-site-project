using System.Diagnostics;
using CPIS_358_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using CPIS_358_project.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CPIS_358_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() {
            //create session ID.

           SetSession("id",Guid.NewGuid().ToString());

            //Checks if user is authenticated.
            if (User.Identity.IsAuthenticated)
            {
                SetCookies("username", User.Identity.Name);
                SetSession("username", User.Identity.Name);
            }
            else
            {
                SetCookies("username", "guest");
                SetSession("username", "guest");
            }
            return View();
        }

        public IActionResult Signup() { return View(); }
        public IActionResult Login() { return View(); }
        public IActionResult ForgotPassword() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(User user)
        {

            var existingUser = _context.Users.FirstOrDefault(u => u.UserE == user.UserE);

            if (existingUser != null)
            {

                ModelState.AddModelError("UserE", "This email is already registered.");
                return View(user);
            }

            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetString("username", user.UserE);
                return RedirectToAction("Store");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Login(User userLogin)
        {
            //Ignore Name/Phone validation for login
            ModelState.Remove("FullName");
            ModelState.Remove("PhoneNumber");

            if (ModelState.IsValid)
            {
                var userFound = _context.Users
                    .FirstOrDefault(u => u.UserE == userLogin.UserE && u.UserP == userLogin.UserP);

                if (userFound != null)
                {
                    //start Session
                    HttpContext.Session.SetString("username", userFound.UserE);
                    return RedirectToAction("Store");
                }
                else
                {
                    ViewBag.Error = "Invalid Email or Password";
                }
            }
            return View(userLogin);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var userToUpdate = _context.Users.FirstOrDefault(u => u.UserE == model.UserE);

                if (userToUpdate != null)
                {
                    userToUpdate.UserP = model.NewP;
                    _context.Update(userToUpdate);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("UserE", "Email not found.");
                }
            }
            return View(model);
        }

        public IActionResult Logout()//will implement later
        {
            HttpContext.Session.Clear();//destroy the session
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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


        public IActionResult Store()
        {
            return View();
        }


        public IActionResult Payment()
        {
            return View();
        }

        [Authorize]
        public IActionResult SetCookies(string cookieName, string cookieValue)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(10),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
            };
            Response.Cookies.Append(cookieName, cookieValue, options);
            return Ok("Cookies has been set.");
        }
        [Authorize]
        public IActionResult SetSession(string sessionId, string value)
        {
            HttpContext.Session.SetString(sessionId, value);
            return RedirectToAction("Index");
        }
    }
}