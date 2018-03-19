using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationSystem.Models
{
    public class ReservedSeat
    {
        public int Id { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Screening Screening { get; set; }
        
    }
}
