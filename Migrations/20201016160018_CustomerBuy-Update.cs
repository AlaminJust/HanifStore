using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HanifStore.Migrations
{
    public partial class CustomerBuyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "CustomersBuys",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomersBuys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "CustomersBuys");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CustomersBuys");
        }
    }
}
