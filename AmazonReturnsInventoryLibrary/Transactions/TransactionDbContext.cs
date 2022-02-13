﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AmazonReturnsInventoryLibrary.Transactions
{
    public class TransactionDbContext: DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(GetTransactions());
            base.OnModelCreating(modelBuilder);
        }

        private List<Transaction> GetTransactions()
        {
            return new List<Transaction>
            {
                new Transaction { TransactionID = 1, Description = "MyFirst Transaction", Type = TransactionType.Income, Amount = 20.55}
            };
        }
    }
}
