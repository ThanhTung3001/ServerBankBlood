using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class rollback_migration_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserInfo_UserInfoId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserInfoId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                schema: "Identity",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_AppUserId",
                schema: "Identity",
                table: "UserInfo",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_User_AppUserId",
                schema: "Identity",
                table: "UserInfo",
                column: "AppUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_User_AppUserId",
                schema: "Identity",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_AppUserId",
                schema: "Identity",
                table: "UserInfo");

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserInfoId",
                schema: "Identity",
                table: "User",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserInfo_UserInfoId",
                schema: "Identity",
                table: "User",
                column: "UserInfoId",
                principalSchema: "Identity",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }
    }
}
