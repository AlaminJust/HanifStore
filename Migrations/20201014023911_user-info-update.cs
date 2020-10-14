using Microsoft.EntityFrameworkCore.Migrations;

namespace HanifStore.Migrations
{
    public partial class userinfoupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserInformation");
        }
    }
}
