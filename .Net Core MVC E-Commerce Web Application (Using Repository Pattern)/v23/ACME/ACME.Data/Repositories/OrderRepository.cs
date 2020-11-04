using ACME.Data.Interfaces;
using ACME.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACME.Data.Repositories
{

    // Repository used to perform CRUD operations on the database (DB Context) for Orders
    public class OrderRepository : IOrderRepository
    {

        // Variable used to store the DB Context
        private readonly AppDbContext _appDbContext;

        // Variable used to store the shopping cart
        private readonly ShoppingCart _shoppingCart;

        // Constructor
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {

            // Initializes the DB Context variable
            _appDbContext = appDbContext;

            // Initializes the Shopping Cart variable
            _shoppingCart = shoppingCart;
        }

        // Method to create the order in the database
        public void CreateOrder(Order order)
        {

            // Set the OrderPlaced field to DateTime.Now (current date time)
            order.OrderPlaced = DateTime.Now;

            // Add the order to the database
            _appDbContext.Orders.Add(order);

            // Get the shopping cart items and store them in the shoppingCartItems variable
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            // Add all the order details to the database
            foreach (var item in shoppingCartItems)
            {

                // Create new orderDetail model object for each product in the order
                var orderDetail = new OrderDetail()
                {

                    // Add product details to the OrderDetail object
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    ProductName = item.Product.Name,
                    CategoryId = (int)item.Product.CategoryId,
                    OrderId = order.OrderId,
                    Price = item.Product.Price
                };

                // Add the orderDetail object to the database
                _appDbContext.OrderDetails.Add(orderDetail);
            }

            // Save all changes to the database context
            _appDbContext.SaveChanges();
        }

        // Get all customer orders for a specific user, or if email is "all" when the admin logs in, return orders for all users
        public IQueryable<Order> CustomerOrders(string email)
        {

            // Get all orders from the database
            IQueryable<Order> orders = _appDbContext.Orders.OrderBy(o => o.OrderPlaced).Include(o => o.OrderLines);

            // If the email is not equal to "all" then only return a subset of orders for that particular email address
            if (!email.Equals("all"))
            {
                
                // Filter orders and only return orders for a particular account (email)
                orders = orders.Where(o => o.Email.Equals(email));
            }

            // Return the list of orders
            return orders;

        }

        // Method used to filter orders for passed string value
        // Get all customer orders for a specific user, or if email is "all" when the admin logs in, return orders for all users
        public IQueryable<Order> CustomerOrders(string email, string orderSearch)
        {

            // Get all orders from the database
            IQueryable<Order> orders = _appDbContext.Orders.OrderBy(o => o.OrderPlaced).Include(o => o.OrderLines);

            // Filter orders where orderSearch value is equal to, or is contained in order details
            orders = orders.Where(o => o.OrderId.ToString().Equals(orderSearch) ||
                 o.Email.Contains(orderSearch) ||
                 o.FirstName.Contains(orderSearch) ||
                 o.LastName.Contains(orderSearch) ||
                 o.AddressLine1.Contains(orderSearch) ||
                 o.AddressLine2.Contains(orderSearch) ||
                 o.Province.Contains(orderSearch) ||
                 o.City.Contains(orderSearch) ||
                 o.Postcode.ToString().Contains(orderSearch) ||
                 o.OrderTotal.ToString().Contains(orderSearch));

            // If the email is not equal to "all" then only return a subset of orders for that particular email address
            if (!email.Equals("all"))
            {

                // Filter orders and only return orders for a particular account (email)
                orders = orders.Where(o => o.Email.Equals(email));
            }

            // Return the list of orders
            return orders;

        }

        // Return a list of all order details
        public List<OrderDetail> AllOrders()
        {

            // Create new orders model object, which contains all orderDetails for the orders
            List<OrderDetail> orders = new List<OrderDetail>();

            // Fetches all order details from the database
            foreach (var item in _appDbContext.OrderDetails)
            {

                // Creates new OrderDetail object
                OrderDetail o = new OrderDetail()
                {
                    OrderDetailId = item.OrderDetailId,
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    CategoryId = item.CategoryId,
                    Amount = item.Amount,
                    Price = item.Price
                };

                // Adds the order details to the orders list
                orders.Add(o);
            }

            // Returns a list of all order details
            return orders;

        }

        // Method used to return a single order for the passed order id
        public Order CustomerOrder(int? id)
        {

            // Creates a new Order object and fetches information from the database into it
            Order order = _appDbContext.Orders.Include(o => o.OrderLines).Where(o => o.OrderId == id).SingleOrDefault();

            // Returns the order object
            return order;

        }
    }

}