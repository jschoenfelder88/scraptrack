using Microsoft.EntityFrameworkCore;
using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapTrack.Data.DataAccess
{
    public class scrapskcContext : DbContext
    {
        public scrapskcContext(DbContextOptions options) : base(options) { }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
