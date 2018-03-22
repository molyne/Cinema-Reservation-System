using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationSystem.Models
{
    public class Screening
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Auditorium Auditorium { get; set; }
        public DateTime ScreeningTime { get; set; }
    }
}
