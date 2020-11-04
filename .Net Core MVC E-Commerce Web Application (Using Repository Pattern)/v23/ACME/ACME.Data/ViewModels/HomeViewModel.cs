using ACME.Data.Models;
using System.Collections.Generic;

namespace ACME.Data.ViewModels
{

    // View Model used to define fields for the home page (preferred products)
    public class HomeViewModel
    {
        public IEnumerable<Product> PreferredProducts { get; set; }
    }
}
