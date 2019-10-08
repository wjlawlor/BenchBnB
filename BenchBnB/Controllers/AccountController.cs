using BenchBnB.Data;
using BenchBnB.Models;
using BenchBnB.Models.ViewModels;
using BenchBnB.Repositories;
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

            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                bool goodLogin = userRepo.LoginUser(viewModel.Email, viewModel.Password);

                if (goodLogin)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                    return RedirectToAction("Index", "Bench");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong username or password.");
                }
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
            }

            if (ModelState.IsValid)
            {
                if (ModelState.IsValidField("Email") && ModelState.IsValidField("FirstName")
                    && ModelState.IsValidField("LastName") && ModelState.IsValidField("Password"))
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(viewModel.Password, 12);

                    User newUser = new User(0, viewModel.FirstName, viewModel.LastName, viewModel.Email, hashedPassword);
                    userRepo.Insert(newUser);

                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                    return RedirectToAction("Index", "Bench");
                }
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