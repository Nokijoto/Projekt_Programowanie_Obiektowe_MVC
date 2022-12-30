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
                return StatusCode((int)HttpStatusCode.NotAcceptable, e.Message);
            }
            
        }
        
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
            
        }

        
        public IActionResult EditCar(int id)
        {
            try
            {
                var car = _CarService.GetCar(id);
                var model = new EditCarViewModel()
                {
                    CarID = car.CarID,
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
                

                return View(model);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        public IActionResult EditCarDetails(long CarID, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {

            _CarService.EditCar(CarID, name, model, color, year, price, description, engine, horsePower);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> GetCarsListJson()
        {
            try
            {
                var model = new CarViewModel()
                {
                    Cars = _CarService.GetCars()
                };
                return Json(model);
            }
            catch (Exception e)
            {
                return Json(new { Status = "Get Failed", ErrorMessage = e.Message });
            }
            
           
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCarJson(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Niepoprawne ID");
                   
                    
                }
                _CarService.DeleteCar(id);
                return Json(new { Status = "Delete Succesfull"});
            }
            catch (Exception e)
            {
                return Json(new { Status = "Delete Failed", ErrorMessage = e.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateCarJson(string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
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
                    return Json(new { Status = "Add Succesfull" });

                }
                else
                {
                    throw new Exception("Model is invalid");

                }
            }
            catch (Exception e)
            {
                return Json(new { Status = "Add Failed", ErrorMessage = e.Message });
            }
        }
        [HttpPut]
        public async Task<ActionResult> EditCarJson(long CarID, string name, string model, string color, string year, string price, string description, EngineEnum engine, int horsePower)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Int32.Parse(price) <= 0)
                    {
                        throw new Exception("Cena nie mniejsza niż 0");
                    }
                    if (_CarService.EditCar(CarID, name, model, color, year, price, description, engine, horsePower))
                    {

                        return Json(new { Status = "Edit Succesfull" });
                    }
                    else
                    {
                        throw new Exception("Bład edycji auta");
                    }
                }
                else
                {
                    throw new Exception("Model is invalid");
                }
            }
            catch (Exception e)
            {
                return Json(new { Status = "Edit Failed", ErrorMessage = e.Message });
            }
        }
    }
}
