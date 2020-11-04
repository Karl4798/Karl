using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductCommon
{

    // Product model
    public class Product
    {

        // Model variables used to store values

        // Product identity
        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        // Product name
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Last updated field
        [DisplayName("Last Updated")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        // Product price
        [Required]
        [Range(0, 9999999999999.99)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Prices must be in 0.00 format.")]
        public decimal Price { get; set; }

        // Product description
        [Required]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // Image URL link
        [StringLength(5000)]
        [DisplayName("Full-size Image")]
        public string ImageURL { get; set; }

    }

}

