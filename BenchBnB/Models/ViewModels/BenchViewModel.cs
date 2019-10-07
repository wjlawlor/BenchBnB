﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenchBnB.Models.ViewModels
{
    public class BenchViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [Display(Name = "Average Rating")]
        public string AverageRating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime DateDiscovered { get; set; }

        public List<Review> Reviews { get; set; }
        public List<User> Users { get; set; }
    }
}