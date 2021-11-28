using Movies.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Data
{
    public class MoviesContextSeed
    {
        public static void SeedAsync(MoviesAPIContext moviesContext)
        {
            if (!moviesContext.Movie.Any())
            {
                var movies = new List<Movie> {

                    new Movie{
                        Id=1,
                        Genre = "Драма",
                        Title="Побег из Шоушенка",
                        Owner="alice",
                        Rating="3.3",
                        ReleaseDate = new DateTime(1985,5,5),
                        ImageUrl="images/src"
                    },
                    new Movie{
                        Id=2,
                        Genre = "Комедия",
                        Title="Форест Гамп",
                        Owner="bob",
                        Rating="5",
                        ReleaseDate = new DateTime(1985,5,5),
                        ImageUrl="images/src"
                    }
                };

                moviesContext.Movie.AddRange(movies);
                moviesContext.SaveChanges();
            }
        }
    }
}