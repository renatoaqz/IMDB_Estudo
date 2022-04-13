using Api_imdb.DTO;
using Api_imdb.Models;
using Api_imdb.Repository;
using Api_imdb.Repository.Generic;
using System;
using System.Collections.Generic;

namespace Api_imdb.Business.Implementations
{
    public class MovieBusiness : IMovieBusiness
    {
        private readonly IRepository<Movie> _repository;
        private readonly IRepository<Author> _repositoryAuthor;
        private readonly IRepository<Gender> _repositoryGender;
        private readonly IMovieRepository _movieRepository;

        public MovieBusiness(IRepository<Movie> repository, IRepository<Author> repositoryAuthor, IRepository<Gender> repositoryGender, IMovieRepository movieRepository)
        {
            _repository = repository;
            _repositoryAuthor = repositoryAuthor;
            _repositoryGender = repositoryGender;
            _movieRepository = movieRepository;
        }
        public Movie Create(Movie item)
        {
            if (item.Author != null && item.Author.Id > 0)
            {
                item.Author = _repositoryAuthor.FindByID(item.Author.Id);
            }
            else
            {
                if (item.Author == null)
                {
                    throw new Exception("O autor deve ser informado!");
                }
                if(item.Author != null && item.Author.Id == 0 && string.IsNullOrEmpty(item.Author.Name))
                {
                    throw new Exception("O nome do autor deve ser informado!");
                }
            }

            if (item.Gender != null && item.Gender.Id > 0)
            {
                item.Gender = _repositoryGender.FindByID(item.Gender.Id);
            }
            else
            {
                if (item.Gender == null)
                {
                    throw new Exception("O gênero deve ser informado!");
                }
                if (item.Gender != null && item.Gender.Id == 0 && string.IsNullOrEmpty(item.Gender.Name))
                {
                    throw new Exception("O nome do gênero deve ser informado!");
                }

            }

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

        public IList<Movie> FindAll()
        {
            return _repository.FindAll();
            
            
        }

        public IList<Movie> FindAllFull()
        {
            return _movieRepository.FindAllFull();
        }


        public IList<Movie> FindByAuthorOrTitleOrGender(string title, string author, string gender)
        {
            return _movieRepository.FindByAuthorOrTitleOrGender(title,author,gender);
        }

        public IList<MovieDTO> GetMoviesOrderByMovieTitleAvgVotes()
        {
            IDictionary<Movie,double> listMovies = _movieRepository.GetMoviesOrderByMovieTitleAvgVotes();

            if(listMovies.Count > 0)
            {
                IList<MovieDTO> list = new List<MovieDTO>();
                foreach(KeyValuePair<Movie,double> item in listMovies)
                {
                    list.Add(new MovieDTO() { Id = item.Key.Id, Title = item.Key.Title, 
                        Author = item.Key.Author.Name, Gender = item.Key.Gender.Name, AvgVotes = item.Value});
                }

                return list;
            }

            return null;
        }

        public Movie FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Movie Update(Movie item)
        {
            return _repository.Update(item);
        }

    }
}
