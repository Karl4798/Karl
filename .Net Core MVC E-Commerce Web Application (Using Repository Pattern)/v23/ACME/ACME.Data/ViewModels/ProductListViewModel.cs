using ACME.Data.Models;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;

namespace ACME.Data.ViewModels
{

    // View Model used to define fields for listing products
    public class ProductListViewModel
    {
        public PagingList<Product> PagingProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string CurrentCategory { get; set; }
        public string SortBy { get; set; }
        public Dictionary<string, string> Sorts { get; set; }
        public int Count { get; set; }
    }
}
