using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationSystem.Models
{
    public class Screening
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Auditorium Auditorium { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DisplayName("Time")]
        public DateTime ScreeningTime { get; set; }
    }
}
