﻿using System.ComponentModel.DataAnnotations;

namespace BenchBnB.Models.ViewModels
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}