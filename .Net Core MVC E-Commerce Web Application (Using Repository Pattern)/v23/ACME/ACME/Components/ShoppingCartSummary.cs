using ACME.Data.Models;
using ACME.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Components
{

    // Class used to show shopping cart in the navigation bar header menu
    public class ShoppingCartSummary: ViewComponent
    {

        // Variable used to store shopping cart class instance
        private readonly ShoppingCart _shoppingCart;

        // Constructor
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        // Invokes the shopping cart, which returns shopping cart items
        public IViewComponentResult Invoke()
        {

            // Get shopping cart items from the shopping cart repository
            var items = _shoppingCart.GetShoppingCartItems();

            // Sets variable _shoppingCart.ShoppingCartItems variable equal to shopping cart items
            _shoppingCart.ShoppingCartItems = items;

            // Create new ShoppingCartViewModel object, and save items and total to it
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            // Return the view with the shoppingCartViewModel object
            return View(shoppingCartViewModel);

        }

    }
}
