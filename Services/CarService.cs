using Projekt_MVC.Models;
using Projekt_MVC.Context;
using Projekt_MVC.Models.Car;
using Projekt_MVC.Services.Car;
namespace Projekt_MVC.Services
{
    public class CarService : ICarService
    {
        private readonly MainContext _CarService;
        public CarService(MainContext context)
        {
            _CarService = context;
        }
        //public List<CarModel> GetCars()
        //{
        //    return _context.Cars.ToList();
        //}

        // create function to get cars from database
        public List<CarModel> GetCars()
        {
            return _CarService.Cars.ToList();
        }
        public void CreateCar(int id, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            var newCar = new CarModel()
            {
                ID = id,
                Name = name,
                Model = model,
                Color = color,
                Year = year,
                Price = price,
                Description = description,
                Engine = engine,
                HorsePower = horsePower
            };
            _CarService.Cars.Add(newCar);
            _CarService.SaveChanges();
        }
        public async void DeleteCar(int id)
        {
           
            CarModel Car;
            var cart =_CarService.Cars.Find(id);
            Car = cart;
            if (Car != null)
            {
            _CarService.Cars.Remove(Car);
            _CarService.SaveChanges();
            }
        }
        public void EditCar(int id, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            var Car = _CarService.Cars.Find(id);
            if (Car != null)
            {
                Car.ID = id;
                Car.Name = name;
                Car.Model = model;
                Car.Color = color;
                Car.Year = year;
                Car.Price = price;
                Car.Description = description;
                Car.Engine = engine;
                Car.HorsePower = horsePower;
                _CarService.SaveChanges();
            }
        }

    }
}
