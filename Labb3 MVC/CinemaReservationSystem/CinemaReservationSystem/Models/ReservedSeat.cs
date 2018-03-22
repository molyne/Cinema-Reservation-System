using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationSystem.Models
{
    public class ReservedSeat
    {
        public int Id { get; set; }
        public Seat Seat { get; set; }
        public Reservation Reservation { get; set; }
        public Screening Screening { get; set; }
        
    }
}
