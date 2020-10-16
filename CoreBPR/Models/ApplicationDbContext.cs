using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreBPR.Models;

namespace CoreBPR.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationInitial> ApplicationInitials { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<RefGroup> RefGroups { get; set; }
        public DbSet<RefUnit> RefUnits { get; set; }
        public DbSet<RefProvince> RefProvinces { get; set; }
        public DbSet<RefCity> RefCities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
