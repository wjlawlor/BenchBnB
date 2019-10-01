using BenchBnB.Data;
using BenchBnB.Models;
using BenchBnB.Models.ViewModels;
using BenchBnB.Repositories;
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

            AllLists allLists = new AllLists();
            allLists.Users = users;
            allLists.Benches = benches;

            return View("Index", allLists);
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
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
    }
}
