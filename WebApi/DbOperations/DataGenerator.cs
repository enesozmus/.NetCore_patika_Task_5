using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        // ***** Initial Data ***** //
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {

                List<Actor> actors = new List<Actor>
                {
                    new Actor { firstName = "Actor_1", lastName = "Demo" },
                    new Actor { firstName = "Actor_2", lastName = "Demo" },
                    new Actor { firstName = "Actor_3", lastName = "Demo" },
                    new Actor { firstName = "Actor_4", lastName = "Demo" },
                    new Actor { firstName = "Actor_5", lastName = "Demo" }
                };

                List<Customer> customers = new List<Customer>
                {
                    new Customer { firstName = "Enes", lastName = "Ozmus", Email = "ensozmus@gmail.com", Password = "12345" },
                    new Customer { firstName = "Ali", lastName = "Demir,", Email = "demo@gmail.com", Password = "54321" },
                    new Customer { firstName = "Hasan", lastName = "Uğurlu", Email = "demo1@gmail.com", Password = "963258" }
                };

                List<CustomerFavoritGenre> customerFavoritGenres = new List<CustomerFavoritGenre>
                {
                    new CustomerFavoritGenre{ CustomerId = 1, GenreId = 1 },
                    new CustomerFavoritGenre{ CustomerId = 1, GenreId = 2 },
                    new CustomerFavoritGenre{ CustomerId = 1, GenreId = 3 },
                    new CustomerFavoritGenre{ CustomerId = 2, GenreId = 1 },
                    new CustomerFavoritGenre{ CustomerId = 2, GenreId = 3 },
                };

                List<Director> directors = new List<Director>
                {
                    new Director { firstName = "Director_1", lastName = "Demo" },
                    new Director { firstName = "Director_2", lastName = "Demo" },
                    new Director { firstName = "Director_3", lastName = "Demo" },
                    new Director { firstName = "Director_4", lastName = "Demo" },
                    new Director { firstName = "Director_5", lastName = "Demo" }
                };

                List<Genre> genres = new List<Genre>
                {
                    new Genre { Name = "Mystery" },
                    new Genre { Name = "Drama" },
                    new Genre { Name = "Romance" },
                    new Genre { Name = "Fantasy" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Action" },
                    new Genre { Name = "Comedy" },
                    new Genre { Name = "Horror" }
                };

                List<Movie> movies = new List<Movie>{

                    new Movie
                    {
                        Title = "Inception",
                        GenreId = 1,
                        ReleaseDate = 2010,
                        DirectorId = 2,
                        Price = 140.0m
                    },
                    new Movie
                    {
                        Title = "Star Wars: Episode V - The Empire Strikes Back",
                        GenreId = 1,
                        ReleaseDate = 1980,
                        DirectorId = 1,
                        Price = 35.0m
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Return of the King",
                        GenreId = 3,
                        ReleaseDate = 2003,
                        DirectorId = 3,
                        Price = 70.0m
                    }
                };

                List<MovieActor> movieActors = new List<MovieActor>
                {
                    new MovieActor { ActorId = 1, MovieId = 1 },
                    new MovieActor { ActorId = 4, MovieId = 1 },
                    new MovieActor { ActorId = 2, MovieId = 2 },
                    new MovieActor { ActorId = 3, MovieId = 3 }
                };

                List<OrderMovie> orderMovies = new List<OrderMovie>{
                    new OrderMovie{
                        MovieId=1,
                        CustomerId=1,
                        PurchasedDate = new DateTime(2021,01,01),
                        PurchasedPrice = 140
                    },
                    new OrderMovie{
                        MovieId=3,
                        CustomerId=1,
                        PurchasedDate = new DateTime(2021,02,02),
                        PurchasedPrice = 35
                    },
                    new OrderMovie{
                        MovieId=2,
                        CustomerId=2,
                        PurchasedDate = new DateTime(2021,03,03),
                        PurchasedPrice = 70
                    }
                };

                if (context.Actors.Any())
                {
                    return;
                }
                context.Actors.AddRange(actors);

                if (context.Customers.Any())
                {
                    return;
                }
                context.Customers.AddRange(customers);

                if (context.CustomerFavoritGenres.Any())
                {
                    return;
                }
                context.CustomerFavoritGenres.AddRange(customerFavoritGenres);

                if (context.Directors.Any())
                {
                    return;
                }
                context.Directors.AddRange(directors);

                if (context.Genres.Any())
                {
                    return;
                }
                context.Genres.AddRange(genres);


                if (context.Movies.Any())
                {
                    return;
                }
                context.Movies.AddRange(movies);


                if (context.MovieActors.Any())
                {
                    return;
                }
                context.MovieActors.AddRange(movieActors);
                
                if (context.OrderMovies.Any())
                {
                    return;
                }
                context.OrderMovies.AddRange(orderMovies);

                context.SaveChanges();
            }
        }
    }
}