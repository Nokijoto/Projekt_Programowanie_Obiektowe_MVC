using Projekt_MVC.Models;
namespace Projekt_MVC.Services
{
    public interface ICarService
    {
        public List<CarModel> GetCars();
        public void CreateCar(int id, string name, string city, EngineEnum gender);
    }
}
