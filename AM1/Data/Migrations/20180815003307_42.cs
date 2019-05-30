using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class _42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventDate",
                table: "Event",
                newName: "StartEventDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishEventDate",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "FullDay",
                table: "Event",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThemeColour",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishEventDate",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "FullDay",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ThemeColour",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "StartEventDate",
                table: "Event",
                newName: "EventDate");
        }
    }
}
