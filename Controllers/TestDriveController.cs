using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_MVC.Services.TestDrive;
using Projekt_MVC.Models.TDriveModel;
using Projekt_MVC.Models.Car;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Projekt_MVC.Services.Car;

namespace Projekt_MVC.Controllers

{
    public class TestDriveController : Controller
    {
        private readonly ILogger<TestDriveController> _logger;
        private readonly ITestDriveService _TestDriveService;
        private readonly ICarService _carService;
        public TestDriveController(ILogger<TestDriveController> logger, ITestDriveService TestDriveService,ICarService carService)
        {
            _logger = logger;
            _TestDriveService = TestDriveService;
            _carService = carService;
        }
        public IActionResult Index()
        {
            try
            {
                var model = new TestDriveViewModel()
                {
                    TestDrives = _TestDriveService.GetTestDrives(),
                    
            };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
          

        }

        public IActionResult NewTestDrive(int CarID)
        {
            try
            {

                var model = new CreateTestDriveViewModel()
                {
                    CarID = CarID
                };
                
                return View(model);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }

        public IActionResult CreateNewTestDrive(string imie, string nazwisko, string pesel, string data, int nrtel, int CarID)
        {
            try
            {
               
                _TestDriveService.CreateTestDrive(imie, nazwisko, pesel, data, nrtel,CarID);
               return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
           
        }

       
        public IActionResult DeleteTestDrive(int id)
        {
            try 
            {
                
                if (id == null)
                {
                    return NotFound();
                }
                _TestDriveService.DeleteTestDrive(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }

        public IActionResult EditTestDrive(int id)
        {
            try
            {
               

                var TD = _TestDriveService.GetTestDrives(id);

                var model = new EditTestDriveModel()
                {
                    ID = TD.ID,
                    Imie = TD.Imie,
                    Nazwisko = TD.Nazwisko,
                    Pesel = TD.Pesel,
                    Data = TD.Data,
                    NrTel = TD.NrTel,
                    CarID = TD.CarID
                    
                };


                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }
        public IActionResult EditTestDriveDetails(long id, string imie, string nazwisko, string pesel, string data, int nrtel,int CarID)
        {
            try
            {
                _TestDriveService.EditTestDrive(id, imie, nazwisko, pesel, data, nrtel,CarID);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }


        [HttpGet]
        public async Task<ActionResult> GetTestDrivesJson()
        {
            var model = new TestDriveViewModel()
            {
                TestDrives = _TestDriveService.GetTestDrives()
            };
            return Json(model);
            //return Json(new { Data = model }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTestDriveJson(int id)
        {
            try
            {
                
                if (id == null || id <=0)
                {
                    throw new Exception("Niepoprawny ID");
                     
                    
                }
                _TestDriveService.DeleteTestDrive(id);
                return Json(new { Success = true });
            }
            catch (Exception e)
            {
                return Json(new { Error = "ID is null" ,StatusCode= StatusCode((int)HttpStatusCode.InternalServerError), ErrorM= e.Message
            });
            }

        }
        [HttpPost]
        public async Task<ActionResult> CreateTestDriveJson(int CarID,string imie, string nazwisko, string pesel, string data, int nrtel )
        {
            try
            {
                var dataNowa = DateTime.Parse(data);
                var now = DateTime.Now;
               
                //if (dataNowa < now)
                //{
                //    throw new Exception("Data nie może być wcześniejsza niż dzisiejsza");
                //}

                _TestDriveService.CreateTestDrive(imie, nazwisko, pesel, data, nrtel,CarID);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {

                return Json(new { Success = false, Rason = ex.Message });
            }
        }
        [HttpPut]
        public async Task<ActionResult> EditTestDriveJson(long id,string imie, string nazwisko, string pesel, string data, int nrtel, int CarID)
        {
            try
            {
                _TestDriveService.EditTestDrive(id, imie, nazwisko, pesel, data, nrtel,CarID);
                return Json(new { Success = true });
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Rason = e.Message });
            }
        }
    }
}
