﻿using System.Collections.Generic;

namespace BenchBnB.Models
{
    public class User
    {
        public User() { }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Bench> Benches { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
