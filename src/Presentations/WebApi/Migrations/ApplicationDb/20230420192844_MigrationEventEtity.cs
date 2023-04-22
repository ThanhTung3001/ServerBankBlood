using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.ApplicationDb
{
    public partial class MigrationEventEtity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUserSub_Events_EventId",
                table: "EventUserSub");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUserSub_UserInfo_UserInfoId",
                table: "EventUserSub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUserSub",
                table: "EventUserSub");

            migrationBuilder.RenameTable(
                name: "EventUserSub",
                newName: "EventUserSubs");

            migrationBuilder.RenameIndex(
                name: "IX_EventUserSub_UserInfoId",
                table: "EventUserSubs",
                newName: "IX_EventUserSubs_UserInfoId");

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "EventUserSubs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateUTC",
                table: "EventUserSubs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventUserSubs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "EventUserSubs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "EventUserSubs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUserSubs",
                table: "EventUserSubs",
                columns: new[] { "EventId", "UserInfoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserSubs_Events_EventId",
                table: "EventUserSubs",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserSubs_UserInfo_UserInfoId",
                table: "EventUserSubs",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUserSubs_Events_EventId",
                table: "EventUserSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUserSubs_UserInfo_UserInfoId",
                table: "EventUserSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUserSubs",
                table: "EventUserSubs");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "EventUserSubs");

            migrationBuilder.DropColumn(
                name: "CreateUTC",
                table: "EventUserSubs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventUserSubs");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "EventUserSubs");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "EventUserSubs");

            migrationBuilder.RenameTable(
                name: "EventUserSubs",
                newName: "EventUserSub");

            migrationBuilder.RenameIndex(
                name: "IX_EventUserSubs_UserInfoId",
                table: "EventUserSub",
                newName: "IX_EventUserSub_UserInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUserSub",
                table: "EventUserSub",
                columns: new[] { "EventId", "UserInfoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserSub_Events_EventId",
                table: "EventUserSub",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserSub_UserInfo_UserInfoId",
                table: "EventUserSub",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
