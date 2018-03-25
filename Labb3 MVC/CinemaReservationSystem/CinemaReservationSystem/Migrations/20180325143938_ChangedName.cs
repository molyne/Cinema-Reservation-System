using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaReservationSystem.Migrations
{
    public partial class ChangedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservedSeats",
                table: "Screenings",
                newName: "TicketsLeft");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketsLeft",
                table: "Screenings",
                newName: "ReservedSeats");
        }
    }
}
