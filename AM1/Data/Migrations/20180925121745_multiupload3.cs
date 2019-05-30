using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class multiupload3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumID = table.Column<string>(nullable: false),
                    AlbumCreatedTime = table.Column<DateTime>(nullable: false),
                    AlbumDescription = table.Column<string>(nullable: true),
                    AlbumOwner = table.Column<string>(nullable: true),
                    AlbumTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumID);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoID = table.Column<string>(nullable: false),
                    FileFullPath = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    PhotoAlbumID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
