using Projekt_MVC.Models;
using Projekt_MVC.Context;
namespace Projekt_MVC.Services
{
    public class CarService : ICarService
    {
        private readonly MainContext _context;
        public CarService(MainContext context)
        {
            _context = context;
        }
        public List<CarModel> GetCars()
        {
            return _context.Cars.ToList();
        }
        public void CreateCar(int id, string name, string city, EngineEnum gender)
        {
            _context.Cars.Add(new CarModel()
            {
                ID = id,
                Name = name,
                City = city,
                Gender = gender
            });
            _context.SaveChanges();
        }
    }
}
