using Api_imdb.Models;
using System.Collections.Generic;

namespace Api_imdb.Repository
{
    public interface IMovieRepository
    {
        IList<Movie> FindAllFull();
        IList<Movie> FindByAuthorOrTitleOrGender(string title, string author, string gender);
        IDictionary<Movie, double> GetMoviesOrderByMovieTitleAvgVotes();
    }
}
