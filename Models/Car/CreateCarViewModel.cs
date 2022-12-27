using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Car
{
    public class CreateCarViewModel
    {
        [Required]
        public string Name { get; set; }
        
        public string Model { get; set; }
     
        public string Color { get; set; }

        public string Year { get; set; }
        [Required]
        [Range(0, 1000)]
        public string Price { get; set; }
        
        public string Description { get; set; }
        [Range(0, 3)]
        [Required]
        public List<SelectListItem> Engine { get; set; }
       
        public int HorsePower { get; set; }
    
    }
}
