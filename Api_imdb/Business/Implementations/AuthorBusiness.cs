using Api_imdb.Models;
using Api_imdb.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_imdb.Business.Implementations
{
    public class AuthorBusiness : IAuthorBusiness
    {
        private readonly IRepository<Author> _repository;

        public AuthorBusiness(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public Author Create(Author item)
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

        public List<Author> FindAll()
        {
            return _repository.FindAll();
        }

        public Author FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Author Update(Author item)
        {
            return _repository.Update(item);
        }
    }
}
