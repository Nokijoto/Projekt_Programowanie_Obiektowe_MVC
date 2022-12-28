using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Context;
using Projekt_MVC.Models.Car;
using Projekt_MVC.Models.Salon;
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
                        Engine = 0,
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
                        Imie = "Robert",
                        Nazwisko = "Makłowicz",
                        Pesel = "00000000000",
                        Data = "12-12-2022",
                        NrTel = 123456789,
                    }

                );
                if (context.Salons.Any())
                {
                    return;
                }
                context.Salons.AddRange(
                   new SalonModel()
                   {
                       
                       ID=1,
                       Name = "Salon 1",
                       Address = "Adres 1",
                       Phone = "123456789",
                       OpenHours = "8:00 - 16:00",
                       OpenDays = "Poniedziałek - Piątek",
                       Email = "testemail"
                       
                   }

               );
                context.SaveChanges();
            }
        }
    }
}