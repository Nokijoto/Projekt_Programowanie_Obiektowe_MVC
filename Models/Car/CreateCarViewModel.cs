using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Car
{

    [Keyless]
    
    public class CreateCarViewModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(50, ErrorMessage = "Nazwa auta nie może byc dłuższa niż 50 znaków.")]
        [Display(Name = "Nazwa Auta")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^{3,50}", ErrorMessage = "Nazwa auta musi zaczynać się wielką literą")]
        [MinLength(3, ErrorMessage = "Nazwa nie może być krótsza niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 liter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwa modelu jest wymagana")]
        [StringLength(50, ErrorMessage = "Nazwa modelu nie może byc dłuższa niż 50 znaków.")]
        [Display(Name = "Model")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^{3,50}", ErrorMessage = "Nazwa modelu musi zaczynać się wielką literą")]
        [MinLength(3, ErrorMessage = "Nazwa modelu nie może być krótsza niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Nazwa modelu nie może być dłuższa niż 50 liter")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Kolor jest wymagany")]
        [StringLength(50, ErrorMessage = "Kolor nie może byc dłuższy niż 50 znaków.")]
        [Display(Name = "Kolor")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^{3,50}", ErrorMessage = "Kolor musi zaczynać się wielką literą")]
        [MinLength(3, ErrorMessage = "Kolor nie może być krótszy niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Kolor nie może być dłuższy niż 50 liter")]

        public string Color { get; set; }

        [Required(ErrorMessage = "Rok jest wymagany")]
        [Display(Name = "Year")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{4,4}", ErrorMessage = "Rok musi składać się z 4 cyfr")]
        [MinLength(4, ErrorMessage = "Rok nie może być krótszy niż 4 cyfry")]
        [MaxLength(4, ErrorMessage = "Rok nie może być dłuższy niż 4 cyfry")]

        public string Year { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Display(Name = "Price")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{0,50}", ErrorMessage = "Price must be numbers")]
        
        public string Price { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        [StringLength(50, ErrorMessage = "Opis nie może byc dłuższy niż 50 znaków.")]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^{3,50}", ErrorMessage = "Opis musi zaczynać się wielką literą")]
        [MinLength(3, ErrorMessage = "Opis nie może być krótszy niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Opis nie może być dłuższy niż 50 liter")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Engine is required.")]
       // [Display(Name = "Engine")]
        
        public List<SelectListItem> Engine { get; set; }


        [Required(ErrorMessage = "Silnik jest wymagany")]
        [Display(Name = "HorsePower")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{1,3}", ErrorMessage = "Ilość koni musi składać się z 1-3 cyfr i być z przedziału 1-1000")]

        [Range(10, 1000)]
        public int HorsePower { get; set; }
    
    }
}
