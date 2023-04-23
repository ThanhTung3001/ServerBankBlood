using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class MigrationDbForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_User_AppUserId",
                schema: "Identity",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_AppUserId",
                schema: "Identity",
                table: "UserInfo");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Identity",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "Identity",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                schema: "Identity",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                schema: "Identity",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaRegister",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaRegister_Media_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "Identity",
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaRegister_Register_RegisterId",
                        column: x => x.RegisterId,
                        principalSchema: "Identity",
                        principalTable: "Register",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    PublicTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Identity",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventUserSub",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserInfoId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUserSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventUserSub_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "Identity",
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUserSub_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalSchema: "Identity",
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTag",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTag_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "Identity",
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "Identity",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogTag",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogTag_Blog_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "Identity",
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "Identity",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserInfoId",
                schema: "Identity",
                table: "User",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_BlogId",
                schema: "Identity",
                table: "Media",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_EventId",
                schema: "Identity",
                table: "Media",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_CategoryId",
                schema: "Identity",
                table: "Blog",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_BlogId",
                schema: "Identity",
                table: "BlogTag",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_TagId",
                schema: "Identity",
                table: "BlogTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTag_EventId",
                schema: "Identity",
                table: "EventTag",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTag_TagId",
                schema: "Identity",
                table: "EventTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserSub_EventId",
                schema: "Identity",
                table: "EventUserSub",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserSub_UserInfoId",
                schema: "Identity",
                table: "EventUserSub",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRegister_MediaId",
                schema: "Identity",
                table: "MediaRegister",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRegister_RegisterId",
                schema: "Identity",
                table: "MediaRegister",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Blog_BlogId",
                schema: "Identity",
                table: "Media",
                column: "BlogId",
                principalSchema: "Identity",
                principalTable: "Blog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Event_EventId",
                schema: "Identity",
                table: "Media",
                column: "EventId",
                principalSchema: "Identity",
                principalTable: "Event",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserInfo_UserInfoId",
                schema: "Identity",
                table: "User",
                column: "UserInfoId",
                principalSchema: "Identity",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Blog_BlogId",
                schema: "Identity",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Event_EventId",
                schema: "Identity",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserInfo_UserInfoId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropTable(
                name: "BlogTag",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "EventTag",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "EventUserSub",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "MediaRegister",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Blog",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_User_UserInfoId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Media_BlogId",
                schema: "Identity",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_EventId",
                schema: "Identity",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Identity",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "Identity",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "BlogId",
                schema: "Identity",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "Identity",
                table: "Media");

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
    }
}
