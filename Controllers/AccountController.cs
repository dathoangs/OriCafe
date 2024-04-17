using OriCafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnonymousForum.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        public OriCafeContext db;

        public AccountController (ILogger<AccountController> logger)
        {
            _logger = logger;
            db = new OriCafeContext();
        }
        public ActionResult Index()
        {
            return View();
        }        

        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            var userData = db.TaiKhoans;
            bool isValidUser = false;

            foreach (TaiKhoan taiKhoan in userData){
                if(username == taiKhoan.TenTaiKhoan && password == taiKhoan.MatKhau){
                    isValidUser = true;
                    ViewBag.taiKhoan = taiKhoan;
                }     
            }

            if (isValidUser)
            {
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("Username", username);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return RedirectToAction("Index", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            // HttpContext.Session.Remove("IsAuthenticated");
            // ViewBag.taiKhoan = null;
            return RedirectToAction("Index", "Account");
        }
    }
}
