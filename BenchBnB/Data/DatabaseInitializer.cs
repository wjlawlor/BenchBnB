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
                HashedPassword = "$2a$12$L73qjlARoiJwj1ZSrrS0xewkBQcmRBqbLW0UFPa6a1bweJwwUPel2"
            };
            context.Users.Add(mo);
            var jason = new User()
            {
                FirstName = "Jason",
                LastName = "Lu",
                Email = "jlu@gmail.com",
                HashedPassword = "$2a$12$L73qjlARoiJwj1ZSrrS0xewkBQcmRBqbLW0UFPa6a1bweJwwUPel2"
            };
            context.Users.Add(jason);

            // Benches
            var bench1 = new Bench()
            {
                Name = "First Bench",
                Seats =  2,
                Description = "The first bench in the entire world.",
                Latitude = 40.7891m,
                Longitude = -73.1450m,
                User = mo,
                DateDiscovered = new DateTime(2019, 10, 1)

            };
            context.Benches.Add(bench1);
            var bench2 = new Bench()
            {
                Name = "Giga Bench",
                Seats = 8,
                Description = "A chonk, for sure.",
                Latitude = 40.7891m,
                Longitude = -73.1350m,
                User = jason,
                DateDiscovered = new DateTime(2019, 9, 29)

            };
            context.Benches.Add(bench2);
            var bench3 = new Bench()
            {
                Name = "Average Bench",
                Seats = 4,
                Description = "Nothing to see here.",
                Latitude = 40.8256m,
                Longitude = -73.1028m,
                User = jason,
                DateDiscovered = new DateTime(2019, 9, 29)

            };
            context.Benches.Add(bench3);
            var bench4 = new Bench()
            {
                Name = "Not A Bench",
                Seats = 0,
                Description = "How is this even allowed?",
                Latitude = 40.7891m,
                Longitude = -73.1330m,
                User = mo,
                DateDiscovered = new DateTime(2019, 9, 29)

            };
            context.Benches.Add(bench4);
            var bench5 = new Bench()
            {
                Name = "TSM Bench",
                Seats = 8,
                Description = "Akkadian, Grig.",
                Latitude = 40.7891m,
                Longitude = -73.1380m,
                User = jason,
                DateDiscovered = new DateTime(2019, 9, 1)

            };
            context.Benches.Add(bench5);
            var bench6 = new Bench()
            {
                Name = "The Last Bench",
                Seats = 3,
                Description = "But not least.",
                Latitude = -35.3213m,
                Longitude = 33.45234m,
                User = mo,
                DateDiscovered = new DateTime(2019, 9, 29)

            };
            context.Benches.Add(bench6);

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