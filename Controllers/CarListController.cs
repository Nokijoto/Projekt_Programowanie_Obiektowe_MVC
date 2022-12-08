using Projekt_MVC.Services;
using Projekt_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Policy;

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
        public IActionResult DeleteCar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _CarService.DeleteCar(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditCar(int id, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            if (id == null)
            {
                return NotFound();
            }
            _CarService.EditCar(id, name, model, color, year, price, description, engine, horsePower);
            return RedirectToAction("EditCar");
        }
        //if (id == null)
        //{
        //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //}
        //Movie movie = db.Movies.Find(id);
        //if (movie == null)
        //{
        //    return HttpNotFound();
        //}


    }
}
