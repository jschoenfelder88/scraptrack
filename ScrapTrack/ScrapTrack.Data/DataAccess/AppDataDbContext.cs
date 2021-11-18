using Microsoft.EntityFrameworkCore;
using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapTrack.Data.DataAccess
{
    public class AppDataDbContext : DbContext
    {
        public AppDataDbContext(DbContextOptions<AppDataDbContext> options) : base(options) { }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Description = "Clothing"
                },
                new Category
                {
                    Id = 2,
                    Description = "Survival"
                },
                new Category
                {
                    Id = 3,
                    Description = "Food"
                },
                new Category
                {
                    Id = 4,
                    Description = "none"
                }
            );
        }
    }
}
