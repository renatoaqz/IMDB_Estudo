using Api_imdb.Models;
using Api_imdb.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Api_imdb.Repository.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private SqlServerContext _context;

        
        public MovieRepository(SqlServerContext context)
        {
            _context = context;
           
        }

        public IList<Movie> FindAllFull()
        {
            return _context.Movies.Include(x => x.Author).Include(y => y.Gender).ToList();
        }

        public IList<Movie> FindByAuthorOrTitleOrGender(string title, string author, string gender)
        {
            IList<Movie> list = _context.Movies
                .Where(x=>x.Title.Contains(!string.IsNullOrEmpty(title) ? title : ""))
                .Where(x => x.Author.Name.Contains(!string.IsNullOrEmpty(author) ? author : ""))
                .Where(x => x.Gender.Name.Contains(!string.IsNullOrEmpty(gender) ? gender : ""))
                .Include(x => x.Author)
                .Include(y => y.Gender)
                .ToList();

            return list;

        }

        public IDictionary<Movie, double> GetMoviesOrderByMovieTitleAvgVotes()
        {
            return _context.Movies
                .Include(u => u.Votes).Include(x=>x.Author).Include(x=>x.Gender).AsEnumerable()
                .GroupBy(v => v.Id)
      
                .Select(m => new { Movie = m.FirstOrDefault(), Avg = m.Average(u=>u.Votes.Select(x=>x.ValueVote).FirstOrDefault()) })
                .ToDictionary(m => m.Movie, m => m.Avg);
           
        }

    }
}
