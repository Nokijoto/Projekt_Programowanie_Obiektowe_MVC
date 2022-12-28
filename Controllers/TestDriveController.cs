using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_MVC.Services.TestDrive;
using Projekt_MVC.Models.TDriveModel;
using Projekt_MVC.Models.Car;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Projekt_MVC.Controllers

{
    public class TestDriveController : Controller
    {
        private readonly ILogger<TestDriveController> _logger;
        private readonly ITestDriveService _TestDriveService;
        public TestDriveController(ILogger<TestDriveController> logger, ITestDriveService TestDriveService)
        {
            _logger = logger;
            _TestDriveService = TestDriveService;
        }
        public IActionResult Index()
        {
            try
            {
                var model = new TestDriveViewModel()
                {
                    TestDrives = _TestDriveService.GetTestDrives()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
          

        }

        public IActionResult NewTestDrive()
        {
            try
            {
               
                var model = new CreateTestDriveViewModel();
                return View(model);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }

        public IActionResult CreateNewTestDrive(string imie, string nazwisko, string pesel, string data, int nrtel)
        {
            try
            {
                var dataNowa = DateTime.Parse(data);
                var now = DateTime.Now;
                //if (dataNowa < now)
                //{
                //    throw new Exception("Data nie może być wcześniejsza niż dzisiejsza");
                //}

                _TestDriveService.CreateTestDrive(imie, nazwisko, pesel, data, nrtel);
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
                };


                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }
        public IActionResult EditTestDriveDetails(long id, string imie, string nazwisko, string pesel, string data, int nrtel)
        {
            try
            {
                _TestDriveService.EditTestDrive(id, imie, nazwisko, pesel, data, nrtel);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }
    }
}
