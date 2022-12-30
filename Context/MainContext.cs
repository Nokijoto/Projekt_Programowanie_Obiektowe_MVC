using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Models.Car;
using Projekt_MVC.Models.Salon;
using Projekt_MVC.Models.TDriveModel;

namespace Projekt_MVC.Context
{
    public class MainContext : DbContext
    {

        public MainContext(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<CarModel> Cars { get; set; }
        public DbSet<TestDriveModel> TestDrives { get; set; }
        public DbSet<SalonModel> Salons { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().ToTable("Cars");
            modelBuilder.Entity<TestDriveModel>().ToTable("TestDrives");
            modelBuilder.Entity<SalonModel>().ToTable("Salons");
        }


        
    }
}
