﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public IList<ReservedSeat> ReservedSeats { get; set; }
    }
}
