using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Salon
{
    [Keyless]
    public class CreateSalonListViewModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(50, ErrorMessage = "Nazwa Salonu nie poprawna.")]
        [Display(Name = "Nazwa")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^{3,50}$", ErrorMessage = "Nazwa Salonu nie jest poprawna.")]
        [MinLength(3, ErrorMessage = "Nazwa musi zawierać conajmniej 3 znaki")]
        [MaxLength(50, ErrorMessage = "Nazwa może zawierać najwięcej 50 znaków")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany")]
        [StringLength(50, ErrorMessage = "Adres nie poprawny.")]
        [Display(Name = "Adres")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^{3,50}$", ErrorMessage = "Adres nie jest poprawny.")]
        [MinLength(3, ErrorMessage = "Adres musi mieć conajmniej 3 znaki")]
        [MaxLength(50, ErrorMessage = "Adres musi mieć najwiecej 50 znaków")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Numer telefonu jesat wymagany")]
        [StringLength(9, ErrorMessage = "Telefon musi składać się z 9 cyfr")]
        [Display(Name = "NrTelefonu")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{9,9}$", ErrorMessage = "Telefon musi składać się z 9 cyfr")]
        [MinLength(9, ErrorMessage = "Telefon musi składać się z 9 cyfr")]
        [MaxLength(9, ErrorMessage = "Telefon musi składać się z 9 cyfr")]

        public string Phone { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Email nie jest poprawny")]
        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Godziny otwarcia są wymagane")]
        [StringLength(50, ErrorMessage = "Godziny otwarcia są nie poprawne.")]
        [Display(Name = "Godziny Otwarcia")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9-]{3,50}$", ErrorMessage = "Godziny otwarcia powinny mieć następujący format 8-16")]
        public string OpenHours { get; set; }

        [Required(ErrorMessage = "Dni otwarcia są wymagane")]
        [StringLength(50, ErrorMessage = "Dni otwarcia są nie poprawne.")]
        [Display(Name = "Dni otwarcia")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^{3,50}$", ErrorMessage = "Dni otwarcia powinny mieć następujący format pn-pt")]

        public string OpenDays { get; set; }
    }
}
