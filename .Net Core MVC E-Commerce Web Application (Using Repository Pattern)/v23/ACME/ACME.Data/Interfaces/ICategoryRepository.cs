using ACME.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Data.Interfaces
{

    // Interface used for CRUD operations for the category repository
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        List<Category> GetCategories();
        Category Add(Category category);
        Category Edit(Category category);
        Category Delete(int id);
    }
}
