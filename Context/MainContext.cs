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
        }


        public DbSet<Projekt_MVC.Models.Car.CreateCarViewModel> CreateCarViewModel { get; set; }


        public DbSet<Projekt_MVC.Models.Car.EditCarViewModel> EditCarViewModel { get; set; }


        public DbSet<Projekt_MVC.Models.Salon.CreateSalonListViewModel> CreateSalonListViewModel { get; set; }


        public DbSet<Projekt_MVC.Models.Salon.EditSalonModel> EditSalonModel { get; set; }


        public DbSet<Projekt_MVC.Models.TDriveModel.CreateTestDriveViewModel> CreateTestDriveViewModel { get; set; }


        public DbSet<Projekt_MVC.Models.TDriveModel.EditTestDriveModel> EditTestDriveModel { get; set; }
    }
}
