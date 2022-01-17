using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Handle(){
            var Movie = _dbContext.Movies.SingleOrDefault(a => a.Id == MovieId);
            if(Movie is null)
                throw new InvalidOperationException("Silmeye çalıştığınız film bulunamadı!");
            var movieActor = _dbContext.MovieActors.Any(x=>x.MovieId == MovieId);
            if(!movieActor)
                throw new InvalidOperationException("Önce filme ait aktörler silinmelidir!");
            _dbContext.Movies.Remove(Movie);            
            int result = _dbContext.SaveChanges();
            return Convert.ToBoolean(result);
        }
    }
}