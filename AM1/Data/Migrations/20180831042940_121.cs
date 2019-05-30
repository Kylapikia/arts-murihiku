using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class _121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtistDescription",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CreativeSpace",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Design",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeviantArt",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Education",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Festival",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Film",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Individual",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Literacy",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MixedMedia",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MultiCultural",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Music",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Organisation",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Paint",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pasifika",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Photography",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PublicArt",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sculpture",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Textiles",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Theatre",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ToiMaori",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArtsDir",
                columns: table => new
                {
                    ArtsDirID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Design = table.Column<bool>(nullable: false),
                    Education = table.Column<bool>(nullable: false),
                    Film = table.Column<bool>(nullable: false),
                    Literacy = table.Column<bool>(nullable: false),
                    MixedMedia = table.Column<bool>(nullable: false),
                    MultiCultural = table.Column<bool>(nullable: false),
                    Music = table.Column<bool>(nullable: false),
                    Paint = table.Column<bool>(nullable: false),
                    Pasifika = table.Column<bool>(nullable: false),
                    Photography = table.Column<bool>(nullable: false),
                    Picture1 = table.Column<string>(nullable: true),
                    Picture2 = table.Column<string>(nullable: true),
                    Picture3 = table.Column<string>(nullable: true),
                    Picture4 = table.Column<string>(nullable: true),
                    Picture5 = table.Column<string>(nullable: true),
                    ProfileLink = table.Column<string>(nullable: true),
                    PublicArt = table.Column<bool>(nullable: false),
                    Sculpture = table.Column<bool>(nullable: false),
                    Textiles = table.Column<bool>(nullable: false),
                    Theatre = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtsDir", x => x.ArtsDirID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtsDir");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ArtistDescription",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreativeSpace",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeviantArt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Festival",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Film",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Individual",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Literacy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MixedMedia",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MultiCultural",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Music",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Organisation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Paint",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pasifika",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Photography",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PublicArt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sculpture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Textiles",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Theatre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ToiMaori",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WebsiteLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "AspNetUsers");
        }
    }
}
