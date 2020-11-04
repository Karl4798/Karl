using ACME.Data.Interfaces;
using ACME.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace ACME.OrderFacade
{

    // Facade used to process order
    public class UserOrder
    {

        // Variables used when creating the order on the web application
        private string email;
        private ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;


        // Constructor
        public UserOrder(IOrderRepository orderRepository, ShoppingCart shoppingCart, IHttpContextAccessor httpContextAccessor)
        {

            // Sets repository variables
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;

            // Gets the email of the customer
            var email = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            this.email = email;

            // If the user is in role Admin set their email to "all" so they can access all customer orders and information
            if (httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value.Equals("Admin"))
            {
                this.email = "all";
            }
            else
            {
                this.email = email;
            }

        }

        // Method used when checking out
        public Order CheckoutOrder(Order order)
        {

            // Try and generate the order, else console log the error and return null
            try
            {

                // Retrieve user information
                order.Email = email;

                // Retrieves the order information
                order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

                // Create the new order with the customer and order information
                _orderRepository.CreateOrder(order);

                // Clear the cart
                _shoppingCart.ClearCart();

                // Return the order object
                return order;

            }

            // If the order is invalid, or cannot be processed, then console log the error message and return null
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;

            }


        }

        // Method used to fetch all customer transactions from the database
        public IQueryable<Order> getCustomerTransactions()
        {

            // Gets the customer transactions for the passed email address (account)
            var customerTransactions = _orderRepository.CustomerOrders(email);

            // Return the customer transactions
            return customerTransactions;

        }

        // Method used to fetch all customer transactions from the database for the search phrase or term
        public IQueryable<Order> getSearchedOrders(string orderSearch)
        {

            // Gets customer orders for the logged in user, and which evaluate to the search term
            var customerTransactions = _orderRepository.CustomerOrders(email, orderSearch);

            // Return the customer transactions
            return customerTransactions;

        }

    }
}
