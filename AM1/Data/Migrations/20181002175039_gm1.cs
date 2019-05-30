using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class gm1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GMapModel",
                columns: table => new
                {
                    GMapID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FridayClose = table.Column<string>(nullable: true),
                    FridayOpen = table.Column<string>(nullable: true),
                    GAddress = table.Column<string>(nullable: true),
                    GDisciplines = table.Column<string>(nullable: true),
                    GLinkProfile = table.Column<string>(nullable: true),
                    GName = table.Column<string>(nullable: true),
                    GProfilePic = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Lng = table.Column<string>(nullable: true),
                    MondayClose = table.Column<string>(nullable: true),
                    MondayOpen = table.Column<string>(nullable: true),
                    SaturdayClose = table.Column<string>(nullable: true),
                    SaturdayOpen = table.Column<string>(nullable: true),
                    SundayClose = table.Column<string>(nullable: true),
                    SundayOpen = table.Column<string>(nullable: true),
                    ThursdayClose = table.Column<string>(nullable: true),
                    ThursdayOpen = table.Column<string>(nullable: true),
                    TuesdayClose = table.Column<string>(nullable: true),
                    TuesdayOpen = table.Column<string>(nullable: true),
                    WednesdayClose = table.Column<string>(nullable: true),
                    WednesdayOpen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMapModel", x => x.GMapID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GMapModel");
        }
    }
}
