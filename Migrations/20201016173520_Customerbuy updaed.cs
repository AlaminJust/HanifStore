using Microsoft.EntityFrameworkCore.Migrations;

namespace HanifStore.Migrations
{
    public partial class Customerbuyupdaed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Deposite",
                table: "CustomersBuys",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deposite",
                table: "CustomersBuys");
        }
    }
}
