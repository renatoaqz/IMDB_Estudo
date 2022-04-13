using Api_imdb.Models;
using Api_imdb.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace Api_imdb.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private SqlServerContext _context;


        public UserRepository(SqlServerContext context)
        {
            _context = context;

        }

        public User GetuserByLoginPassword(string login, string password)
        {
            return _context.Users.Where(x => x.Login == login && x.Password == password & x.Ativo == true).FirstOrDefault();
        }

        public IList<User> GetUsersActives()
        {
            return _context.Users.Where(x => x.Ativo == true && x.Role == "user").OrderBy(x=>x.FullName).ToList();
        }
    }
}
