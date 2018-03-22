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

            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Models.Movie[]
            {
                new Models.Movie{Title="Harry Potter", Genre="Fantasy"}
            };
            foreach (var m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();
        }
    }
}
