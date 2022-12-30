using Projekt_MVC.Models.Car;

namespace Projekt_MVC.Services.Car
{
    public interface ICarService
    {
        public List<CarModel> GetCars();
        public bool CreateCar( string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower);
        void DeleteCar(int id);
        public CarModel GetCar(int id);
        public bool EditCar(long CarID, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower);
       
    }
}
