using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class MigrationAppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_BloodGroups_BloodId",
                table: "UserInfo");

            migrationBuilder.AlterColumn<int>(
                name: "BloodId",
                table: "UserInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_BloodGroups_BloodId",
                table: "UserInfo",
                column: "BloodId",
                principalTable: "BloodGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_BloodGroups_BloodId",
                table: "UserInfo");

            migrationBuilder.AlterColumn<int>(
                name: "BloodId",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_BloodGroups_BloodId",
                table: "UserInfo",
                column: "BloodId",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
