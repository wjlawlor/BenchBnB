using BenchBnB.Data;
using BenchBnB.Models;
using BenchBnB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BenchBnB.Controllers
{
    public class HomeController : Controller
    {
        private Context context;

        public HomeController()
        {
            context = new Context();
        }

        public ActionResult Index()
        {
            BenchRepository repo = new BenchRepository(context);
            List<User> users = repo.GetUsers();

            return View("Index", users);
        }
    }
}
