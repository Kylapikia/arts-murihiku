using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "PoliceVetCheck",
                table: "VolForm",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "FirstAidCertificate",
                table: "VolForm",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PoliceVetCheck",
                table: "VolForm",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "FirstAidCertificate",
                table: "VolForm",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
