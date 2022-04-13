using Api_imdb.Models;
using System.Collections.Generic;

namespace Api_imdb.Business
{
    public interface IAuthorBusiness
    {
        Author Create(Author item);
        Author Update(Author item);
        void Delete(int id);
        Author FindByID(int id);
        List<Author> FindAll();
        bool Exists(int id);
    }
}
