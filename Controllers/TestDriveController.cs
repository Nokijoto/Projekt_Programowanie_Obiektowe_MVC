using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_MVC.Services.TestDrive;
using Projekt_MVC.Models.TDriveModel;

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
            var model = new TestDriveViewModel()
            {
                TestDrives = _TestDriveService.GetTestDrives()
            };
            return View(model);

        }

        public IActionResult NewTestDrive()
        {
            var model = new CreateTestDriveViewModel();
            return View(model);
        }

        public IActionResult CreateNewTestDrive(string imie, string nazwisko, string pesel, string data, int nrtel)
        {
            _TestDriveService.CreateTestDrive(imie, nazwisko, pesel, data, nrtel);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTestDrive(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _TestDriveService.DeleteTestDrive(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditTestDrive(int id)
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
        public IActionResult EditTestDriveDetails(long id, string imie, string nazwisko, string pesel, string data, int nrtel)
        {
            _TestDriveService.EditTestDrive(id, imie, nazwisko, pesel, data, nrtel); 
            return RedirectToAction("Index");
        }
    }
}
