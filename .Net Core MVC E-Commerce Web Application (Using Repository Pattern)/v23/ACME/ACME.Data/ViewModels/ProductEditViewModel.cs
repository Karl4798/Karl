using System.ComponentModel.DataAnnotations;

namespace ACME.Data.ViewModels
{

    // View Model used to define fields for editing products in the database
    public class ProductEditViewModel : ProductViewModel
    {
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}
