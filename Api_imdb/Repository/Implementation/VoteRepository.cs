using Api_imdb.Models;
using Api_imdb.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Api_imdb.Repository.Implementation
{
    public class VoteRepository : IVoteRepository
    {
        private SqlServerContext _context;


        public VoteRepository(SqlServerContext context)
        {
            _context = context;

        }
        public IDictionary<Movie, int> GetTopRatedMoviesOrderByMovieTitleCountVotes()
        {
            return _context.Votes.Include(u=>u.Movie).AsEnumerable()
                .GroupBy(v => v.Movie.Id)
                .AsEnumerable()
                .Select(m => new { Movie = m.Where(x=>x.Movie.Id == m.Key).Select(x=>x.Movie).First() , Count = m.Count() })
                .OrderByDescending(m => m.Count).ThenBy(m => m.Movie.Title)
                .ToDictionary(m => m.Movie, m => m.Count);
        }

        public IList<Vote> FindAllFull()
        {
            return _context.Votes.Include(x => x.Movie).ToList();
        }
    }
}
