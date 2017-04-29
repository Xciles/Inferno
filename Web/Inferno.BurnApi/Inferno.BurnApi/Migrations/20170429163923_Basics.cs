using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Inferno.BurnApi.Migrations
{
    public partial class Basics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DroneAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DroneDispatchedAt = table.Column<DateTime>(nullable: true),
                    FinishedAt = table.Column<DateTime>(nullable: true),
                    Urgency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneAssignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveDroneAssignmentId = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    BaseLocationAsJson = table.Column<string>(nullable: true),
                    BatteryLevel = table.Column<int>(nullable: false),
                    CurrentLocationAsJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drones_DroneAssignments_ActiveDroneAssignmentId",
                        column: x => x.ActiveDroneAssignmentId,
                        principalTable: "DroneAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoordinateAsJson = table.Column<string>(nullable: true),
                    DroneAssignmentId = table.Column<int>(nullable: false),
                    FireSeverity = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireReports_DroneAssignments_DroneAssignmentId",
                        column: x => x.DroneAssignmentId,
                        principalTable: "DroneAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drones_ActiveDroneAssignmentId",
                table: "Drones",
                column: "ActiveDroneAssignmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FireReports_DroneAssignmentId",
                table: "FireReports",
                column: "DroneAssignmentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drones");

            migrationBuilder.DropTable(
                name: "FireReports");

            migrationBuilder.DropTable(
                name: "DroneAssignments");
        }
    }
}
