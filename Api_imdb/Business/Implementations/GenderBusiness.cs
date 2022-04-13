using Api_imdb.Models;
using Api_imdb.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_imdb.Business.Implementations
{
    public class GenderBusiness : IGenderBusiness
    {
        private readonly IRepository<Gender> _repository;


        public GenderBusiness(IRepository<Gender> repository)
        {
            _repository = repository;
        }
        public Gender Create(Gender item)
        {
            return _repository.Create(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exists(int id)
        {
           return _repository.Exists(id);
        }

        public List<Gender> FindAll()
        {
            return _repository.FindAll();
        }

        public Gender FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Gender Update(Gender item)
        {
            return _repository.Update(item);
        }
    }
}
