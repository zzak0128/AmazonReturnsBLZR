﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AmazonReturnsInventoryLibrary.Orders;

namespace AmazonReturnsInventoryLibrary
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Condition Condition { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
