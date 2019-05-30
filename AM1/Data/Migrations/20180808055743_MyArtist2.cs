using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class MyArtist2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyArtist",
                columns: table => new
                {
                    MyArtistID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    ArtistDescription = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CreativeSpace = table.Column<bool>(nullable: false),
                    Design = table.Column<bool>(nullable: false),
                    DeviantArt = table.Column<string>(nullable: true),
                    Education = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FacebookLink = table.Column<string>(nullable: true),
                    Festival = table.Column<bool>(nullable: false),
                    Film = table.Column<bool>(nullable: false),
                    Individual = table.Column<bool>(nullable: false),
                    InstagramLink = table.Column<string>(nullable: true),
                    Literacy = table.Column<bool>(nullable: false),
                    MixedMedia = table.Column<bool>(nullable: false),
                    MultiCultural = table.Column<bool>(nullable: false),
                    Music = table.Column<bool>(nullable: false),
                    Organisation = table.Column<bool>(nullable: false),
                    Paint = table.Column<bool>(nullable: false),
                    Pasifika = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Photography = table.Column<bool>(nullable: false),
                    ProfilePic = table.Column<string>(nullable: true),
                    PublicArt = table.Column<bool>(nullable: false),
                    Sculpture = table.Column<bool>(nullable: false),
                    Textiles = table.Column<bool>(nullable: false),
                    Theatre = table.Column<bool>(nullable: false),
                    ToiMaori = table.Column<bool>(nullable: false),
                    WebsiteLink = table.Column<string>(nullable: true),
                    YoutubeLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyArtist", x => x.MyArtistID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyArtist");
        }
    }
}
