using Microsoft.AspNetCore.Mvc;
using System.Net;

using Projekt_MVC.Models.Car;
using Projekt_MVC.Services.Car;
using Microsoft.AspNetCore.Mvc.Rendering;


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
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                
                var model = new CarViewModel()
                {
                    Cars = _CarService.GetCars()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting cars");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
           
           
        }
        [HttpPost]
        public IActionResult NewCar()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new CreateCarViewModel()
                    {
                        Engine = new List<SelectListItem>()
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
                else
                {
                    return View();
                }
              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting cars");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
           
        }
        [HttpPost]
        public IActionResult CreateNewCar( string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Int32.Parse(price) <= 0)
                    {
                        throw new Exception("Cena nie mniejsza niż 0");
                    }
                    _CarService.CreateCar(name, model, color, year, price, description, engine, horsePower);
                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("NewCar");

                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        //if (horsePower < 0)
            //        //{
            //        //    ModelState.AddModelError("horsePower", "Horse power cannot be negative");
            //        //    return View("NewCar");
            //        //}
            //        //if (year.Length >= 4)
            //        //{
            //        //    ModelState.AddModelError("year", "Year must be 4 digits");
            //        //    return View("NewCar");
            //        //}
            //        //if (price.Length < 3)
            //        //{
            //        //    ModelState.AddModelError("price", "Price must be at least 3 digits");
            //        //    return View("NewCar");
            //        //}
            //        //if (description.Length < 10)
            //        //{
            //        //    ModelState.AddModelError("description", "Description must be at least 10 characters");
            //        //    return View("NewCar");
            //        //}
            //        //if (name.Length < 3)
            //        //{
            //        //    ModelState.AddModelError("name", "Name must be at least 3 characters");
            //        //    return View("NewCar");
            //        //}
            //        //if (model.Length < 3)
            //        //{
            //        //    ModelState.AddModelError("model", "Model must be at least 3 characters");
            //        //    return View("NewCar");
            //        //}
            //        //if (color.Length < 3)
            //        //{
            //        //    ModelState.AddModelError("color", "Color must be at least 3 characters");
            //        //    return View("NewCar");
            //        //}


            //        _CarService.CreateCar(name, model, color, year, price, description, engine, horsePower);
            //        return RedirectToAction("Index");

            //    }
            //    else
            //    {
            //        return View("NewCar");

            //    }
            //    //_CarService.CreateCar(name, model, color, year, price, description, engine, horsePower);
            //    //return RedirectToAction("Index");
            //}
         
           
            //_CarService.CreateCar (name, model, color,year,price,description, engine, horsePower);
            //return RedirectToAction("Index");
        }
        [HttpDelete]
        public IActionResult DeleteCar(int id)
        {
            try
            {
                _CarService.DeleteCar(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //_CarService.DeleteCar(id);
            //return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult EditCar(int id)
        {
            try
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
                        Value = item.ToString()
                    });
                }
                //foreach (var item in Enum.GetValues(typeof(EngineEnum)))
                //{
                //    model.Engine.Add(new SelectListItem()
                //    {
                //        Text = item.ToString(),
                //        Value = item.ToString(),
                //        Selected = item.ToString() == car.Engine.ToString()
                //    });
                //}

                return View(model);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPost]
        public IActionResult EditCarDetails(long id, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {

            _CarService.EditCar(id, name, model, color, year, price, description, engine, horsePower);
            return RedirectToAction("Index");
        }



    }
}
