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

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
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
                if (BCrypt.Net.BCrypt.Verify(password, user.HashedPassword))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
