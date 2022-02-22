using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonReturnsInventoryLibrary.SupplyItems
{
    public class SupplyItem
    {
        [Key]
        public int SupplyID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Unit { get; set; }
        [Required]
        public double Price { get; set; }

        public SupplyItem()
        {
        }
    }
}
