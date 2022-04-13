using Api_imdb.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_imdb.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        void Delete(int id);
        T FindByID(int id);
        List<T> FindAll();
        bool Exists(int id);
    }
}
