using BenchBnB.Data;
using BenchBnB.Models;
using BenchBnB.Models.ViewModels;
using BenchBnB.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace BenchBnB.Controllers
{
    public class AccountController : Controller
    {
        private Context context;

        public AccountController()
        {
            context = new Context();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var viewModel = new Login();
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login viewModel)
        {
            UserRepository userRepo = new UserRepository(context);
            bool goodLogin = userRepo.LoginUser(viewModel.Email, viewModel.Password);

            if (goodLogin)
            {
                FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }
    }
}