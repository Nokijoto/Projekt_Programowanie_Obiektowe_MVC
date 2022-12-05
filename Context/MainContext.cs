using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Models;
namespace Projekt_MVC.Context
{
    public class MainContext : DbContext
    {

        public MainContext(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<CarModel> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
