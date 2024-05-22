using GraphQLMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLMVC.Data
{
    public class CarvedRockDbContext : DbContext
    {
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}
