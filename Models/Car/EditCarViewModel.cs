using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;



namespace Projekt_MVC.Models.Car
{
    [Keyless]
    public class EditCarViewModel
    {
        public int CarID { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(50, ErrorMessage = "Nazwa auta nie może byc dłuższa niż 50 znaków.")]
        [Display(Name = "Firma")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Nazwa auta musi zaczynać się wielką literą")]
        [MinLength(3, ErrorMessage = "Nazwa nie może być krótsza niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 liter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwa modelu jest wymagana")]
        [StringLength(50, ErrorMessage = "Nazwa modelu nie może byc dłuższa niż 50 znaków.")]
        [Display(Name = "Model")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Nazwa modelu musi zaczynać się wielką literą")]
        [MinLength(3, ErrorMessage = "Nazwa modelu nie może być krótsza niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Nazwa modelu nie może być dłuższa niż 50 liter")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Kolor jest wymagany")]
        [StringLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 znaków.")]
        [Display(Name = "Kolor")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z\s]*$", ErrorMessage = "Kolor musi zaczynać się wielką literą oraz składć się z liter")]
        [MinLength(3, ErrorMessage = "Nazwa nie może być krótsza niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 liter")]

        public string Color { get; set; }

        [Required(ErrorMessage = "Rok jest wymagany")]
        [Display(Name = "Rok produkcji")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[\d0-9]{4,4}", ErrorMessage = "Rok musi składać się z 4 cyfr")]
        [MinLength(4, ErrorMessage = "Rok nie może być krótszy niż 4 cyfry")]
        [MaxLength(4, ErrorMessage = "Rok nie może być dłuższy niż 4 cyfry")]

        public string Year { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Display(Name = "Cena")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[\d0-9]{0,50}", ErrorMessage = "Cena musi być cyframi")]

        public string Price { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        [StringLength(50, ErrorMessage = "Opis nie może byc dłuższy niż 50 znaków.")]
        [Display(Name = "Opis")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]{3,50}$", ErrorMessage = "Opis musi zaczynać się wielką literą")]
        [MinLength(3, ErrorMessage = "Opis nie może być krótszy niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Opis nie może być dłuższy niż 50 liter")]
        public string Description { get; set; }


        public List<SelectListItem> Engine { get; set; }


        [Required(ErrorMessage = "Silnik jest wymagany")]
        [Display(Name = "Moc silnika w KM")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[\d0-9]{2,3}", ErrorMessage = "Ilość koni musi składać się z 2-3 cyfr i być z przedziału 10-1000")]

        [Range(10, 1000, ErrorMessage = "Ilość koni musi być z przedziału 10-1000")]
        public int HorsePower { get; set; }


    }
}
