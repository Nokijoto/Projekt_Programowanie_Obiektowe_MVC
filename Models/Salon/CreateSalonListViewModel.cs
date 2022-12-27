using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt_MVC.Models.Salon
{
    public class CreateSalonListViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpenHours { get; set; }
        public string OpenDays { get; set; }
    }
}
