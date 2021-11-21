using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScrapTrack.Data.Models;
using System;

namespace ScrapTrack.Data.DataAccess
{
    public class AuthorizationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
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
