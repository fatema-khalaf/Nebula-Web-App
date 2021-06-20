using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nebula.Areas.Identity.Data;
using Nebula.Models;

namespace Nebula.Data
{
    public class NebulaContext : IdentityDbContext<NebulaUser>
    {
        public NebulaContext(DbContextOptions<NebulaContext> options)
            : base(options)
        {
        }
        // adding each table to the database
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Attachments> Attachments { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
