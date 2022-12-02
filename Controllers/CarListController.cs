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
            _CarService = carService;
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
        public IActionResult CreateNewCar(int id, string name, string city, EngineEnum gender)
        {
            _personService.CreatePerson(id, name, city, gender);
            return RedirectToAction("Index");
        }
    }
}
