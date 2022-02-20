using System.Collections.Generic;
using AmazonReturnsInventoryLibrary.Items;
using AmazonReturnsInventoryLibrary.Orders;
using AmazonReturnsInventoryLibrary.SupplyItems;
using AmazonReturnsInventoryLibrary.Transactions;
using Microsoft.EntityFrameworkCore;

namespace AmazonReturnsInventoryUI.Model
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<SupplyItem> SupplyItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Transaction>().Property(p => p.Type).HasConversion<string>();

            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().Property(o => o.Carrier).HasConversion<string>();
            modelBuilder.Entity<Order>().Property(o => o.Status).HasConversion<string>();

            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Item>().Property(i => i.Category).HasConversion<string>();
            modelBuilder.Entity<Item>().Property(i => i.Condition).HasConversion<string>();

            modelBuilder.Entity<SupplyItem>().ToTable("SupplyItems");

            modelBuilder.Entity<Transaction>().HasData(GetTransactions());
            modelBuilder.Entity<Order>().HasData(GetOrders());
            modelBuilder.Entity<Item>().HasData(GetItems());
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

        private List<Item> GetItems()
        {
            return new List<Item>
            {
                new Item { ItemID = 1, SKU="4492749273", Title = "Dog Bed", Description = "FurBuddy 26'' Dog Bed", Category = Category.Pet, Condition = Condition.Used, Quantity = 1, Price = 25.99 }
            };
        }
    }
}
