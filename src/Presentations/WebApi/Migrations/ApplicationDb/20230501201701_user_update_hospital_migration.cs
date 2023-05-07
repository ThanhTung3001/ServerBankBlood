using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class user_update_hospital_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "UserInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId1",
                table: "UserInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_HospitalId",
                table: "UserInfo",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_HospitalId1",
                table: "UserInfo",
                column: "HospitalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Hospitals_HospitalId",
                table: "UserInfo",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Hospitals_HospitalId1",
                table: "UserInfo",
                column: "HospitalId1",
                principalTable: "Hospitals",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Hospitals_HospitalId",
                table: "UserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Hospitals_HospitalId1",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_HospitalId",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_HospitalId1",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "HospitalId1",
                table: "UserInfo");
        }
    }
}
