using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ProductCommon
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base("name=ProductsContext")
        {
        }

        public ProductsContext(string connString) : base(connString)
        {
        }

        public System.Data.Entity.DbSet<Product> Products { get; set; }
    
    }
}
