using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonReturnsInventoryUI.Migrations
{
    public partial class AddSellingFeesToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SellingFees",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "Category",
                value: "PetSupplies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellingFees",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "Category",
                value: "Pet");
        }
    }
}
