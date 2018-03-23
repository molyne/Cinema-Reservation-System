using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Tickets { get; set; }
        public Screening Screening { get; set; }
    }
}
