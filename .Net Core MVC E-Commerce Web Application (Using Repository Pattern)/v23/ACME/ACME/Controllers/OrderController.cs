using ACME.Data.Interfaces;
using ACME.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ACME.OrderFacade;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;

namespace ACME.Controllers
{
    public class OrderController : Controller
    {

        // Creates repository variables used to access database information
        private readonly IOrderRepository _orderRepository;

        // Variable used to access shopping cart methods
        private readonly ShoppingCart _shoppingCart;

        // IHttpContextAccessor variable used to get HTTP Context
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Variable used to access UserOrder Facade
        private UserOrder userOrder;

        // Create variables to hold the UserManager (user information)
        private readonly UserManager<AccountUser> _userManager;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, IHttpContextAccessor httpContextAccessor, UserManager<AccountUser> userManager)
        {

            // Assigns variables used to retrieve and send information to the database
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

            // Instantiates new UserOrder object called userOrder
            userOrder = new UserOrder(_orderRepository, _shoppingCart, _httpContextAccessor);

        }

        // Method used to show a list of all customer transactions
        // Only users in the Admin or Customer roles may access this resource
        [Authorize]
        public IActionResult CustomerTransactions(string orderSearch, string startDate, string endDate, string orderSortOrder)
        {

            // Gets the customer transactions and stores it in an IQueryable object
            IQueryable<Order> customerTransactions = userOrder.getCustomerTransactions().OrderBy(o => o.OrderPlaced);

            // If the orderSearch value is not null, then display only searched for transactions
            if (!String.IsNullOrEmpty(orderSearch))
            {

                // Sets customerTransactions variable to that of only searched for transactions
                customerTransactions = userOrder.getSearchedOrders(orderSearch);
            }

            // Variable used to store start date for filtering by transaction date
            DateTime parsedStartDate;

            // Try Parse this date, and set customerTransactions to only those that conform to the date value range
            if (DateTime.TryParse(startDate, out parsedStartDate))
            {

                // Sets customerTransactions variable
                customerTransactions = customerTransactions.Where(o => o.OrderPlaced >= parsedStartDate);
            }

            // Variable used to store end date for filtering by transaction date
            DateTime parsedEndDate;

            // Try Parse this date, and set customerTransactions to only those that conform to the date value range
            if (DateTime.TryParse(endDate, out parsedEndDate))
            {

                // Sets customerTransactions variable
                customerTransactions = customerTransactions.Where(o => o.OrderPlaced <= parsedEndDate);
            }

            // Sets ViewBag variables
            ViewBag.DateSort = String.IsNullOrEmpty(orderSortOrder) ? "date" : "";
            ViewBag.UserSort = orderSortOrder == "user" ? "user_desc" : "user";
            ViewBag.PriceSort = orderSortOrder == "price" ? "price_desc" : "price";
            ViewBag.CurrentOrderSearch = orderSearch;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            // Sets customerTransactions order based on username (email), price, and date
            switch (orderSortOrder)
            {
                case "user":
                    customerTransactions = customerTransactions.OrderBy(o => o.FirstName);
                    break;
                case "user_desc":
                    customerTransactions = customerTransactions.OrderByDescending(o => o.FirstName);
                    break;
                case "price":
                    customerTransactions = customerTransactions.OrderBy(o => o.OrderTotal);
                    break;
                case "price_desc":
                    customerTransactions = customerTransactions.OrderByDescending(o => o.OrderTotal);
                    break;
                case "date":
                    customerTransactions = customerTransactions.OrderBy(o => o.OrderPlaced);
                    break;
                default:
                    customerTransactions = customerTransactions.OrderByDescending(o => o.OrderPlaced);
                    break;
            }

            // Returns the view with the customerTransactions object
            return View(customerTransactions);

        }

        // Method used to show detailed information about a transaction
        // Only users in the Admin or Customer roles may access this resource
        [Authorize]
        public ActionResult CustomerTransactionsDetails(int? id)
        {

            // Gets the order information for the passed order id
            Order order = _orderRepository.CustomerOrder(id);

            // Returns the view with the order details (order object)
            return View(order);

        }

        // Method used to checkout customers
        // Only users in the Customer role may access this resource
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Checkout()
        {

            // Gets the user information
            var user = await _userManager.GetUserAsync(User);

            // Gets the order informatiuon and stores it in an Order model
            var orderUserModel = new Order
            {

                // Sets model fields
                FirstName = user.FirstName,
                LastName = user.LastName,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                Province = user.Province,
                Postcode = user.Postcode,
                PhoneNumber = user.PhoneNumber
            };

            // Returns the view with order details
            return View(orderUserModel);
        }

        // Method used to checkout customers
        // Only users in the Customer role may access this resource
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult Checkout(Order order)
        {

            // Variable used to store shopping cart items
            var items = _shoppingCart.GetShoppingCartItems();

            // Gets shopping cart items
            _shoppingCart.ShoppingCartItems = items;

            // If the shopping cart has no items, then display and error
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some products first");
            }

           // If the shopping cart has items, then checkout the customer
            if (ModelState.IsValid)
            {

                // Checkout the customer using the Facade, and then return the view
                if (userOrder.CheckoutOrder(order) != null)
                {
                    // Return the "CheckoutComplete" view
                    return RedirectToAction("CheckoutComplete");
                }
                
            }

            // Return the view with order details (order object)
            return View(order);
        }

        // Method used to show checkout confirmation view
        // Only users in the Customer role may access this resource
        [Authorize(Roles = "Customer")]
        public IActionResult CheckoutComplete()
        {
            
            // Set ViewBag message to be displayed on the view
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";

            // Return to the view
            return View();
        }

    }
}
