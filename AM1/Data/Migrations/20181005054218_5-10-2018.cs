using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class _5102018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Event");
        }
    }
}
