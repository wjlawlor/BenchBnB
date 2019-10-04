using BenchBnB.Data;
using BenchBnB.Models;
using BenchBnB.Repositories;
using System.Web.Mvc;

namespace BenchBnB.Controllers
{
    public class ReviewController : Controller
    {
        private Context context;

        public ReviewController()
        {
            context = new Context();
        }

        [Authorize]
        public ActionResult Add(int? id)
        {
            if (id == null) { return RedirectToAction("Index", "Bench", null); }

            BenchRepository benchRepo = new BenchRepository(context);
            UserRepository userRepo = new UserRepository(context);

            var viewModel = new Review();
            viewModel.Bench = benchRepo.GetBenchById(id.Value);
            viewModel.User = userRepo.GetUserByEmail(User.Identity.Name);

            return View("Add", viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(Review review)
        {
            UserRepository userRepo = new UserRepository(context);
            User user = userRepo.GetUserByEmail(User.Identity.Name);
            BenchRepository benchRepo = new BenchRepository(context);
            Bench bench = benchRepo.GetBenchById(review.Id);
            ReviewRepository reviewRepo = new ReviewRepository(context);



            if (ModelState.IsValid)
            {
                Review newReview = new Review(0, user, bench, review.Rating, review.Description);
                reviewRepo.Insert(newReview);

                return RedirectToAction("View", "Bench", new { id = review.Id });
            }

            return View("Add", review);
        }
    }
}