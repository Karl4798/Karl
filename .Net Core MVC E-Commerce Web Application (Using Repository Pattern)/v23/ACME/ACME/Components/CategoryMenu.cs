using ACME.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ACME.Components
{

    // Class used to show all categories in the "Products" navigation bar header menu
    public class CategoryMenu: ViewComponent
    {

        // Provides access to the categoryRepository
        private readonly ICategoryRepository _categoryRepository;

        // Constructor
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Invokes the menu, which returns a list of all categories
        public IViewComponentResult Invoke()
        {

            // Gets the categories from the categoryRepository
            var categories = _categoryRepository.Categories.OrderBy(p => p.Name);

            // Returns the view with categories object (which contains all categories)
            return View(categories);
        }
    }
}
