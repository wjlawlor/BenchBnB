using BenchBnB.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BenchBnB.Context
{
    public class Context : DbContext
    {
        //public Context() : base("name=BenchBnB")
        //{
        //    Database.SetInitializer<Context>(null);
        //}

        public DbSet<User> Users { get; set; }
        //public DbSet<Bench> Benches { get; set; }
        //public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}