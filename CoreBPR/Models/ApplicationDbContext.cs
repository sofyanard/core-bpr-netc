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
        public DbSet<RefMenu> RefMenus { get; set; }
        public DbSet<RefGroupMenu> RefGroupMenus { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<RefGroup> RefGroups { get; set; }
        public DbSet<RefUnit> RefUnits { get; set; }
        public DbSet<RefProvince> RefProvinces { get; set; }
        public DbSet<RefCity> RefCities { get; set; }
        public DbSet<RefGender> RefGenders { get; set; }
        public DbSet<RefHomeStatus> RefHomeStatuses { get; set; }
        public DbSet<RefMarital> RefMaritals { get; set; }
        public DbSet<RefCitizen> RefCitizens { get; set; }
        public DbSet<RefEducation> RefEducations { get; set; }
        public DbSet<RefJenisIdentity> RefJenisIdentities { get; set; }
        public DbSet<RefYesNo> RefYesNos { get; set; }
        public DbSet<RefJenisBadanUsaha> RefJenisBadanUsahas { get; set; }
        public DbSet<RefBidangUsaha> RefBidangUsahas { get; set; }
        public DbSet<RefJobType> RefJobTypes { get; set; }
        public DbSet<RefSourceIncome> RefSourceIncomes { get; set; }
        public DbSet<RefGolonganNasabah> RefGolonganNasabahs { get; set; }
        public DbSet<RefHubunganBank> RefHubunganBanks { get; set; }
        public DbSet<RefLembagaRating> RefLembagaRatings { get; set; }
        public DbSet<Nasabah> Nasabahs { get; set; }
        public DbSet<RefCIFGenerator> RefCIFGenerators { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<CoreBPR.Models.NasabahJobnSpouse> NasabahJobnSpouse { get; set; }
    }
}
