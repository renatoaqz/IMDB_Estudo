using Api_imdb.DTO;
using Api_imdb.Models;

namespace Api_imdb.Services
{
    public interface IUserService
    {
        UserDTO Authenticate(string login, string password);
    }
}
