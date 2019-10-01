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

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool LoginUser(string email, string password)
        {
            User user = _context.Users.SingleOrDefault(u => u.Email == email);

            if (_context.Users.SingleOrDefault(u => u.Email == email) != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
