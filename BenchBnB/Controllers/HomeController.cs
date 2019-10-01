using BenchBnB.Data;
using BenchBnB.Models;
using BenchBnB.Models.ViewModels;
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
            UserRepository userRepo = new UserRepository(context);
            List<User> users = userRepo.GetUsers();

            BenchRepository benchRepo = new BenchRepository(context);
            List<Bench> benches = benchRepo.GetBenches();

            ReviewRepository reviewRepo = new ReviewRepository(context);
            List<Review> reviews = reviewRepo.GetReviews();

            AllLists allLists = new AllLists();
            allLists.Users = users;
            allLists.Benches = benches;
            allLists.Reviews = reviews;

            return View("Index", allLists);
        }
    }
}
