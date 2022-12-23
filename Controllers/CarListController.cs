using Microsoft.AspNetCore.Mvc;
using System.Net;
<<<<<<< HEAD
using System.Security.Policy;
=======
using Projekt_MVC.Models.Car;
using Projekt_MVC.Services.Car;
using Microsoft.AspNetCore.Mvc.Rendering;
>>>>>>> master

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
            var model = new CreateCarViewModel()
            {
                Engine = new List<SelectListItem>()
         {
                      new SelectListItem() { Text = "Diesel", Value = "Diesel" },
                      new SelectListItem() { Text = "Benzyna", Value = "Benzyna" },
                      new SelectListItem() { Text = "Elektryczny", Value = "Elektryczny" },
                      new SelectListItem() { Text = "Hybryda", Value = "Hybryda" },
                 }
                
                   
            };

            foreach (var item in Enum.GetValues(typeof(EngineEnum)))
            {
                model.Engine.Add(new SelectListItem()
                {
                    Text = item.ToString(),
                    Value = item.ToString()
                });
            }
            return View(model);
        }
        public IActionResult CreateNewCar( string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            _CarService.CreateCar (name, model, color,year,price,description, engine, horsePower);
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
<<<<<<< HEAD

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
=======
       
        public IActionResult EditCar(int id)
        {
            var car = _CarService.GetCar(id);
            var model = new EditCarViewModel()
            {
                ID = car.ID,
                Name = car.Name,
                Model = car.Model,
                Color = car.Color,
                Year = car.Year,
                Price = car.Price,
                Description = car.Description,
                Engine = new List<SelectListItem>(),
                HorsePower = car.HorsePower
            };
            foreach (var item in Enum.GetValues(typeof(EngineEnum)))
            {
                model.Engine.Add(new SelectListItem()
                {
                    Text = item.ToString(),
                    Value = item.ToString(),
                    Selected = item.ToString() == car.Engine.ToString()
                });
            }

            return View(model);
        }
        public IActionResult EditCarDetails(long id, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            _CarService.EditCar(id, name, model, color, year, price, description, engine, horsePower);
            return RedirectToAction("Index");
        }
>>>>>>> master


    }
}
