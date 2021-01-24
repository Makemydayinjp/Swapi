
using SwapiRater.DAL.CQRSDomain.Queries.Handler;
using SwapiRater.DAL.CQRSDomain.Queries.Query;
using SwapiRater.DAL.Models;

namespace SwapiRater.DAL.CQRSDomain.Queries
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly SwapiContext _context;
        public QueryHandlerFactory(SwapiContext context)
        {
            _context = context;
        }
        public IQueryHandler<SingleMovieQuery, Movie> Build(SingleMovieQuery query)
        {
            return new SingleMovieQueryHandler(query, _context);
        }


    }
}
