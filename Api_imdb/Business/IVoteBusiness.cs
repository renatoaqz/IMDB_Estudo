using Api_imdb.DTO;
using Api_imdb.Models;
using System.Collections.Generic;

namespace Api_imdb.Business
{
    public interface IVoteBusiness
    {
        Vote Create(Vote item);
        Vote Update(Vote item);
        void Delete(int id);
        Vote FindByID(int id);
        List<Vote> FindAll();
        bool Exists(int id);
        IList<VoteDTO> GetTopRatedMoviesOrderByMovieTitleCountVotes();
        IList<VoteDTO> FindAllFull();
    }
}
