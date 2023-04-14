using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class MigradeUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_User_ApplicationUserId",
                schema: "Identity",
                table: "Media");

            migrationBuilder.DropTable(
                name: "RegisterUser",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Media_ApplicationUserId",
                schema: "Identity",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Avatar",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Iccid",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Media");

            migrationBuilder.CreateTable(
                name: "BloodGroup",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urgent = table.Column<bool>(type: "bit", nullable: false),
                    Capacity = table.Column<long>(type: "bigint", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonateAmount = table.Column<int>(type: "int", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    TotalDonate = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Iccid = table.Column<long>(type: "bigint", nullable: false),
                    BloodId = table.Column<int>(type: "int", nullable: false),
                    BloodGroupId = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_BloodGroup_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalSchema: "Identity",
                        principalTable: "BloodGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserInfo_User_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Register",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroupId = table.Column<int>(type: "int", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Register_BloodGroup_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalSchema: "Identity",
                        principalTable: "BloodGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Register_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalSchema: "Identity",
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Register_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalSchema: "Identity",
                        principalTable: "UserInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Register_BloodGroupId",
                schema: "Identity",
                table: "Register",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_HospitalId",
                schema: "Identity",
                table: "Register",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_UserInfoId",
                schema: "Identity",
                table: "Register",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_AppUserId",
                schema: "Identity",
                table: "UserInfo",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_BloodGroupId",
                schema: "Identity",
                table: "UserInfo",
                column: "BloodGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Register",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserInfo",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "BloodGroup",
                schema: "Identity");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Iccid",
                schema: "Identity",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegisterUser",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterId = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterUser_User_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_ApplicationUserId",
                schema: "Identity",
                table: "Media",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUser_ApplicationUserId",
                schema: "Identity",
                table: "RegisterUser",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_User_ApplicationUserId",
                schema: "Identity",
                table: "Media",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
