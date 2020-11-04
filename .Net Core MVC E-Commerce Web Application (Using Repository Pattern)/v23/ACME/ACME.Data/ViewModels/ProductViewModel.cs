using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ACME.Data.ViewModels
{

    // View Model used to define fields for viewing product information stored in the database
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a product name.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a product name between 3 and 50 characters in length")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a product name made up of letters and numbers only")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Short Description")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Please enter a product description between 10 and 200 characters in length")]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s\:\-\.\#\&\!\@\$\?\%\*\(\)\/\|\""\+\-\~\{\}\”\’\<\>]*$", ErrorMessage = "Please enter a product description made up of letters and numbers only")]
        public string ShortDescription { get; set; }
        [Required]
        [Display(Name = "Long Description")]
        [StringLength(25000, MinimumLength = 5, ErrorMessage = "Please enter a product description between 5 and 25000 characters in length")]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s\:\-\.\#\&\!\@\$\?\%\*\(\)\/\|\""\+\-\~\{\}\”\’\<\>]*$", ErrorMessage = "Please enter a product description made up of letters and numbers only")]
        public string LongDescription { get; set; }
        [Required(ErrorMessage = "Please enter a price.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Preferred Stock?")]
        public bool IsPreferredProduct { get; set; }
        [Required]
        [Display(Name = "In Stock?")]
        public bool InStock { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
    }
}
