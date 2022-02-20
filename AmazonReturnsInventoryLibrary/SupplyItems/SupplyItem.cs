using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonReturnsInventoryUI.Model.SupplyItems
{
    public class SupplyItem
    {
        [Key]
        public int SupplyID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public SupplyItem()
        {
        }
    }
}
