using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class MirationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_BloodGroup_BloodGroupId",
                schema: "Identity",
                table: "Register");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Identity",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Identity",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Identity",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                schema: "Identity",
                newName: "UserInfo");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Identity",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Identity",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Identity",
                newName: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Register",
                schema: "Identity",
                newName: "Register");

            migrationBuilder.RenameTable(
                name: "Media",
                schema: "Identity",
                newName: "Media");

            migrationBuilder.RenameTable(
                name: "Hospital",
                schema: "Identity",
                newName: "Hospital");

            migrationBuilder.RenameTable(
                name: "BloodGroup",
                schema: "Identity",
                newName: "BloodGroup");

            migrationBuilder.AlterColumn<int>(
                name: "BloodGroupId",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_BloodGroup_BloodGroupId",
                table: "Register",
                column: "BloodGroupId",
                principalTable: "BloodGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_BloodGroup_BloodGroupId",
                table: "Register");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "UserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "UserInfo",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "UserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "RoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Role",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Register",
                newName: "Register",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Media",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Hospital",
                newName: "Hospital",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "BloodGroup",
                newName: "BloodGroup",
                newSchema: "Identity");

            migrationBuilder.AlterColumn<int>(
                name: "BloodGroupId",
                schema: "Identity",
                table: "Register",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_BloodGroup_BloodGroupId",
                schema: "Identity",
                table: "Register",
                column: "BloodGroupId",
                principalSchema: "Identity",
                principalTable: "BloodGroup",
                principalColumn: "Id");
        }
    }
}
