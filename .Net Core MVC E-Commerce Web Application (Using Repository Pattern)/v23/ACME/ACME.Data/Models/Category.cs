using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACME.Data.Models
{

    // Model used to store category fields
    public class Category
    {

        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter a category name beginning with a capital letter and made up of letters and spaces only")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
