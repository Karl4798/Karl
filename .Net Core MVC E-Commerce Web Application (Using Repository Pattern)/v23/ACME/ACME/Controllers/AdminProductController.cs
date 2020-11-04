using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACME.Data.Models;
using Microsoft.AspNetCore.Authorization;
using ACME.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ACME.Data.ViewModels;

namespace ACME.Controllers
{
    public class AdminProductController : Controller
    {

        // Creates repository variables used to access database information
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private static string ImageUrl;

        public AdminProductController(IOrderRepository orderRepository,
            IProductRepository productRepository, ICategoryRepository categoryRepository,
            IHostingEnvironment hostingEnvironment)
        {

            // Initializes the Repository classes, so that we can use them to perform CRUD operations on the database
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _hostingEnvironment = hostingEnvironment;
            _orderRepository = orderRepository;
        }

        // Method used to show a list of all products in the web application
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            // Gets the products list from the productsRepository class
            var products = _productRepository.Products.ToList();

            // Gets the categories from the categoryRepository class
            var categories = _categoryRepository.Categories.ToList();

            // Creates a ProductListViewModel instance and initializes it
            ProductListViewModel model = new ProductListViewModel();

            // Adds all the products to the view model
            model.Products = products;
            model.Categories = categories;

            // Return to the view with the view model information
            return View(model);
        }

        // Method used to get product details for the passed product ID
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            
            // If the product id is invalid (< 0), then display an error
            if (id < 0)
            {
                return NotFound();
            }

            // Variable used to hold categoryName
            string categoryName = null;

            // Gets product information for the passed in product id
            var product = _productRepository.GetProductById(id);

            // Gets all categories and stores it in a list
            var categories = _categoryRepository.Categories.ToList();

            // Gets the category name for the product
            foreach (var c in categories)
            {
                if (product.CategoryId == c.Id)
                {
                    categoryName = c.Name;
                }
            }

            // Creates an instance of ProductEditViewModel and initializes it
            ProductEditViewModel p = new ProductEditViewModel()
            {
                // Fetches product information and stores it in ProductEditViewModel p object
                Id = product.Id,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                IsPreferredProduct = product.IsPreferredProduct,
                InStock = product.InStock,
                CategoryName = categoryName
            };

            // If the ProductEditViewModel p object is null, then display and error
            if (p == null)
            {
                return NotFound();
            }

            // Return the view with product details (ProductEditViewModel p object)
            return View(p);
        }

        // Method used to edit selected product
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {

            // If the product id is invalid (< 0), then display an error
            if (id < 0)
            {
                return NotFound();
            }

            // Variable used to hold categoryName
            string categoryName = null;

            // Gets product information for the passed in product id
            var product = _productRepository.GetProductById(id);

            // Gets all categories and stores it in a list
            var categories = _categoryRepository.Categories.ToList();

            // Sets static variable for ImageUrl
            if (product.ImageUrl != null)
            {
                ImageUrl = product.ImageUrl;
            }

            // Gets the category name for the product
            foreach (var c in categories)
            {
                if (product.CategoryId == c.Id)
                {
                    categoryName = c.Name;
                }
            }

            // Creates an instance of ProductEditViewModel and initializes it
            ProductEditViewModel p = new ProductEditViewModel()
            {

                // Fetches product information and stores it in ProductEditViewModel p object
                Id = product.Id,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                IsPreferredProduct = product.IsPreferredProduct,
                InStock = product.InStock,
                CategoryName = categoryName
            };

            // If the ProductEditViewModel p object is null, then display and error
            if (p == null)
            {
                return NotFound();
            }

            // Return list of all available category names
            ViewData["CategoryName"] = new SelectList(_categoryRepository.Categories, "Name", "Name");

            // Return the view with product details (ProductEditViewModel p object)
            return View(p);
        }

        // Method used to edit selected product
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductEditViewModel product)
        {

            // Check that the passed in id equals to the product id passed in
            if (id != product.Id)
            {
                return NotFound();
            }

            // Sets static variable for ImageUrl
            if (product.ImageUrl != null)
            {
                product.ImageUrl = ImageUrl;
            }

            // Checks form state (ModelState), and only processes edit request if ModelState is valid
            if (ModelState.IsValid)
            {

                // Variable to store categoryId
                int? categoryId = null;

                // Gets all categories and stores it in a list
                var categories = _categoryRepository.Categories.ToList();

                // Gets product information for the passed in product id
                var prod = _productRepository.GetProductById(id);

                // Gets the category id for the product
                foreach (var c in categories)
                {
                    if (c.Name.Equals(product.CategoryName))
                    {
                        categoryId = c.Id;
                    }
                }

                // Try and process the edit request
                try
                {

                    // Store new product information
                    prod.Name = product.Name;
                    prod.ShortDescription = product.ShortDescription;
                    prod.LongDescription = product.LongDescription;
                    prod.Price = product.Price;
                    prod.IsPreferredProduct = product.IsPreferredProduct;
                    prod.InStock = product.InStock;
                    prod.CategoryId = categoryId;

                    // Store new image if it has changed
                    if (product.Image != null)
                    {

                        // If the product Url is not null, then save the image
                        if (prod.ImageUrl != null)
                        {

                            // Gets the image path of the existing image
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", prod.ImageUrl);

                            // Try and delete the existing image
                            try
                            {

                                // Delete the image
                                System.IO.File.Delete(filePath);
                            }
                            catch (Exception)
                            {
                                // Do nothing
                            }

                        }

                        // Save the new image
                        prod.ImageUrl = SaveImage(product);

                        // Set the view image to that of the new image
                        ImageUrl = prod.ImageUrl;
                    }

                    // Save changes by calling the productRepository Edit method and passing in the new product object
                    _productRepository.Edit(prod);
                }

                // If the changes could not be saved, then display an error message
                catch (DbUpdateConcurrencyException)
                {

                    // Display a "Not Found" error if the product could not be found
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                // Redirect to the product list view
                return RedirectToAction(nameof(Index));

            }

            // If the model state was not valid, but a new (valid) images was provided, save the new image and display in the view.
            else
            {

                // Gets product information for the passed in product id
                var prod = _productRepository.GetProductById(id);

                // Store new image if it has changed
                if (product.Image != null)
                    {

                        // If the product Url is not null, then save the image
                        if (prod.ImageUrl != null)
                        {

                            // Gets the image path of the existing image
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", prod.ImageUrl);

                            // Try and delete the existing image
                            try
                            {

                                // Delete the image
                                System.IO.File.Delete(filePath);
                            }
                            catch (Exception)
                            {
                                // Do nothing
                            }

                        }

                        // Save the new image
                        prod.ImageUrl = SaveImage(product);

                        // Saves the image on the view
                        ImageUrl = prod.ImageUrl;
                        
                        // Saves the image to the product object
                        product.ImageUrl = ImageUrl;

                        // Save the changes to the product by calling the productRepository Edit method and passing in the prod object
                        _productRepository.Edit(prod);
                }

            }

            // Return list of all available category names
            ViewData["CategoryName"] = new SelectList(_categoryRepository.Categories, "Name", "Name");

            // Return the view with product details (ProductEditViewModel product object)
            return View(product);

        }

        // Method used to save product images
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        private string SaveImage(ProductViewModel product)
        {

            // Variable used to store unique photo name (GUID)
            string uniqueFileName = null;

            // If the product.Image is not null, then save the image
            if (product.Image != null)
            {

                // Variable used to store the images folder path
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                // Sets the unique image file name
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.Image.FileName;

                // Variable used to store combined path of the images directory and the image GUID
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Saves the image
                FileStream fs = new FileStream(filePath, FileMode.Create);
                product.Image.CopyTo(fs);
                fs.Close();
            }

            // Returns the image GUID
            return uniqueFileName;
        }

        // Method used to create products in the web application
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {

            // Return list of all available category names
            ViewData["CategoryName"] = new SelectList(_categoryRepository.Categories, "Name", "Name");

            // Return the view
            return View();
        }


        // Method used to create products in the web application
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product)
        {

            // Check if the product.Image is null - if it's not null, then create the product, else display an error
            if (product.Image != null)
            {

                // Checks form state (ModelState), and only processes create request if ModelState is valid
                if (ModelState.IsValid)
                {

                    // Saves the product image
                    string uniqueFileName = SaveImage(product);

                    // Variable used to store categoryId
                    int? categoryId = null;

                    // Gets all categories and stores it in a list
                    var categories = _categoryRepository.Categories.ToList();

                    // Gets the category id for the product
                    foreach (var c in categories)
                    {
                        if (c.Name.Equals(product.CategoryName))
                        {
                            categoryId = c.Id;
                        }
                    }

                    // Creates a new Product object p
                    Product p = new Product()
                    {

                        // Saves all the product information into the model
                        Name = product.Name,
                        ShortDescription = product.ShortDescription,
                        LongDescription = product.LongDescription,
                        Price = product.Price,
                        ImageUrl = uniqueFileName,
                        IsPreferredProduct = product.IsPreferredProduct,
                        InStock = product.InStock,
                        CategoryId = categoryId
                    };

                    // Saves the new product to the database (using the productRepository Add method)
                    _productRepository.Add(p);

                    // Returns to the product list
                    return RedirectToAction(nameof(Index));
                }

                // Return list of all available category names
                ViewData["CategoryName"] = new SelectList(_categoryRepository.Categories, "Name", "Name");

                // Return to the view with the product information
                return View(product);
            }

            // Return list of all available category names
            ViewData["CategoryName"] = new SelectList(_categoryRepository.Categories, "Name", "Name");

            // Return to the view with the product information
            return View(product);

        }

        // Method used to delete products from the web application
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {

            // If the product id is invalid (< 0), then display an error
            if (id < 0)
            {
                return NotFound();
            }

            // Variable to store categoryName
            string categoryName = null;

            // Gets product information for the passed in product id
            var product = _productRepository.GetProductById(id);

            // Gets all categories and stores it in a list
            var categories = _categoryRepository.Categories.ToList();

            // Gets the category name for the product
            foreach (var c in categories)
            {
                if (product.CategoryId == c.Id)
                {
                    categoryName = c.Name;
                }
            }


            // Creates an instance of ProductEditViewModel and initializes it
            ProductEditViewModel p = new ProductEditViewModel()
            {

                // Fetches product information and stores it in ProductEditViewModel p object
                Id = product.Id,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                IsPreferredProduct = product.IsPreferredProduct,
                InStock = product.InStock,
                CategoryName = categoryName
            };


            // If the ProductEditViewModel p object is null, then display and error
            if (p == null)
            {
                return NotFound();
            }

            // Return the view with product details (ProductEditViewModel p object)
            return View(p);
        }

        // Method used to delete products from the web application
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            // Gets product information for the passed in product id
            var product = _productRepository.GetProductById(id);

            // Deletes the product from the database, using the productRepository Delete method
            _productRepository.Delete(id);

            // If the product image is not null (thre is an image present), then delete the image
            if (product.ImageUrl != null)
            {

                // Get the file path for the image
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", product.ImageUrl);

                // Delete the image from the images folder
                System.IO.File.Delete(filePath);
            }

            // Return to the products list
            return RedirectToAction(nameof(Index));
        }

        // Method used to determine if a product exists, by passing in it's id
        private bool ProductExists(int id)
        {

            // Return true if the product exists, or false if it does not exist
            return _productRepository.Products.Any(e => e.Id == id);
        }

        // Method used to view cumulative sales for each category in the web application
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        public ActionResult LineChart()
        {

            // Returns the view
            return View();
        }

        // Method used to view cumulative sales for each category in the web application
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        public ActionResult VisualizeSales()
        {

            // Returns the view, passing in all sales as a JSON object
            return Json(Sales());
        }

        // Method used to get sales for each category in the web application
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        public List<CategorySale> Sales()
        {

            // Creates a list of CategorySale object
            List<CategorySale> sales = new List<CategorySale>();

            // Variable used to store sales for the category
            int noOfSales = 0;

            // Runs foreach methods which extract sales information and increments the noOfSales for the category
            foreach (var c in _categoryRepository.GetCategories())
            {
                
                foreach (var s in _orderRepository.AllOrders())
                {

                    for (int i = 0; i < s.Amount; i++)
                    {
                        if (s.CategoryId == c.Id)
                        {
                            noOfSales++;
                        }
                    }
                    
                }

                // Add new sales object (with product category and number of sales)
                sales.Add(new CategorySale { CategoryName = c.Name, Sales = noOfSales});

                // Reset sales counter for next category
                noOfSales = 0;

            }

            // Return the number of sales for the category
            return sales;

        }
    }
}
