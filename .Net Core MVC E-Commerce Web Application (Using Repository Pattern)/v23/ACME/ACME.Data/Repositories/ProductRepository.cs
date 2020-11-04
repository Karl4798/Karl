using ACME.Data.Interfaces;
using ACME.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Data.Repositories
{

    // Repository used to perform CRUD operations on the database (DB Context) for Products
    public class ProductRepository : IProductRepository
    {

        // Variable used to store the DB Context
        private readonly AppDbContext _appDbContext;

        // Constructor
        public ProductRepository(AppDbContext appDbContext)
        {

            // Initializes the DB Context variable
            _appDbContext = appDbContext;
        }

        // Method used to retrieve all products in the database context
        public IEnumerable<Product> Products => _appDbContext.Products.Include(c => c.Category);

        // Method used to retrieve all preferred products in the database context
        public IEnumerable<Product> PreferredProducts => _appDbContext.Products.Where(p => p.IsPreferredProduct).Include(c => c.Category);

        // Method used to retrieve specific product in the database context
        public Product GetProductById(int productId) => _appDbContext.Products.FirstOrDefault(p => p.Id == productId);

        // Method used to add a product to the database context
        public Product Add(Product product)
        {

            // Adds the passed product object to the database context
            _appDbContext.Products.Add(product);

            // Saves all changes to the database context
            _appDbContext.SaveChanges();

            // Returns the product object
            return product;
        }

        // Method used to edit a product in the database context
        public Product Edit(Product productChanges)
        {

            // Variable used to hold the changed product
            var product = _appDbContext.Products.Attach(productChanges);

            // Change the state of the product so that it updates when SaveChanges() method is run
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // Save all changes to the database
            _appDbContext.SaveChanges();

            // Return the product object
            return productChanges;

        }

        // Method used to delete a product from the database context
        public Product Delete(int id)
        {

            // Variable used to store the product found in the database, from the passed product id
            Product product = _appDbContext.Products.Find(id);

            // If the product is not null, delete it from the database context
            if (product != null)
            {

                // Remove the product from the database context
                _appDbContext.Products.Remove(product);

                // Save all changes to the database context
                _appDbContext.SaveChanges();
            }

            // Return the product object
            return product;

        }

    }

}
