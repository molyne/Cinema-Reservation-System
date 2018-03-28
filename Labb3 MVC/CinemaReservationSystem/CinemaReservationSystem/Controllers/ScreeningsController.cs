using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaReservationSystem;
using CinemaReservationSystem.Models;

namespace CinemaReservationSystem.Controllers
{
    public class ScreeningsController : Controller
    {
        private readonly CinemaContext _context;

        public ScreeningsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Screenings
        public async Task<IActionResult> Index(string sortOrder)
        {
            var screenings = _context.Screenings
                .Include(s => s.Auditorium)
                .Include(m => m.Movie).OrderBy(o => o.ScreeningTime)
                .AsNoTracking();
            if (!String.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "timeSort":
                        screenings = screenings.OrderByDescending(s => s.ScreeningTime);
                        break;
                    case "seatSort":
                        screenings = screenings.OrderByDescending(s => s.TicketsLeft);
                        break;
                    default:
                        screenings = screenings.OrderBy(s => s.ScreeningTime);
                        break;
                }
            }
            return View(await screenings.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Book(int? id)
        {
            ViewData["ErrorInfo"] = "";

            if (id == null)
            {
                return NotFound();
            }
            var choosenScreening = _context.Screenings
                .Include(s => s.Auditorium)
                .Include(m => m.Movie).
                SingleOrDefaultAsync(m => m.Id == id);

            if (choosenScreening == null)
            {
                return NotFound();
            }
            return View(await choosenScreening);
        }
        [HttpPost]
        public IActionResult Reservation(int? id, int tickets)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookedScreening = _context.Screenings
                .Include(s => s.Auditorium)
                .Include(m => m.Movie).
                SingleOrDefault(m => m.Id == id);

            if (tickets < 1 || tickets > 12)
            {
                ViewData["ErrorInfo"] = "Tickets must be between 1 to 12. Try again!";
                return View("Book", bookedScreening);
            }
            var updateSeats = bookedScreening;

            updateSeats.TicketsLeft -= tickets;

            if (bookedScreening.TicketsLeft >= 0)
            {
                _context.Update(updateSeats);
                var reservation = new Reservation
                {
                    Screening = bookedScreening,
                    Tickets = tickets
                };
                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                if (bookedScreening == null)
                {
                    return NotFound();
                }
                return View(reservation);
            }
            else
            {
                updateSeats.TicketsLeft += tickets;
                ViewData["ErrorInfo"] = "Only " + updateSeats.TicketsLeft + " tickets to the choosen movie left. Try again.";
                return View("Book", bookedScreening);
            }
        }

    }
}

