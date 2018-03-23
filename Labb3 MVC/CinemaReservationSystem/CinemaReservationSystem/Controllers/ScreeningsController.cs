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
        public async Task<IActionResult> Index()
        {

            var screenings = _context.Screenings
                .Include(s => s.Auditorium)
                .Include(m => m.Movie)
                .AsNoTracking();

            return View(await screenings.ToListAsync());
        }
       
        [HttpGet]
        public async Task<IActionResult> Book(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var choosenScreening =  _context.Screenings
                .Include(s => s.Auditorium)
                .Include(m => m.Movie).
                SingleOrDefaultAsync(m => m.Id == id);
          
            if (choosenScreening == null)
            {
                return NotFound();
            }

            return View(await choosenScreening);
        }
       

    }
       
}

       