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

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
