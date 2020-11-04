using ACME.Data.Models;
using System.Collections.Generic;

namespace ACME.Data.Interfaces
{

    // Interface used for CRUD operations for the product repository
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> PreferredProducts { get; }
        Product GetProductById(int productId);
        Product Add(Product product);
        Product Edit(Product product);
        Product Delete(int id);
    }
}
