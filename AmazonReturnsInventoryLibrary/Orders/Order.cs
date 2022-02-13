using System;
using System.Collections.Generic;

namespace AmazonReturnsInventoryLibrary.Orders
{
    public class Order
    {
        public int OrderID { get; set; }
        public List<int> ItemIDs { get; set; } //Foreign Key - Items in the order
        public string ShippingCarrier { get; set; }
        public string CustomerName { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public ShippingCarrier Carrier { get; set; }

        public Order()
        {
        }
    }
}
