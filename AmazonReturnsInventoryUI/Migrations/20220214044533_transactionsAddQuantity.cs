﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonReturnsInventoryUI.Migrations
{
    public partial class transactionsAddQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Transactions");
        }
    }
}
