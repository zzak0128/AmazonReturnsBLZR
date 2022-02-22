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
        [MaxLength(50, ErrorMessage = "Title needs to be less than 50 characters.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Condition Condition { get; set; }
        public string SKU { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [DataType(DataType.Currency)]
        public double SoldPrice { get; set; } = 0.00;
    }
}
