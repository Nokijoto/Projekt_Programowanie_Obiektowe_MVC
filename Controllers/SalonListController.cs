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
            try
            {
                var model = new SalonListViewModel()
                {
                    GetSalons = _SalonListService.GetSalons()
                };
               
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }


        }

        public IActionResult NewSalon()
        {
            try
            {
                var model = new CreateSalonListViewModel();
                return View(model);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
    }

        public IActionResult CreateNewSalon(string name, string address, string phone, string email, string openhours, string opendays)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _SalonListService.CreateSalon(name, address, phone, email, openhours, opendays);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception("Invalid model state");
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }
        public IActionResult DeleteSalonList(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                _SalonListService.DeleteSalon(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
      
        }

        public IActionResult EditSalonList(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }
        public IActionResult EditSalonDetails(long id, string name, string address, string phone, string email, string openhours, string opendays)
        {
            try
            {
                _SalonListService.EditSalonList(id, name, address, phone, email, openhours, opendays);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
         
        }

        [HttpGet]
        public async Task<ActionResult> GetSalonListJSON()
        {
            try
            {
                var model = new SalonListViewModel()
                {
                    GetSalons = _SalonListService.GetSalons()
                };
                return Json(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteSalonJSON(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                _SalonListService.DeleteSalon(id);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateNewSalonJSON(string name, string address, string phone, string email, string openhours, string opendays)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _SalonListService.CreateSalon(name, address, phone, email, openhours, opendays);
                    return Json(new { Success = true });
                }
                else
                {
                    throw new Exception("Invalid model state");
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpPut]
        public async Task<ActionResult> EditSalonDetailsJSON(long id, string name, string address, string phone, string email, string openhours, string opendays)
        {
            try
            {
                _SalonListService.EditSalonList(id, name, address, phone, email, openhours, opendays);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing salons");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
