using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class _2423 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefOne",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "RefOneContact",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "RefTwo",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "RefTwoContact",
                table: "VolForm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefOne",
                table: "VolForm",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefOneContact",
                table: "VolForm",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefTwo",
                table: "VolForm",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefTwoContact",
                table: "VolForm",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
