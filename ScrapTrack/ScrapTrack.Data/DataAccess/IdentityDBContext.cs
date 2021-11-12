using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapTrack.Data.DataAccess
{
    public class IdentityDBContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options)
        : base(options)
        {
        }
    }
}
