using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonReturnsInventoryLibrary.SupplyItems
{
    public class SupplyItem
    {
        [Key]
        public int SupplyID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Title needs to be 50 characters or less.")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Unit { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
