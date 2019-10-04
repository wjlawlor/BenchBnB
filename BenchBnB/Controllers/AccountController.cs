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
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel viewModel)
        {
            UserRepository userRepo = new UserRepository(context);
            bool goodLogin = userRepo.LoginUser(viewModel.Email, viewModel.Password);

            if (goodLogin)
            {
                FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                return RedirectToAction("Index", "Bench");
            }

            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var viewModel = new RegisterViewModel();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            UserRepository userRepo = new UserRepository(context);
            User doesUserExist = userRepo.GetUserByEmail(viewModel.Email);

            if (doesUserExist != null)
            {
                ModelState.AddModelError("","Email already exists.");
                return View(viewModel);
            }

            if (ModelState.IsValid)
            {
                User newUser = new User(0, viewModel.FirstName, viewModel.LastName, viewModel.Email, viewModel.Password);
                userRepo.Insert(newUser);

                FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                return RedirectToAction("Index", "Bench");
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Bench");
        }
    }
}