using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScrapTrack.Data.Models;
using System;

namespace ScrapTrack.Data.DataAccess
{
    public class DataDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Transaction_Details> Transaction_Details { get; set; }

        public DataDbContext(DbContextOptions<DataDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
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
            base.OnModelCreating(builder);
            this.SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            ApplicationUser devUser = new ApplicationUser()
            {
                UserName = "dev",
                NormalizedUserName = "dev".ToUpperInvariant().Normalize(),
                FirstName = "Dev",
                LastName = "Team"
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            devUser.PasswordHash = passwordHasher.HashPassword(devUser, "aldojo");

            builder.Entity<ApplicationUser>().HasData(devUser);
        }


    }
}
