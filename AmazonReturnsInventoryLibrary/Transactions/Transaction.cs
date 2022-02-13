using System;
namespace AmazonReturnsInventoryLibrary.Transactions
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; } //ENUM Expense or Income
        public double Amount { get; set; }

        public Transaction()
        {
        }
    }
}
