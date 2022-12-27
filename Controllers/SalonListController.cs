using Microsoft.AspNetCore.Mvc;
using Projekt_MVC.Services.SalonList;
using Projekt_MVC.Models.Salon;

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
        public IActionResult DeleteSalon(int id)
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
            var S = _SalonListService.GetSalons(id);
            var model = new EditSalonModel()
            {
                ID = S.ID,
                Name = S.Name,
                Address = S.Address,
                Phone = S.Phone,
                Email = S.Email,
                OpenHours = S.OpenHours,
                OpenDays = S.OpenDays,
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
