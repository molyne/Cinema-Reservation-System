using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaReservationSystem.Models;

namespace CinemaReservationSystem
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet <ReservedSeat> ReservedSeats { get; set; }
        public DbSet <Reservation> Reservations { get; set; }
    }
}
