using Microsoft.AspNetCore.Mvc;

namespace Projekt_MVC.Controllers
{
    public class SalonListController : Controller
    {
        private readonly ILogger<SalonListController> _logger;

        public SalonListController(ILogger<SalonListController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
