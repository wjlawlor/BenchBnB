using BenchBnB.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BenchBnB.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Bench> Benches { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Handle Cascading Delete; Inconsequential.
            modelBuilder.Entity<Review>()
                    .HasRequired(r => r.Bench)
                    .WithMany(b => b.Reviews)
                    .WillCascadeOnDelete(false);

            //
            modelBuilder.Entity<Bench>()
                .Property(p => p.Latitude)
                    .HasPrecision(20, 17);
            modelBuilder.Entity<Bench>()
                .Property(p => p.Longitude)
                    .HasPrecision(20, 17);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}