using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class AddStatusAndMediaForRegister_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Registers_RegisterId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_RegisterId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Medias");

            migrationBuilder.CreateTable(
                name: "MediaRegister",
                columns: table => new
                {
                    RegisterId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaRegister", x => new { x.RegisterId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_MediaRegister_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaRegister_Registers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaRegister_MediaId",
                table: "MediaRegister",
                column: "MediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaRegister");

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
    }
}
