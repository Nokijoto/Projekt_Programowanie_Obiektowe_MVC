using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Context;
using Projekt_MVC.Models.Car;
using Projekt_MVC.Models.TDriveModel;

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
                        Name = "Aston",
                        Model = "Martin",
                        Color = "Black",
                        Year = "2019",
                        Price = " 100000",
                        Description = "This is a Aston Martin",
                        Engine = EngineEnum.Petrol,
                        HorsePower = 500

                    });


                    if (context.TestDrives.Any())
                {
                    return;
                }
                context.TestDrives.AddRange(
                    new TestDriveModel()
                    {
                        ID = 1,
                        Imie = "Robret",
                        Nazwisko = "Makłowicz",
                        Pesel = "00000000000",
                        Data = "12-12-2022",
                        NrTel = 123456789,
                    }

                );
                context.SaveChanges();
            }
        }
    }
}