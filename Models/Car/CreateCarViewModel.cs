using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Car
{
    
       
    
    public class CreateCarViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Title must start with capital letter and cannot contain special characters.")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(50, ErrorMessage = "Model cannot be longer than 50 characters.")]
        [Display(Name = "Model")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Model must start with capital letter and cannot contain special characters.")]
        [MinLength(3, ErrorMessage = "Model must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Model cannot be longer than 50 characters.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(50, ErrorMessage = "Color cannot be longer than 50 characters.")]
        [Display(Name = "Color")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Color must start with capital letter and cannot contain special characters.")]
        [MinLength(3, ErrorMessage = "Color must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Color cannot be longer than 50 characters.")]
        
        public string Color { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [StringLength(50, ErrorMessage = "Year cannot be longer than 50 characters.")]
        [Display(Name = "Year")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Year must start with capital letter and cannot contain special characters.")]
        [MinLength(3, ErrorMessage = "Year must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Year cannot be longer than 50 characters.")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [StringLength(50, ErrorMessage = "Price cannot be longer than 50 characters.")]
        [Display(Name = "Price")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^\d{0,8}(\.\d{1,4})?$", ErrorMessage = "Price must be numbers")]
        [Range(10000, 100000)]
        public string Price { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(50, ErrorMessage = "Description cannot be longer than 50 characters.")]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Description must start with capital letter and cannot contain special characters.")]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Description cannot be longer than 50 characters.")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Engine is required.")]
       // [Display(Name = "Engine")]
        
        public List<SelectListItem> Engine { get; set; }


        [Required(ErrorMessage = "HorsePower is required.")]
        [StringLength(50, ErrorMessage = "HorsePower cannot be longer than 50 characters.")]
        [Display(Name = "HorsePower")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "HorsePower must start with capital letter and cannot contain special characters.")]
        [MinLength(3, ErrorMessage = "HorsePower must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "HorsePower cannot be longer than 50 characters.")]
        [Range(10, 100)]
        public int HorsePower { get; set; }
    
    }
}
