using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class AddStatusAndMediaForRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_RegisterId",
                table: "Medias",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Registers_RegisterId",
                table: "Medias",
                column: "RegisterId",
                principalTable: "Registers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Registers_RegisterId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_RegisterId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Medias");
        }
    }
}
