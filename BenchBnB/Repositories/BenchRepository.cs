using BenchBnB.Data;
using BenchBnB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchBnB.Repositories
{
    public class BenchRepository
    {
        private Context _context;
        public BenchRepository(Context context)
        {
            _context = context;
        }

        public List<Bench> GetBenches()
        {
            return _context.Benches.ToList();
        }

        public Bench GetBenchById(int id)
        {
            return _context.Benches.SingleOrDefault(b => b.Id == id);
        }

        public void Insert(Bench bench)
        {
            _context.Benches.Add(bench);
            _context.SaveChanges();
        }
    }
}
