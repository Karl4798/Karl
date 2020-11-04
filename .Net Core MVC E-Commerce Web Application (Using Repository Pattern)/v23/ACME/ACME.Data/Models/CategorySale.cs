using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Data.Models
{

    // Model used to store category sale fields (sales for each category)
    public class CategorySale
    {

        public string CategoryName { get; set; }
        public int Sales { get; set; }

    }
}
