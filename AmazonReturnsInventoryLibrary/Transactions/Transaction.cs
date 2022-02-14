using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonReturnsInventoryLibrary.Transactions
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; } //ENUM Expense or Income
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
