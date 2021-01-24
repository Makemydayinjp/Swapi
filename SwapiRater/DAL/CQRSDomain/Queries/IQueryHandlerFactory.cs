using SwapiRater.DAL.CQRSDomain.Queries.Query;
using SwapiRater.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.DAL.CQRSDomain.Queries
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<SingleMovieQuery, Movie> Build(SingleMovieQuery query);
    }
}
