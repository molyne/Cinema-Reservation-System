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

            if (context.Screenings.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Models.Movie[]
            {
              new Models.Movie{Title="Harry Potter", Genre="Fantasy"},
              new Models.Movie{Title="12 Strong", Genre="Comedy"},
              new Models.Movie{Title="Fifty Shades Freed", Genre="Romance"},
              new Models.Movie{Title="Lady Bird", Genre="Thriller"},
              new Models.Movie{Title="Batman", Genre="Action"},
              new Models.Movie{Title="Wonder", Genre="Drama"},
              new Models.Movie{Title="Thomb Raider", Genre="Horror"}

            };
            foreach (var m in movies)
            {
                context.Movies.Add(m);
            }
            var Auditorium1 = new Models.Auditorium
            {
                Name = "Saloon 1",
               NoOfSeats = 50,         
            };
            var Auditorium2 = new Models.Auditorium
            {
                Name = "Saloon 2",
                NoOfSeats = 100,     
            };

            context.Auditoriums.Add(Auditorium1);
            context.Auditoriums.Add(Auditorium2);

            var screenings = new Models.Screening[]
            {
                new Models.Screening{ScreeningTime=DateTime.Parse("2018-03-03 12:15:00"), Movie=movies[0], Auditorium=Auditorium1,TicketsLeft=Auditorium1.NoOfSeats },

                new Models.Screening{ScreeningTime=DateTime.Parse("2018-03-03 12:30:00"), Movie=movies[1], Auditorium=Auditorium2,TicketsLeft=Auditorium2.NoOfSeats },

                new Models.Screening{ScreeningTime=DateTime.Parse("2018-03-03 15:45:00"), Movie=movies[2], Auditorium=Auditorium1,TicketsLeft=Auditorium1.NoOfSeats },

                new Models.Screening{ScreeningTime=DateTime.Parse("2018-03-03 15:00:00"), Movie=movies[3], Auditorium=Auditorium2,TicketsLeft=Auditorium2.NoOfSeats },

                new Models.Screening{ScreeningTime=DateTime.Parse("2018-03-03 17:30:00"), Movie=movies[4], Auditorium=Auditorium1, TicketsLeft=Auditorium1.NoOfSeats },

                new Models.Screening{ScreeningTime=DateTime.Parse("2018-03-03 18:00:00"), Movie=movies[5], Auditorium=Auditorium2, TicketsLeft=Auditorium2.NoOfSeats },

                new Models.Screening{ScreeningTime=DateTime.Parse("2018-03-03 21:00:00"), Movie=movies[6], Auditorium=Auditorium1, TicketsLeft=Auditorium1.NoOfSeats }
            };
          
            

            foreach (var s in screenings)
            {
                context.Screenings.Add(s);
            }
            context.SaveChanges();
        }
    }
}
