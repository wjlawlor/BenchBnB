using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchBnB.Models
{
    public class Bench
    {
        public Bench() { }

        public Bench(int id, string name, int seats, string description, decimal latitude, decimal longitude, User user)
        {
            Id = id;
            Name = name;
            Seats = seats;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;

            User = user;
            DateDiscovered = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public string Description { get; set; }
        
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime DateDiscovered { get; set; }

        public List<Review> Reviews { get; set; }
    
        //ImageMethod()

        public decimal? Rating
        {
            get {
                if (Reviews.Count > 0)
                {
                    int sum = 0;
                    foreach (var review in Reviews)
                    {
                        sum += review.Rating;
                    }
                    return sum / Reviews.Count;
                }
                return null;
            }
        }
    }
}
