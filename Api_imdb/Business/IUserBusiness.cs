using Api_imdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_imdb.Business
{
    public interface IUserBusiness
    {
        User Create(User item);
        User Update(User item);
        void Delete(int id);
        User FindByID(int id);
        List<User> FindAll();
        bool Exists(int id);
        IList<User> GetUsersActives();
    }
}
