using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservationSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaContext context)
        {
            context.Database.EnsureCreated();

            //if (context.Screenings.Any())
            //{
            //    return;   // DB has been seeded
            //}

            var movies = new Models.Movie[]
            {
              new Models.Movie{Title="Harry Potter", Genre="Fantasy"}
            };
            foreach (var m in movies)
            {
                context.Movies.Add(m);
            }
            var Auditorium1 = new Models.Auditorium
            {
                Name = "Saloon 1",
               NoOfSeats = 50,
               NoOfFreeSeats = 50
               
            };
            var Auditorium2 = new Models.Auditorium
            {
                Name = "Saloon 2",
                NoOfSeats = 100,
                NoOfFreeSeats= 100
            };
            
            var screenings = new Models.Screening[]
            {
                new Models.Screening{ScreeningTime=DateTime.Parse("2018-03-03 21:45:00"), Movie=movies[0], Auditorium=Auditorium1, }
            };
          
            context.Auditoriums.Add(Auditorium1);

            foreach (var s in screenings)
            {
                context.Screenings.Add(s);
            }
            context.SaveChanges();
        }
    }
}
