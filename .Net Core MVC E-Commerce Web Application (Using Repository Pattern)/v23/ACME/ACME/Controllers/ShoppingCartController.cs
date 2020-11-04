using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACME.Data.Interfaces;
using ACME.Data.Models;
using ACME.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Controllers
{

    public class ShoppingCartController : Controller
    {

        // Creates repository variables used to access database information
        private readonly IProductRepository _productRepository;

        // Variable used to access shopping cart methods
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {

            // Initializes the Repository classes, so that we can use them to perform CRUD operations on the database
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        // Method used to show the shopping cart for the user
        // Only users in the Customer role may access this resource
        [Authorize(Roles = "Customer")]
        public ViewResult Index()
        {

            // Gets shopping cart items by calling GetShoppingCartItems() method
            var items = _shoppingCart.GetShoppingCartItems();

            // Sets global class variable to store shopping cart items
            _shoppingCart.ShoppingCartItems = items;

            // Creates a new instance of the ShoppingCartViewModel to store shopping cart information
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            // Returns the view with shoppingCartViewModel information
            return View(shoppingCartViewModel);
        }

        // Method used to add items to the shopping cart for the user
        // Only users in the Customer role may access this resource
        [Authorize(Roles = "Customer")]
        public RedirectToActionResult AddToShoppingCart(int productId)
        {

            // Gets the selected product object from the productRepository
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.Id == productId);

            // If the selected product is not null, then add the item to the cart
            if (selectedProduct != null)
            {

                // Adds the product to the cart (x1 quantity)
                _shoppingCart.AddToCart(selectedProduct, 1);
            }

            // Returns the shopping cart index view
            return RedirectToAction("Index");
        }

        // Method used to remove an item from the shopping cart
        // Only users in the Customer role may access this resource
        [Authorize(Roles = "Customer")]
        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {

            // Gets the selected product object from the productRepository
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.Id == productId);

            // If the selected product is not null, then remove the item from the cart
            if (selectedProduct != null)
            {

                // Calls the RemoveFromCart() method to remove the product fromt the cart
                _shoppingCart.RemoveFromCart(selectedProduct);

                // If the shopping cart now contains no items, then return to the home/index view
                if (_shoppingCart.GetShoppingCartItems().Count < 1)
                {

                    // Returns to the home/index view
                    return RedirectToAction("Return");
                }

            }

            // Returns to the shopping cart index view
            return RedirectToAction("Index");
        }

        // Method used to update the cart with new product quantities
        // Only users in the Customer role may access this resource
        [Authorize(Roles = "Customer")]
        public ActionResult UpdateCart(IFormCollection frc)
        {

            // Create new array to store quantities
            string [] quantities = frc["quantity"];

            // Get items from the shopping cart
            var items = _shoppingCart.GetShoppingCartItems();

            // Variable to store item quantities
            int i = 0;

            // Fetch all products in the shopping cart
            foreach (var product in items)
            {

                // Set the quantities from the view
                try
                {

                    // Set the product amount (quantity)
                    product.Amount = Convert.ToInt32(quantities[i]);

                    // If the quantity is now less than one, remove the item from the cart
                    if(product.Amount < 1)
                    {
                        _shoppingCart.RemoveFromCart(product.Product);
                    }

                }

                // If the item quantity cannot be set, then remove the product from the cart
                catch (Exception)
                {
                    _shoppingCart.RemoveFromCart(product.Product);
                }
                
                // Increment the quantity variable
                i++;

            }

            // Checks to see if there are any items in the cart - if not, then return the user to the home/index view else return them to the shopping cart/index view
            bool isAnyItems = _shoppingCart.UpdateCart();

            // Redirect the user
            if (isAnyItems)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // Method used to clear the cart
        [Authorize(Roles = "Customer")]
        public RedirectToActionResult ClearCart()
        {

            // Runs a method which clears the cart
            _shoppingCart.ClearCart();

            // Returns the user to the home/index view
            return RedirectToAction("Index", "Home");
        }

        // Returns the user to the home/index view
        public RedirectToActionResult Return()
        {

            // Redirects the user to the home/index view
            return RedirectToAction("Index", "Home");
        }

    }

}