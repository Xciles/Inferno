using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inferno.BurnApi.Migrations
{
    public partial class RemovedDroneAssignmentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireReports_DroneAssignments_DroneAssignmentId",
                table: "FireReports");

            migrationBuilder.DropIndex(
                name: "IX_FireReports_DroneAssignmentId",
                table: "FireReports");

            migrationBuilder.DropColumn(
                name: "DroneAssignmentId",
                table: "FireReports");

            migrationBuilder.AddColumn<int>(
                name: "FireReportId",
                table: "DroneAssignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DroneAssignments_FireReportId",
                table: "DroneAssignments",
                column: "FireReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_DroneAssignments_FireReports_FireReportId",
                table: "DroneAssignments",
                column: "FireReportId",
                principalTable: "FireReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DroneAssignments_FireReports_FireReportId",
                table: "DroneAssignments");

            migrationBuilder.DropIndex(
                name: "IX_DroneAssignments_FireReportId",
                table: "DroneAssignments");

            migrationBuilder.DropColumn(
                name: "FireReportId",
                table: "DroneAssignments");

            migrationBuilder.AddColumn<int>(
                name: "DroneAssignmentId",
                table: "FireReports",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FireReports_DroneAssignmentId",
                table: "FireReports",
                column: "DroneAssignmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FireReports_DroneAssignments_DroneAssignmentId",
                table: "FireReports",
                column: "DroneAssignmentId",
                principalTable: "DroneAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
