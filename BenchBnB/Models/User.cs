using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenchBnB.Models
{
    public class User
    {
        public User()
        {
            List<Bench> benches = new List<Bench>();
            List<Review> reviews = new List<Review>();
        }

        public User(int id, string firstName, string lastName, string email, string hashedPassword)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HashedPassword = hashedPassword;
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }

        [JsonIgnore]
        public List<Bench> Benches { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
