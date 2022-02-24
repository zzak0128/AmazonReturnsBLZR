using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonReturnsInventoryUI.Migrations
{
    public partial class AddOrderShippingCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ShippingCost",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingCost",
                table: "Orders");
        }
    }
}
