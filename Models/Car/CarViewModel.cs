using Microsoft.EntityFrameworkCore;

namespace Projekt_MVC.Models.Car
{
   
    public class CarViewModel
    {
        public CarViewModel()
        { }
       
        public List<CarModel> Cars { get; set; }
    }
}
