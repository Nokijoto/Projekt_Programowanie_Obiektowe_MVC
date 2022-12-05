using Projekt_MVC.Services;
using Projekt_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Projekt_MVC.Controllers
{
    public class CarListController : Controller
    {
        private readonly ILogger<CarListController> _logger;
        private readonly ICarService _CarService;
        public CarListController(ILogger<CarListController> logger, ICarService CarService)
        {
            _logger = logger;
            _CarService = CarService;
        }
        public IActionResult Index()
        {
            var model = new CarViewModel()
            {
                Cars = _CarService.GetCars()
            };
            return View(model);
           
        }
        public IActionResult NewCar()
        {
            return View();
        }
        public IActionResult CreateNewCar(int id, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            _CarService.CreateCar(id, name, model, color,year,price,description, engine, horsePower);
            return RedirectToAction("Index");
        }
    }
}
