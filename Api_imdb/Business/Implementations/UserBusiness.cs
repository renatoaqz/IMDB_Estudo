using Api_imdb.Models;
using Api_imdb.Repository;
using Api_imdb.Repository.Generic;
using System.Collections.Generic;

namespace Api_imdb.Business.Implementations
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IRepository<User> _repository;
        private readonly IUserRepository _userRepository;

        public UserBusiness(IRepository<User> repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public User Create(User item)
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

        public List<User> FindAll()
        {
            return _repository.FindAll();
        }

        public User FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public IList<User> GetUsersActives()
        {
            return _userRepository.GetUsersActives();
        }

        public User Update(User item)
        {
            return _repository.Update(item);
        }


    }
}
