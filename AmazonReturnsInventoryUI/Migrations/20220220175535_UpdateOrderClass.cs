using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonReturnsInventoryUI.Migrations
{
    public partial class UpdateOrderClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.AddColumn<double>(
                name: "OrderTotal",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "Carrier", "City", "CustomerName", "State", "Status", "Street1", "Street2", "ZipCode" },
                values: new object[] { 1, "FedEx", "New York", "George Constanza", "New York", "Shipped", "504th Street", "PO Box 1234", "55660" });
        }
    }
}
