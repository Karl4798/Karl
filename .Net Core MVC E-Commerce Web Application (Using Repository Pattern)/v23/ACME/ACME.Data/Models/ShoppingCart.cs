using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Data.Models
{

    // Model used to store shopping cart fields
    public class ShoppingCart
    {

        // Variable used to store the DB Context
        private readonly AppDbContext _appDbContext;

        // Constructor
        private ShoppingCart(AppDbContext appDbContext)
        {

            // Assign the DB Context variable
            _appDbContext = appDbContext;
        }

        // Shopping cart fields
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        // Method used to get shopping cart instance
        public static ShoppingCart GetCart(IServiceProvider services)
        {

            // Gets session data
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            // Variable used to store service context
            var context = services.GetService<AppDbContext>();

            // Gets new cart id
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            // Sets session cart id
            session.SetString("CartId", cartId);

            // Returns the new shopping cart id
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        // Method used to add items to the cart
        public void AddToCart(Product product, int amount)
        {

            // Variable used to store shopping cart items
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            // If the shopping cart does not containt the item, then add the item to the cart, else increment it's quantity
            if (shoppingCartItem == null)
            {

                // Create a new ShoppingCartItem object in the shopping cart
                shoppingCartItem = new ShoppingCartItem
                {

                    // Sets shopping cart item fields
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                // Adds the shopping cart items to the shopping cart
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }

            // Else if the item already exists in the shopping cart, increment it's amount (quantity)
            else
            {

                // Increment product amount (quantity)
                shoppingCartItem.Amount++;
            }

            // Save changes to the DB Context
            _appDbContext.SaveChanges();
        }

        // Method used to remove items from the cart
        public int RemoveFromCart(Product product)
        {

            // Variable used to store shopping cart item
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            // Variable used to store quantity of products
            var localAmount = 0;

            // If the shopping cart item is not null, then decrement it's amount (quantity)
            if (shoppingCartItem != null)
            {

                // If the product amount (quantity) is greater than one, decrement it's value
                if (shoppingCartItem.Amount > 1)
                {

                    // Decrement it's quantity
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }

                // Else if the quantity is one, remove the product entirely from the cart
                else
                {

                    // Removes the item from the DB Context shopping cart
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);

                }
            }

            // Saves changes to the DB Context
            _appDbContext.SaveChanges();

            // Returns the total amount of the product (quantity)
            return localAmount;
        }

        // Method used to get all shopping cart items (returned into a list of type ShoppingCartItem)
        public List<ShoppingCartItem> GetShoppingCartItems()
        {

            // Returns the shopping cart items from the DB Context
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Product)
                           .ToList());
        }

        // Method used to clear the cart
        public void ClearCart()
        {

            // Variable used to store all cart items
            var cartItems = _appDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            // Remove the range of products from the DB Context shopping cart
            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            // Save all changes to the DB Context
            _appDbContext.SaveChanges();
        }

        // Method used to update the cart
        public bool UpdateCart()
        {

            // Variable used to store all cart items
            var cartItems = _appDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            // If the cart items count is greater than 0, save changes and return true, else return false
            if (cartItems.Count() > 0)
            {

                // Save changes to the DB Context
                _appDbContext.SaveChanges();
            }
            else
            {

                // Return false (cart has not been updated)
                return false;
            }

            // Return true (cart has been updated)
            return true;

        }

        // Method used to get the shopping cart total amount (price)
        public decimal GetShoppingCartTotal()
        {

            // Calculates the total amount from the DB Context
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();

            // Returns the total amount
            return total;
        }

    }
}
