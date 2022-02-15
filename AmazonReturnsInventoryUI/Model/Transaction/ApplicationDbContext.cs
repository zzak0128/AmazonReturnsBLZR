using System;
using System.Collections.Generic;
using AmazonReturnsInventoryLibrary.Orders;
using Microsoft.EntityFrameworkCore;

namespace AmazonReturnsInventoryLibrary.Transactions
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Transaction>().Property(p => p.Type).HasConversion<string>();

            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().Property(o => o.Carrier).HasConversion<string>();
            modelBuilder.Entity<Order>().Property(o => o.Status).HasConversion<string>();

            modelBuilder.Entity<Transaction>().HasData(GetTransactions());
            modelBuilder.Entity<Order>().HasData(GetOrders());
            base.OnModelCreating(modelBuilder);
        }

        private List<Transaction> GetTransactions()
        {
            return new List<Transaction>
            {
                new Transaction { TransactionID = 1, Description = "MyFirst Transaction", Type = TransactionType.Income,Quantity = 1, Amount = 20.55}
            };
        }

        private List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order { OrderID = 1, Items = new List<Item>(), CustomerName = "George Constanza", Street1 = "504th Street", Street2 = "PO Box 1234", City = "New York", State = "New York", ZipCode = "55660", Carrier=ShippingCarrier.FedEx, Status=OrderStatus.Shipped }
            };
        }
    }
}
