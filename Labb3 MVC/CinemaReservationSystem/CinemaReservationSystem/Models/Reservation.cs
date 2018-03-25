using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Range(1,12)]
        public int Tickets { get; set; }
        public Screening Screening { get; set; }
    }
}
