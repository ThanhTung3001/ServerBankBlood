using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class DbPrimary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Blogs_BlogsId",
                table: "BlogTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Tags_TagsId",
                table: "BlogTag");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTag_Events_EventsId",
                table: "EventTag");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTag_Tags_TagsId",
                table: "EventTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Hospitals_HospitalId",
                table: "Registers");

            migrationBuilder.DropTable(
                name: "RegisterUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTag",
                table: "EventTag");

            migrationBuilder.DropIndex(
                name: "IX_EventTag_TagsId",
                table: "EventTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogTag",
                table: "BlogTag");

            migrationBuilder.DropIndex(
                name: "IX_BlogTag_TagsId",
                table: "BlogTag");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "EventTag",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "EventTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "BlogTag",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BlogsId",
                table: "BlogTag",
                newName: "TagId");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventTag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "EventTag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateUTC",
                table: "EventTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "EventTag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "EventTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "BlogTag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "BlogTag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateUTC",
                table: "BlogTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "BlogTag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "BlogTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTag",
                table: "EventTag",
                columns: new[] { "EventId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogTag",
                table: "BlogTag",
                columns: new[] { "BlogId", "TagId" });

            migrationBuilder.CreateTable(
                name: "UserInfo",
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
                    Start = table.Column<int>(type: "int", nullable: false),
                    TotalDonate = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Iccid = table.Column<long>(type: "bigint", nullable: false),
                    BloodId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_BloodGroups_BloodId",
                        column: x => x.BloodId,
                        principalTable: "BloodGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registers_UserId",
                table: "Registers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTag_TagId",
                table: "EventTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_TagId",
                table: "BlogTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_BloodId",
                table: "UserInfo",
                column: "BloodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Blogs_BlogId",
                table: "BlogTag",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Tags_TagId",
                table: "BlogTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTag_Events_EventId",
                table: "EventTag",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTag_Tags_TagId",
                table: "EventTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Hospitals_HospitalId",
                table: "Registers",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_UserInfo_UserId",
                table: "Registers",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Blogs_BlogId",
                table: "BlogTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Tags_TagId",
                table: "BlogTag");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTag_Events_EventId",
                table: "EventTag");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTag_Tags_TagId",
                table: "EventTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Hospitals_HospitalId",
                table: "Registers");

            migrationBuilder.DropForeignKey(
                name: "FK_Registers_UserInfo_UserId",
                table: "Registers");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_Registers_UserId",
                table: "Registers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTag",
                table: "EventTag");

            migrationBuilder.DropIndex(
                name: "IX_EventTag_TagId",
                table: "EventTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogTag",
                table: "BlogTag");

            migrationBuilder.DropIndex(
                name: "IX_BlogTag_TagId",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventTag");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "EventTag");

            migrationBuilder.DropColumn(
                name: "CreateUTC",
                table: "EventTag");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "EventTag");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "EventTag");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "CreateUTC",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "BlogTag");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EventTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "EventTag",
                newName: "EventsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BlogTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "BlogTag",
                newName: "BlogsId");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Registers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Blogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTag",
                table: "EventTag",
                columns: new[] { "EventsId", "TagsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogTag",
                table: "BlogTag",
                columns: new[] { "BlogsId", "TagsId" });

            migrationBuilder.CreateTable(
                name: "RegisterUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterId = table.Column<int>(type: "int", nullable: false),
                    RegisterId1 = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterUser_Registers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterUser_Registers_RegisterId1",
                        column: x => x.RegisterId1,
                        principalTable: "Registers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTag_TagsId",
                table: "EventTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_TagsId",
                table: "BlogTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUser_RegisterId",
                table: "RegisterUser",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterUser_RegisterId1",
                table: "RegisterUser",
                column: "RegisterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Blogs_BlogsId",
                table: "BlogTag",
                column: "BlogsId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Tags_TagsId",
                table: "BlogTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTag_Events_EventsId",
                table: "EventTag",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTag_Tags_TagsId",
                table: "EventTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Hospitals_HospitalId",
                table: "Registers",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");
        }
    }
}
