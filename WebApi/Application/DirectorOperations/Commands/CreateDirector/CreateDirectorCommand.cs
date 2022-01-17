using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Handle(){
            var Director = _dbContext.Directors.SingleOrDefault(a => a.firstName == Model.firstName && a.lastName == Model.lastName);
            if(Director is not null)
                throw new InvalidOperationException("Eklemeye çalıştığınız yönetmen zaten mevcut!");
            Director = _mapper.Map<Director>(Model);
            _dbContext.Directors.Add(Director);
            int result = _dbContext.SaveChanges();
            return Convert.ToBoolean(result);
        }
    }

    public class CreateDirectorViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}