using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Models.Car;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
