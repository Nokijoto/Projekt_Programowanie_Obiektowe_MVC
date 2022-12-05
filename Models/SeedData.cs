using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Context;

namespace Projekt_MVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MainContext(serviceProvider.GetRequiredService<DbContextOptions<MainContext>>()))
            {
                if (context.Cars.Any())
                {
                    return;
                }
                context.Cars.AddRange(
                    new CarModel()
                    {
                        ID = 1,
                        Name="Aston",
                        Model = "Martin",
                        Color = "Black",
                        Year = "2019",
                        Price = " 100000",
                        Description = "This is a Aston Martin",
                        Engine = EngineEnum.Petrol,
                        HorsePower = 500
                        
                    }
                   
                );
                context.SaveChanges();
            }
        }
    }
}