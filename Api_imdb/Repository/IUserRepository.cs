using Api_imdb.Models;
using System.Collections.Generic;

namespace Api_imdb.Repository
{
    public interface IUserRepository
    {
        User GetuserByLoginPassword(string login, string password);

        IList<User> GetUsersActives();
    }
}
