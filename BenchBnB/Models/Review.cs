using System;

namespace BenchBnB.Models
{
    public class Review
    {
        public Review() { }

        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BenchId { get; set; }
        public Bench Bench { get; set; }

        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
