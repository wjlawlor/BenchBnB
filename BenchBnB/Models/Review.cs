using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace BenchBnB.Models
{
    public class Review
    {
        public Review() { }

        public Review(int id, User user, Bench bench, int rating, string description)
        {
            Id = id;
            User = user;
            Bench = bench;
            Rating = rating;
            Description = description;

            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BenchId { get; set; }
        [JsonIgnore]
        public Bench Bench { get; set; }

        [Required]
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
