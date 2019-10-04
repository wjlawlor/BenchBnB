using Newtonsoft.Json;
using System.Collections.Generic;

namespace BenchBnB.Models
{
    public class User
    {
        public User() { }

        public User(int id, string firstName, string lastName, string email, string hashedPassword)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HashedPassword = hashedPassword;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        [JsonIgnore]
        public List<Bench> Benches { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
