using Api_imdb.Models;
using System.Collections.Generic;

namespace Api_imdb.Repository
{
    public interface IVoteRepository
    {
        IDictionary<Movie,int> GetTopRatedMoviesOrderByMovieTitleCountVotes();

        IList<Vote> FindAllFull();
    }
}
