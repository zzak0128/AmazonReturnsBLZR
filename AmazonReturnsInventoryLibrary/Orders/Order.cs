using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AmazonReturnsInventoryLibrary.Items;

namespace AmazonReturnsInventoryLibrary.Orders
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public List<Item> Items { get; set; } //Foreign Key - Items in the order
        [Required]
        public string CustomerName { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "Please use the 2 letter state initials.")]
        public string State { get; set; }
        [DataType(DataType.PostalCode)]
        [StringLength(10, ErrorMessage = "Please enter a valid ZipCode")]
        public string ZipCode { get; set; }
        public ShippingCarrier Carrier { get; set; }
        public OrderStatus Status { get; set; }
        [DataType(DataType.Currency)]
        public double OrderTotal { get; set; } = 0.00;
        [DataType(DataType.Currency)]
        public double ShippingCost { get; set; } = 0.00;
        [DataType(DataType.Currency)]
        public double SellingFees { get; set; } = 0.00;
    }
}
