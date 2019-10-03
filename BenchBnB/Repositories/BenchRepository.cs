using BenchBnB.Data;
using BenchBnB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BenchBnB.Repositories
{
    public class BenchRepository : IBenchRepository
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

        async public Task<List<Bench>> GetBenchList()
        {
            using (var context = new Context())
            {
                return await context.Benches.ToListAsync();
            }
        }
    }
}
