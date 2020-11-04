using ACME.Data.Interfaces;
using ACME.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Data.Repositories
{

    // Repository used to perform CRUD operations on the database (DB Context) for Categories
    public class CategoryRepository : ICategoryRepository
    {

        // Variable used to store the DB Context
        private readonly AppDbContext _appDbContext;

        // Constructor
        public CategoryRepository(AppDbContext appDbContext)
        {

            // Initializes the DB Context variable
            _appDbContext = appDbContext;
        }

        // Method used to retrieve all categories in the database context
        public IEnumerable<Category> Categories => _appDbContext.Categories;

        // Method used to add a category to the database
        public Category Add(Category category)
        {

            // Adds the category to the database context
            _appDbContext.Add(category);

            // Saves all changes to the database context
            _appDbContext.SaveChanges();

            // Return the category object
            return category;

        }

        // Method used to delete a category from the database
        public Category Delete(int id)
        {

            // Gets the category to delete
            Category category = _appDbContext.Categories.Find(id);

            // If the category is not null, delete it
            if (category != null)
            {

                // Remove the category object from the database context
                _appDbContext.Categories.Remove(category);

                // Save all changes to the database context
                _appDbContext.SaveChanges();
            }

            // Return the category object
            return category;

        }

        // Method used to edit a category from the database
        public Category Edit(Category categoryChanges)
        {

            // Gets the category from the passed parameter
            var category = _appDbContext.Categories.Attach(categoryChanges);

            // Change the category state to "Modified", so that it will save all changes
            category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // Save the category name changes to the database
            _appDbContext.SaveChanges();

            // Return the category object
            return categoryChanges;

        }

        // Method used to get all categories from the database
        public List<Category> GetCategories()
        {

            // Temporary list used to store all categories from the database
            List<Category> categories = new List<Category>();

            // Add all the categories to the temporary list of type <Category>
            foreach (var item in _appDbContext.Categories)
            {

                // Add all the categories
                categories.Add(item);
            }

            // Return the categories list
            return categories;

        }

    }
}
