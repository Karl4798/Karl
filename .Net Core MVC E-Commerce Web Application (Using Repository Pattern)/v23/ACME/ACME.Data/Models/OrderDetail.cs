﻿namespace ACME.Data.Models
{

    // Model used to store order detail fields
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
