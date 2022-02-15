﻿// <auto-generated />
using System;
using AmazonReturnsInventoryLibrary.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AmazonReturnsInventoryUI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class TransactionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("AmazonReturnsInventoryLibrary.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AmazonReturnsInventoryLibrary.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Condition")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SKU")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("OrderID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("AmazonReturnsInventoryLibrary.Orders.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Carrier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street2")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            Carrier = "FedEx",
                            City = "New York",
                            CustomerName = "George Constanza",
                            State = "New York",
                            Status = "Shipped",
                            Street1 = "504th Street",
                            Street2 = "PO Box 1234",
                            ZipCode = "55660"
                        });
                });

            modelBuilder.Entity("AmazonReturnsInventoryLibrary.Transactions.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TransactionID");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionID = 1,
                            Amount = 20.550000000000001,
                            Description = "MyFirst Transaction",
                            Quantity = 1,
                            Type = "Income"
                        });
                });

            modelBuilder.Entity("AmazonReturnsInventoryLibrary.Item", b =>
                {
                    b.HasOne("AmazonReturnsInventoryLibrary.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("AmazonReturnsInventoryLibrary.Orders.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderID");
                });
#pragma warning restore 612, 618
        }
    }
}
