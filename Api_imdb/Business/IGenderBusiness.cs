using Api_imdb.Models;
using System.Collections.Generic;

namespace Api_imdb.Business
{
    public interface IGenderBusiness
    {
        Gender Create(Gender item);
        Gender Update(Gender item);
        void Delete(int id);
        Gender FindByID(int id);
        List<Gender> FindAll();
        bool Exists(int id);
    }
}
