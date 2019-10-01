using BenchBnB.Data;
using BenchBnB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchBnB.Repositories
{
    public class UserRepository
    {
        private Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}