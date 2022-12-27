using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_MVC.Services.SalonList;
using Projekt_MVC.Models.Salon;
using System.Xml.Linq;

namespace Projekt_MVC.Controllers
{
    public class SalonListController : Controller
    {
        private readonly ILogger<SalonListController> _logger;
        private readonly ISalonListService _SalonListService;
        public SalonListController(ILogger<SalonListController> logger, ISalonListService salonListService)
        {
            _logger = logger;
            _SalonListService = salonListService;
        }
        public IActionResult Index()
        {
            var model = new SalonListViewModel()
            {
                GetSalons = _SalonListService.GetSalons()
            };
            return View(model);

        }

        public IActionResult NewSalon()
        {
            var model = new CreateSalonListViewModel();
            return View(model);
        }

        public IActionResult CreateNewSalon(string name, string address, string phone, string email, string openhours, string opendays)
        {
            _SalonListService.CreateSalon(name, address, phone, email, openhours, opendays);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSalonList(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _SalonListService.DeleteSalon(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditSalonList(int id)
        {
            var SL = _SalonListService.GetSalons(id);
            var model = new EditSalonModel()
            {
                ID = SL.ID,
                Name = SL.Name,
                Address = SL.Address,
                Phone = SL.Phone,
                Email = SL.Email,
                OpenHours = SL.OpenHours,
                OpenDays = SL.OpenDays,
            };


            return View(model);
        }
        public IActionResult EditSalonDetails(long id, string name, string address, string phone, string email, string openhours, string opendays)
        {
            _SalonListService.EditSalonList(id, name, address, phone, email, openhours, opendays);
            return RedirectToAction("Index");
        }


    }
}
