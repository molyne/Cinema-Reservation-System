using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaReservationSystem.Migrations
{
    public partial class ChangedResevation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScreeningId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tickets",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ScreeningId",
                table: "Reservations",
                column: "ScreeningId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Screenings_ScreeningId",
                table: "Reservations",
                column: "ScreeningId",
                principalTable: "Screenings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Screenings_ScreeningId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ScreeningId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ScreeningId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Tickets",
                table: "Reservations");
        }
    }
}
