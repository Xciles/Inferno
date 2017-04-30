using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inferno.BurnApi.Migrations
{
    public partial class NullableId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drones_DroneAssignments_ActiveDroneAssignmentId",
                table: "Drones");

            migrationBuilder.DropForeignKey(
                name: "FK_FireReports_DroneAssignments_DroneAssignmentId",
                table: "FireReports");

            migrationBuilder.AlterColumn<int>(
                name: "DroneAssignmentId",
                table: "FireReports",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ActiveDroneAssignmentId",
                table: "Drones",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Drones_DroneAssignments_ActiveDroneAssignmentId",
                table: "Drones",
                column: "ActiveDroneAssignmentId",
                principalTable: "DroneAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FireReports_DroneAssignments_DroneAssignmentId",
                table: "FireReports",
                column: "DroneAssignmentId",
                principalTable: "DroneAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drones_DroneAssignments_ActiveDroneAssignmentId",
                table: "Drones");

            migrationBuilder.DropForeignKey(
                name: "FK_FireReports_DroneAssignments_DroneAssignmentId",
                table: "FireReports");

            migrationBuilder.AlterColumn<int>(
                name: "DroneAssignmentId",
                table: "FireReports",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActiveDroneAssignmentId",
                table: "Drones",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drones_DroneAssignments_ActiveDroneAssignmentId",
                table: "Drones",
                column: "ActiveDroneAssignmentId",
                principalTable: "DroneAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireReports_DroneAssignments_DroneAssignmentId",
                table: "FireReports",
                column: "DroneAssignmentId",
                principalTable: "DroneAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
