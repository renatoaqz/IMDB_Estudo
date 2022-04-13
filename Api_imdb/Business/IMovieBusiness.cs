using Api_imdb.DTO;
using Api_imdb.Models;
using System.Collections.Generic;

namespace Api_imdb.Business
{
    public interface IMovieBusiness
    {
        Movie Create(Movie item);
        Movie Update(Movie item);
        void Delete(int id);
        Movie FindByID(int id);
        IList<Movie> FindAll();
        bool Exists(int id);
        IList<Movie> FindAllFull();
        IList<Movie> FindByAuthorOrTitleOrGender(string title, string author, string gender);
        IList<MovieDTO> GetMoviesOrderByMovieTitleAvgVotes();
    }
}
