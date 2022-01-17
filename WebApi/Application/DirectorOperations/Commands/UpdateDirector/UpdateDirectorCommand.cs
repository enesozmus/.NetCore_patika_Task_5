using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int DirectorId { get; set; }
        public UpdateDirectorViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Handle(){
            var Director = _dbContext.Directors.SingleOrDefault(a => a.Id == DirectorId);
            if(Director is null)
                throw new InvalidOperationException("Güncellemeye çalıştığınız yönetmen bulunamadı!");
            Director.firstName = Model.firstName == default ? Director.firstName : Model.firstName;
            Director.lastName = Model.lastName == default ? Director.lastName : Model.lastName;
            Director.IsActive = Model.IsActive == default ? Director.IsActive : Model.IsActive;

            int result = _dbContext.SaveChanges();
            return Convert.ToBoolean(result);
        }
    }

    public class UpdateDirectorViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool IsActive { get; set; }
    }
}