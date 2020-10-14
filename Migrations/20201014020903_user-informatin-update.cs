using Microsoft.EntityFrameworkCore.Migrations;

namespace HanifStore.Migrations
{
    public partial class userinformatinupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userInformation_AspNetUsers_IdentityUserId",
                table: "userInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userInformation",
                table: "userInformation");

            migrationBuilder.RenameTable(
                name: "userInformation",
                newName: "UserInformation");

            migrationBuilder.RenameIndex(
                name: "IX_userInformation_IdentityUserId",
                table: "UserInformation",
                newName: "IX_UserInformation_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInformation",
                table: "UserInformation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInformation_AspNetUsers_IdentityUserId",
                table: "UserInformation",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInformation_AspNetUsers_IdentityUserId",
                table: "UserInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInformation",
                table: "UserInformation");

            migrationBuilder.RenameTable(
                name: "UserInformation",
                newName: "userInformation");

            migrationBuilder.RenameIndex(
                name: "IX_UserInformation_IdentityUserId",
                table: "userInformation",
                newName: "IX_userInformation_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userInformation",
                table: "userInformation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userInformation_AspNetUsers_IdentityUserId",
                table: "userInformation",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
