using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Inferno.BurnApi.Data;
using Inferno.BurnApi.Domain.Enums;

namespace Inferno.BurnApi.Migrations
{
    [DbContext(typeof(InfernoDbContext))]
    [Migration("20170429185911_AddedBOundingBox")]
    partial class AddedBOundingBox
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inferno.BurnApi.Domain.Drone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActiveDroneAssignmentId");

                    b.Property<bool>("Available");

                    b.Property<string>("BaseLocationAsJson");

                    b.Property<int>("BatteryLevel");

                    b.Property<string>("CurrentLocationAsJson");

                    b.HasKey("Id");

                    b.HasIndex("ActiveDroneAssignmentId")
                        .IsUnique();

                    b.ToTable("Drones");
                });

            modelBuilder.Entity("Inferno.BurnApi.Domain.DroneAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DroneDispatchedAt");

                    b.Property<DateTime?>("FinishedAt");

                    b.Property<int>("Urgency");

                    b.HasKey("Id");

                    b.ToTable("DroneAssignments");
                });

            modelBuilder.Entity("Inferno.BurnApi.Domain.FireReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BoundingboxAsJson");

                    b.Property<string>("CoordinateAsJson");

                    b.Property<string>("Description");

                    b.Property<int>("DroneAssignmentId");

                    b.Property<int>("FireSeverity");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("DroneAssignmentId")
                        .IsUnique();

                    b.ToTable("FireReports");
                });

            modelBuilder.Entity("Inferno.BurnApi.Domain.Drone", b =>
                {
                    b.HasOne("Inferno.BurnApi.Domain.DroneAssignment", "ActiveDroneAssignment")
                        .WithOne("Drone")
                        .HasForeignKey("Inferno.BurnApi.Domain.Drone", "ActiveDroneAssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inferno.BurnApi.Domain.FireReport", b =>
                {
                    b.HasOne("Inferno.BurnApi.Domain.DroneAssignment", "DroneAssignment")
                        .WithOne("FireReport")
                        .HasForeignKey("Inferno.BurnApi.Domain.FireReport", "DroneAssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
