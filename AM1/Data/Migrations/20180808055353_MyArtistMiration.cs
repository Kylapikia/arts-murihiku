using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class MyArtistMiration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactMethod",
                table: "VolForm",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "VolForm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstAidCertificate",
                table: "VolForm",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "VolForm",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "VolForm",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "VolForm",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "VolForm",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PoliceVetCheck",
                table: "VolForm",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreviousExperience",
                table: "VolForm",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "TermsAndConditions",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EventCategory",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "Event",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Event",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventPicture",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Blog",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogPic",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogPost",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Blog",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Blog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Blog",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactMethod",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "FirstAidCertificate",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "PoliceVetCheck",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "PreviousExperience",
                table: "VolForm");

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

            migrationBuilder.DropColumn(
                name: "TermsAndConditions",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "EventCategory",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventPicture",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "BlogPic",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "BlogPost",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Blog");
        }
    }
}
