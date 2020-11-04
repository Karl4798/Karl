using ACME.Data.Interfaces;
using ACME.Data.Models;
using ACME.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ACME.Controllers
{
    public class ProductController: Controller
    {

        // Creates repository variables used to access database information
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {

            // Initializes the Repository classes, so that we can use them to perform CRUD operations on the database
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // Method used to show all products in the web application
        // Any user may access this resource
        public ViewResult Index(string sortBy, string category, int page = 1)
        {

            // Creates a new instance of the ProductListViewModel model
            var plvm = new ProductListViewModel();

            // Gets the passed in category name
            string _category = category;

            // Lists used to store products, and categories
            IEnumerable<Product> products = null;
            IEnumerable<Category> categories;

            // Create a variable to store the currentCategory
            string currentCategory = string.Empty;

            // If the passed in category is null, then display all products
            if (string.IsNullOrEmpty(category))
            {

                // Gets the products from the productRepository
                products = _productRepository.Products.OrderBy(p => p.Id);

                // Sets the current category to "All Products"
                currentCategory = "All products";

            }

            // If the passed in category is not null, then display products for the category
            else
            {

                // Gets the categories from the categoryRepository
                categories = _categoryRepository.Categories.OrderBy(p => p.Id);

                // Sets the products variable to include all products that are in the specified category
                foreach (var item in categories)
                {
                    if (string.Equals(item.Name, _category, StringComparison.OrdinalIgnoreCase))
                        products = _productRepository.Products.Where(p => p.Category.Name.Equals(item.Name)).OrderBy(p => p.Name);

                    // Sets the currentCategory name
                    currentCategory = item.Name;
                }

                // Sets the currentCategory name
                currentCategory = _category;
            }

            // Sorts the products by price
            switch (sortBy)
            {
                case "price_lowest":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_highest":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            // Sets ProductListViewModel object plvm values
            plvm.Count = products.Count();
            plvm.PagingProducts = PagingList.Create(products, 12, page);
            plvm.CurrentCategory = currentCategory;
            plvm.SortBy = sortBy;
            plvm.Sorts = new Dictionary<string, string>
            {
                {"Price low to high", "price_lowest" },
                {"Price high to low", "price_highest" }
            };


            // Returns the view with the view model information
            return View(plvm);

        }

        // Method used to search products in the web application
        // Any user may access this resource
        public ViewResult Search(string searchString, int page = 1)
        {

            // Creates a new instance of the ProductListViewModel model
            var plvm = new ProductListViewModel();

            // Gets the string phrase or value
            string _searchString = searchString;

            // Variable used to hold list of Products
            IEnumerable<Product> products;

            // String used to hold current category name
            string currentCategory = "All Products";

            // If the search string is null, then display all products
            if (string.IsNullOrEmpty(_searchString))
            {
                products = _productRepository.Products.OrderBy(p => p.Id);
            }

            // If the search string is not null, then display all products that contain the search phrase or string
            else
            {
                products = _productRepository.Products.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            // Sets ProductListViewModel object plvm values
            plvm.Count = products.Count();
            plvm.PagingProducts = PagingList.Create(products, 12, page);
            plvm.CurrentCategory = currentCategory;
            plvm.Sorts = new Dictionary<string, string>
            {
                {"Price low to high", "price_lowest" },
                {"Price high to low", "price_highest" }
            };

            // Returns the list of products, with the ProductListViewModel object
            return View("~/Views/Product/Index.cshtml", plvm);
        }

        // Method used to view product details in the web application
        // Any user may access this resource
        public ViewResult Details(int productId)
        {

            // Gets the product details from the productRepository
            var product = _productRepository.Products.FirstOrDefault(d => d.Id == productId);

            // If the product is null, then display an error message
            if (product == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }

            // Display the view with the product object
            return View(product);
        }

    }
}
