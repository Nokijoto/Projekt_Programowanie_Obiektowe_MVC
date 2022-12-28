using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Models.Car;
using System;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.TDriveModel
{
    [Keyless]
    public class CreateTestDriveViewModel
    {
        private DateTime dateTime = DateTime.UtcNow.Date;
        private string date = DateTime.Now.ToString("yyyy-MM-dd");
       
        public int ID { get; set; }

        [Required(ErrorMessage = "Imie jest wymagane")]
        [Display(Name = "Imie")]
        [StringLength(50, ErrorMessage = "Imie nie może być dłuższe niż 50 znaków")]
        [RegularExpression(@"^{3,50}", ErrorMessage = "Imie musi zaczynać się wielką literą")]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "Imie musi mieć minimum 3 znaki")]
        [MaxLength(50, ErrorMessage = "Imie nie może być dłuższe niż 50 znaków")]

        public string Imie { get; set; }


        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        [StringLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków")]
        [RegularExpression(@"^{3,50}", ErrorMessage = "Nazwisko musi zaczynać się wielką literą")]
        [DataType(DataType.Text)]
        [MinLength(3, ErrorMessage = "Nazwisko musi mieć minimum 3 znaki")]
        [MaxLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Pole Pesel jest wymagane")]
        [Display(Name = "Pesel")]
        [StringLength(11, ErrorMessage = "Pesel nie może być dłuższy niż 11 znaków")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Pesel może zawierać tylko cyfry")]
        [DataType(DataType.Text)]
        [MinLength(11, ErrorMessage = "Pesel musi mieć 11 znaków")]
        [MaxLength(11, ErrorMessage = "Pesel nie może być dłuższy niż 11 znaków")]

        public string Pesel { get; set; }

        [Required(ErrorMessage = "Pole Data jest wymagane")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
       
        public string Data { get; set; }

        [Required(ErrorMessage = "Pole NrTel jest wymagane")]
        [Display(Name = "NrTel")]
        [StringLength(9, ErrorMessage = "NrTel nie może być dłuższy niż 9 znaków")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "NrTel może zawierać tylko cyfry")]
        [DataType(DataType.Text)]
        [MinLength(9, ErrorMessage = "NrTel musi mieć 9 znaków")]
        [MaxLength(9, ErrorMessage = "NrTel nie może być dłuższy niż 9 znaków")]

        public int NrTel { get; set; }

        // [Required(ErrorMessage = "Pole Samochód jest wymagane")]
        //[Display(Name = "Samochód")]
        // [DataType(DataType.Custom)]

        //  public CarModel car { get; set; }
      
        }

    }

