using System.ComponentModel.DataAnnotations;

namespace ACME.Data.Models
{

    // Model used to store product fields
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Long Description")]
        [StringLength(250000)]
        public string LongDescription { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Preferred Stock?")]
        public bool IsPreferredProduct { get; set; }
        [Required]
        [Display(Name = "In Stock?")]
        public bool InStock { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}