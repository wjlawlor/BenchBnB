using BenchBnB.Data;
using BenchBnB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BenchBnB.Repositories
{
    public class ReviewRepository
    {
        private Context _context;
        public ReviewRepository(Context context)
        {
            _context = context;
        }

        public List<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }
    }
}