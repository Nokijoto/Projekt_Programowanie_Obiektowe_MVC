using Microsoft.AspNetCore.Mvc;

namespace Projekt_MVC.Controllers
{
    public class CarListController : Controller
    {
        private readonly ILogger<CarListController> _logger;

        public CarListController(ILogger<CarListController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
