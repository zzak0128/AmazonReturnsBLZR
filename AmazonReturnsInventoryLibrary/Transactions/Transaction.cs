using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonReturnsInventoryLibrary.Transactions
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        [Required]
        public string Description { get; set; }
        public TransactionType Type { get; set; } //ENUM Expense or Income
        [Required]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
    }
}
