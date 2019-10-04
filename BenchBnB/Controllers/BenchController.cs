using BenchBnB.Data;
using BenchBnB.Models;
using BenchBnB.Models.ViewModels;
using BenchBnB.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BenchBnB.Controllers
{
    public class BenchController : Controller
    {
        private Context context;

        public BenchController()
        {
            context = new Context();
        }

        public ActionResult Index()
        {
            UserRepository userRepo = new UserRepository(context);
            List<User> users = userRepo.GetUsers();
            BenchRepository benchRepo = new BenchRepository(context);
            List<Bench> benches = benchRepo.GetBenches();

            //AllLists allLists = new AllLists();
            //allLists.Users = users;
            //allLists.Benches = benches;

            return View("Index", benches);
        }

        [Authorize]
        public ActionResult Add(decimal? lat, decimal? lon)
        {
            var viewModel = new Bench();

            if (lat.HasValue && lon.HasValue)
            {
                viewModel.Latitude = lat.Value;
                viewModel.Longitude = lon.Value;
            }
            return View("Add", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(Bench bench)
        {
            UserRepository userRepo = new UserRepository(context);
            User user = userRepo.GetUserByEmail(User.Identity.Name);

            BenchRepository benchRepo = new BenchRepository(context);

            if (ModelState.IsValid)
            {
                Bench newBench = new Bench(0, bench.Name, bench.Seats, bench.Description, bench.Latitude, bench.Longitude, user);
                benchRepo.Insert(newBench);

                return RedirectToAction("Index", "Home", null);
            }

            return View("Create", bench);
        }

        public ActionResult View(int? id)
        {
            if (id == null) { return RedirectToAction("Index"); }

            BenchRepository benchRepo = new BenchRepository(context);
            Bench bench = benchRepo.GetBenchById(id.Value);

            if (bench == null) { return RedirectToAction("Index"); }

            ReviewRepository reviewRepo = new ReviewRepository(context);
            List<Review> reviews = reviewRepo.GetReviewsByBench(id.Value);

            UserRepository userRepo = new UserRepository(context);
            List<User> users = userRepo.GetUsers();

            var viewModel = new BenchViewModel();
            viewModel.Id = bench.Id;
            viewModel.Name = bench.Name;
            viewModel.Seats = bench.Seats;
            viewModel.Description = bench.Description;
            viewModel.DateDiscovered = bench.DateDiscovered;
            viewModel.Latitude = bench.Latitude;
            viewModel.Longitude = bench.Longitude;
            viewModel.Reviews = reviews;
            viewModel.Users = users;

            return View("View", viewModel);
        }
    }
}
