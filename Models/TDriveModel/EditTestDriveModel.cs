using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Models.Car;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.TDriveModel
{
    [Keyless]
    public class EditTestDriveModel
    {

        public EditTestDriveModel()
        {

        }
        public int ID { get; set; }


        [Required(ErrorMessage = "Imie jest wymagane")]
        [Display(Name = "Imie")]
        [StringLength(50, ErrorMessage = "Imie nie może być dłuższe niż 50 znaków")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]{3,50}", ErrorMessage = "Imie musi mieć więcej niż 3 znaki")]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "Imie musi mieć minimum 3 znaki")]
        [MaxLength(50, ErrorMessage = "Imie nie może być dłuższe niż 50 znaków")]

        public string Imie { get; set; }


        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        [StringLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]{3,50}", ErrorMessage = "Nazwisko musi mieć więcej niż 3 znaki")]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "Nazwisko musi mieć minimum 3 znaki")]
        [MaxLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Pole Pesel jest wymagane")]
        [Display(Name = "Pesel")]
        [StringLength(11, ErrorMessage = "Pesel nie może być dłuższy niż 11 znaków")]
        [RegularExpression(@"^[\d0-9]{11}$", ErrorMessage = "Pesel może zawierać tylko cyfry oraz musi składać się z 11 cyfr")]
        [DataType(DataType.Text)]
        [MinLength(11, ErrorMessage = "Pesel musi mieć 11 znaków")]
        [MaxLength(11, ErrorMessage = "Pesel nie może być dłuższy niż 11 znaków")]

        public string Pesel { get; set; }

        [Required(ErrorMessage = "Pole Data jest wymagane")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^[\d0-9]{4}-[\d0-9]{2}-[\d0-9]{2}$", ErrorMessage = "Data musi być w formacie yyyy/mm/dd")]

        public string Data { get; set; }

        [Required(ErrorMessage = "Pole NrTel jest wymagane")]
        [Display(Name = "NrTel")]
        [StringLength(9, ErrorMessage = "NrTel nie może być dłuższy niż 9 znaków")]
        [RegularExpression(@"^(\d{3}-\d{3}-\d{3}|^\d{3}\d{3}\d{3})$", ErrorMessage = "Telefon musi być w formacie : 123-123-123 lub 123123123 ")]
        [DataType(DataType.Text)]
        [MinLength(9, ErrorMessage = "NrTel musi mieć 9 znaków")]
        [MaxLength(9, ErrorMessage = "NrTel nie może być dłuższy niż 9 znaków")]

        public int NrTel { get; set; }

        public int CarID { get; set; }
    }
}
