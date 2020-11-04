using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACME.Data.Models;
using Microsoft.AspNetCore.Authorization;
using ACME.Data.Interfaces;
using System;

namespace ACME.Controllers
{
    public class AdminCategoryController : Controller
    {

        // Creates repository variables used to access database information
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public AdminCategoryController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            // Initializes the categoryRepository class
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        // Returns a list of all categories in the web application
        // Only users in the Admin role may access this resource
        // GET: Categories
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            // Returns a list of all categories in the web application
            return View(_categoryRepository.GetCategories().ToList());
        }

        // Shows the details of the categories
        // Only users in the Admin role may access this resource
        // GET: Categories/Details/5
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int? id)
        {

            // If the category ID is null, then return an error message
            if (id == null)
            {
                return NotFound();
            }

            // Gets the category from the passed ID
            var category = _categoryRepository.GetCategories().ToList()
                .FirstOrDefault(m => m.Id == id);

            // If the category is null, return an error message
            if (category == null)
            {
                return NotFound();
            }

            // Return the view with the selected category information
            return View(category);
        }

        // Only users in the Admin role may access this resource
        // GET: Categories/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // Method used to create a new category in the web application
        // Only users in the Admin role may access this resource
        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Category category)
        {

            // If the form state (ModelState) is valid, then create the category by passing it into the repository Add method
            if (ModelState.IsValid)
            {
                // Pass the category into the categoryRepository Add method to create the category
                _categoryRepository.Add(category);
                
                // Return to the index page (list view)
                return RedirectToAction(nameof(Index));
            }

            // Return the view with the selected category information
            return View(category);
        }

        // Method used to edit categories in the web application
        // Only users in the Admin role may access this resource
        // GET: Categories/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {

            // If the category ID is null, then return an error message
            if (id == null)
            {
                return NotFound();
            }

            // Gets the category from the passed ID
            var category = _categoryRepository.GetCategories().Find(c => c.Id == id);

            // If the category is null, return an error message
            if (category == null)
            {
                return NotFound();
            }

            // Returns the view with the category information
            return View(category);
        }

        // Method used to edit categories in the web application
        // Only users in the Admin role may access this resource
        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, [Bind("Id,Name")] Category category)
        {

            // If the category ID is null, then return an error message
            if (id != category.Id)
            {
                return NotFound();
            }

            // If the form state (ModelState) is valid, then edit the category by passing it into the repository Edit method
            if (ModelState.IsValid)
            {

                // Try to edit the model
                try
                {

                    // Calls the categoryRepository Edit method
                    _categoryRepository.Edit(category);
                }

                // If the category cannot be updated, then catch the error
                catch (DbUpdateConcurrencyException)
                {

                    // If the category does not exist, then return en error message
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                // Return to the list view
                return RedirectToAction(nameof(Index));
            }

            // Return to the Edit view with the category information
            return View(category);
        }

        // Method to handle deletion of categories in the web application
        // Only users in the Admin role may access this resource
        // GET: Categories/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {

            // If the category ID is null, then return an error message
            if (id == null)
            {
                return NotFound();
            }

            // Gets the category from the passed ID
            var category = _categoryRepository.GetCategories().ToList()
                .FirstOrDefault(m => m.Id == id);

            // If the category is null, return an error message
            if (category == null)
            {
                return NotFound();
            }

            // Return the Delete view with the category information
            return View(category);
        }

        // Method to handle deletion of categories in the web application
        // Only users in the Admin role may access this resource
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Gets the category from the passed ID
            var category = _categoryRepository.GetCategories().Find(c => c.Id == id);

            // Gets all products in the category
            var productsInCategory = _productRepository.Products.Where(p => p.CategoryId == id);

            // If there are products in the category, then do not allow the category to be deleted
            if (productsInCategory.Count() > 0)
            {

                // Return an error message
                ViewBag.Error = "error";

            }

            // If there are no products assigned to the category, then delete the category
            else
            {

                // Calls the categoryRepository Delete method and passes in the category ID to delete the category
                _categoryRepository.Delete(id);

                // Return to the categories list view
                return RedirectToAction(nameof(Index));

            }

            return View(category);

        }

        // Method used to determine if the category exists
        // Only users in the Admin role may access this resource
        [Authorize(Roles = "Admin")]
        private bool CategoryExists(int id)
        {
            // Returns true if the category exists, or false if it does not exist
            return _categoryRepository.Categories.Any(e => e.Id == id);
        }
    }
}
