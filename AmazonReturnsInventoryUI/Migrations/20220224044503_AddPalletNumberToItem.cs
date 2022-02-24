using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonReturnsInventoryUI.Migrations
{
    public partial class AddPalletNumberToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PalletNumber",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "PalletNumber",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PalletNumber",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "PalletNumber",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
