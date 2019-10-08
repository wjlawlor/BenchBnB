using System;

namespace BenchBnB.Models.DTOs
{
    public class BenchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public string Description { get; set; }
        public decimal? AverageRating { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public User User { get; set; }

        public DateTime DateDiscovered { get; set; }
    }
}
