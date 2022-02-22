using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AmazonReturnsInventoryLibrary.Orders;
using System.ComponentModel.DataAnnotations;

namespace AmazonReturnsInventoryLibrary.Items
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Condition Condition { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
