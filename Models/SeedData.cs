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
                        Name = "Andrzej",
                        City = "Rzeszów",
                        Gender = EngineEnum.Petrol,
                        ID = 1
                    },
                    new CarModel()
                    {
                        Name = "Katarzyna",
                        City = "Rzeszów",
                        Gender = EngineEnum.Petrol,
                        ID = 2
                    },
                    new CarModel()
                    {
                        Name = "Julia",
                        City = "Kraków",
                        Gender = EngineEnum.Petrol,
                        ID = 3
                    },
                    new CarModel()
                    {
                        Name = "Piotr",
                        City = "Warszawa",
                        Gender = EngineEnum.Petrol,
                        ID = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}