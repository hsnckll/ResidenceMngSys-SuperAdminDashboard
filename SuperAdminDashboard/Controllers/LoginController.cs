using Microsoft.AspNetCore.Mvc;
using SuperAdminDashboard.Models;

namespace SuperAdminDashboard.Controllers
{
    public class LoginController : Controller
    {

        private readonly AppDbContext db;

        public LoginController(AppDbContext db)
        {
            this.db = db;
        }



        public IActionResult LoginPage()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Login(string mail, string password, int rolId)
        {
            var girisyapankisi = db.Users.FirstOrDefault(x => x.Mail == mail && x.Password == password);

            if (girisyapankisi == null)
            {
                TempData["Error"] = "Geçersiz kullanıcı adı veya şifre.";
                return View("LoginPage");
            }

            var girisyapankisininRolu = db.UserRoles.FirstOrDefault(x => x.User_Id == girisyapankisi.Id);

            if (girisyapankisininRolu.Roles_Id == 3)
            {
                return RedirectToAction("Dashboard", "SuperAdmin");

            }
            else
            {
                TempData["Error"] = "Sadece SuperAdmin giriş yapabilir.";
                return View("LoginPage");
            }

        }






    }
}
