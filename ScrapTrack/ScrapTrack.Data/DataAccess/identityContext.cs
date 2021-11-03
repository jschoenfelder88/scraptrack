using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapTrack.Data.DataAccess
{
    public class identityContext : IdentityDbContext<AppUser>
    {
        public identityContext(DbContextOptions<identityContext> options)
        : base(options)
        {
        }
    }
}
