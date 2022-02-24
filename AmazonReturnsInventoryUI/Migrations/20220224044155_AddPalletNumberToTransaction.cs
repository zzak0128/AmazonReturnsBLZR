using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonReturnsInventoryUI.Migrations
{
    public partial class AddPalletNumberToTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PalletNumber",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PalletNumber",
                table: "Transactions");
        }
    }
}
