using ACME.Data.Models;

namespace ACME.Data.ViewModels
{

    // View Model used to define fields for shopping cart (cart total)
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
