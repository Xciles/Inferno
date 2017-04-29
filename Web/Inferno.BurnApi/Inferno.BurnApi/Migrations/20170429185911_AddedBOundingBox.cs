using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inferno.BurnApi.Migrations
{
    public partial class AddedBOundingBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoundingboxAsJson",
                table: "FireReports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FireReports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoundingboxAsJson",
                table: "FireReports");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FireReports");
        }
    }
}
