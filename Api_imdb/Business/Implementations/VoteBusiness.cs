using Api_imdb.DTO;
using Api_imdb.Models;
using Api_imdb.Repository;
using Api_imdb.Repository.Generic;
using System;
using System.Collections.Generic;

namespace Api_imdb.Business.Implementations
{
    public class VoteBusiness : IVoteBusiness
    {
        private readonly IRepository<Vote> _repository;
        private readonly IVoteRepository _voteRepository;
        public VoteBusiness(IRepository<Vote> repository, IVoteRepository voteRepository)
        {
            _repository = repository;
            _voteRepository = voteRepository;
        }
        public Vote Create(Vote item)
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

        public List<Vote> FindAll()
        {
            return _repository.FindAll();
        }

        public Vote FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Vote Update(Vote item)
        {
            return _repository.Update(item);
        }

        public IList<VoteDTO> GetTopRatedMoviesOrderByMovieTitleCountVotes()
        {
            IDictionary<Movie, int> list = _voteRepository.GetTopRatedMoviesOrderByMovieTitleCountVotes();

            if(list.Count > 0)
            {
                IList<VoteDTO> voteDTOs = new List<VoteDTO>();
                foreach (KeyValuePair<Movie, int> item in list)
                {
                    voteDTOs.Add(new VoteDTO() { IdMovie = item.Key.Id, TitleMovie = item.Key.Title, CountVotesMovie = item.Value});
                }

                return voteDTOs;
            }

            return null;
        }

        public IList<VoteDTO> FindAllFull()
        {
            IList<Vote> list = _voteRepository.FindAllFull();

            if (list.Count > 0)
            {
                IList<VoteDTO> listDto = new List<VoteDTO>();

                foreach(Vote item in list)
                {
                    listDto.Add(new VoteDTO() { IdVoto = item.Id, IdMovie = item.Movie.Id, TitleMovie = item.Movie.Title, ValueVote = item.ValueVote, CountVotesMovie = null});
                }

                return listDto;
            }

            return null;
        }
    }
}
