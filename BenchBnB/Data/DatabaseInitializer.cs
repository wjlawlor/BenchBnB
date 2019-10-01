using BenchBnB.Models;
using System;
using System.Data.Entity;

namespace BenchBnB.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            // Users
            var mo = new User()
            {
                FirstName = "Mo",
                LastName = "Salam",
                Email = "msalam@gmail.com",
                Password = "password"
            };
            context.Users.Add(mo);
            var jason = new User()
            {
                FirstName = "Jason",
                LastName = "Lu",
                Email = "jlu@gmail.com",
                Password = "password"
            };
            context.Users.Add(jason);

            // Benches
            var bench1 = new Bench()
            {
                Name = "First Bench",
                Seats =  2,
                Description = "The first bench in the entire world.",
                Latitude = 72.02134m,
                Longitude = 44.45249m,
                User = mo,
                DateDiscovered = new DateTime(2019, 10, 1)

            };
            context.Benches.Add(bench1);
            var bench2 = new Bench()
            {
                Name = "Giga Bench",
                Seats = 8,
                Description = "A chonk, for sure.",
                Latitude = 42.02134m,
                Longitude = 102.45243m,
                User = jason,
                DateDiscovered = new DateTime(2019, 9, 29)

            };
            context.Benches.Add(bench2);

            // Reviews
            var review1 = new Review()
            {   
                User = mo,
                Bench = bench1,
                Description = "I found this bench.",
                Rating = 5,
                DateCreated = new DateTime(2019, 10, 1)
            };
            context.Reviews.Add(review1);
            var review2 = new Review()
            {
                User = mo,
                Bench = bench2,
                Description = "Jason's bench isnt a cool as mine.",
                Rating = 1,
                DateCreated = new DateTime(2019, 10, 1)
            };
            context.Reviews.Add(review2);
            var review3 = new Review()
            {
                User = jason,
                Bench = bench1,
                Description = "Mo's bench is ight.",
                Rating = 3,
                DateCreated = new DateTime(2019, 9, 30)
            };
            context.Reviews.Add(review3);

            // Commit Data
            context.SaveChanges();
        }
    }
}