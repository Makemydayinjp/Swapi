using SwapiRater.DAL.CQRSDomain.Queries.Query;
using SwapiRater.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.DAL.CQRSDomain.Queries.Handler
{
    public class SingleMovieQueryHandler : IQueryHandler<SingleMovieQuery, Movie>
    {
        private readonly SwapiContext _context;
        private readonly SingleMovieQuery _query;
        public SingleMovieQueryHandler(SingleMovieQuery query, SwapiContext context)
        {
            _query = query;
            _context = context;
        }
        public Movie Get()
        {
            return _context.Movies.FirstOrDefault(m => m.EpisodeId.Equals(_query.Id));
        }
    }
}
