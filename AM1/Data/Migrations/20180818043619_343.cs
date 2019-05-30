using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AM1.Data.Migrations
{
    public partial class _343 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AppDevelopment",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AssistanceExhibitionsGen",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AssistanceExhibitionsGen1",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AssistanceVisitors",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AssistanceVisitors1",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AssistanceWorkshops",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AssistanceWorkshops1",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Catering",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Costuming",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Facebook",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FrontOfHouse",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hair",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Instagram",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Lighting",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MakeUp",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Prompt",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Props",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PublicityAndPromotion",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PublicityAndPromotion1",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PublicityAndPromotion2",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SetBuilding",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SnapChat",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sound",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StageManagement",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SupportOpenings",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SupportOpenings1",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Twitter",
                table: "VolForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WebsiteDevelopment",
                table: "VolForm",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppDevelopment",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "AssistanceExhibitionsGen",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "AssistanceExhibitionsGen1",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "AssistanceVisitors",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "AssistanceVisitors1",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "AssistanceWorkshops",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "AssistanceWorkshops1",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Catering",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Costuming",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "FrontOfHouse",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Hair",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Lighting",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "MakeUp",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Prompt",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Props",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "PublicityAndPromotion",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "PublicityAndPromotion1",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "PublicityAndPromotion2",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "SetBuilding",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "SnapChat",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Sound",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "StageManagement",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "SupportOpenings",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "SupportOpenings1",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "VolForm");

            migrationBuilder.DropColumn(
                name: "WebsiteDevelopment",
                table: "VolForm");
        }
    }
}
