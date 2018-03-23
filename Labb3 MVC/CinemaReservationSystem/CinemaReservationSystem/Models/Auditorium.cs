using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationSystem.Models
{
    public class Auditorium
    {
        public int Id { get; set; }
        [DisplayName("Auditorium")]
        public string Name { get; set; }
        public int NoOfSeats { get; set; }
        [DisplayName("Tickets left")]
        public int NoOfFreeSeats { get; set; }
    }
}
