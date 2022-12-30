using Projekt_MVC.Context;
using Projekt_MVC.Models.Car;

namespace Projekt_MVC.Services.Car
{
    public class CarService : ICarService
    {
        private readonly MainContext _CarService;
        public CarService(MainContext context)
        {
            _CarService = context;
        }
        public List<CarModel> GetCars()
        {
            return _CarService.Cars.ToList();
        }
        public bool CreateCar(string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            var lastId = _CarService.Cars.OrderByDescending(x => x.CarID).FirstOrDefault()?.CarID;
            if (lastId != null)
            {
                var newCar = new CarModel()
                {
                    CarID = (int)lastId+1,
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
                return true;
            }
            return false;
        }
        public async void DeleteCar(int id)
        {

            CarModel Car;
            var cart = _CarService.Cars.Find(id);
            Car = cart;
            if (Car != null)
            {
                _CarService.Cars.Remove(Car);
                _CarService.SaveChanges();
            }
            
        }

        public CarModel GetCar(int id)
        {
            return _CarService.Cars.FirstOrDefault(x => x.CarID == id) ?? new CarModel();
        }

        public bool EditCar(long CarID, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            var Car = _CarService.Cars.FirstOrDefault(x => x.CarID == CarID);
            if(Car!=null)
            {
                Car.Name = name;
                Car.Model = model;
                Car.Color = color;
                Car.Year = year;
                Car.Price = price;
                Car.Description = description;
                Car.Engine = engine;
                Car.HorsePower = horsePower;
                _CarService.Update(Car);
                _CarService.SaveChanges();
               return true;
            }
            return false;
        }
    }
}
