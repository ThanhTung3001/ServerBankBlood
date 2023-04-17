using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class AddRelationshipForRegisterForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registers_BloodGroups_BloodGroupId",
                table: "Registers");

            migrationBuilder.AlterColumn<int>(
                name: "BloodGroupId",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_BloodGroups_BloodGroupId",
                table: "Registers",
                column: "BloodGroupId",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registers_BloodGroups_BloodGroupId",
                table: "Registers");

            migrationBuilder.AlterColumn<int>(
                name: "BloodGroupId",
                table: "Registers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_BloodGroups_BloodGroupId",
                table: "Registers",
                column: "BloodGroupId",
                principalTable: "BloodGroups",
                principalColumn: "Id");
        }
    }
}
