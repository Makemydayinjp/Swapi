using SwapiRater.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.DAL.CQRSDomain.Queries.Query
{
    public class SingleMovieQuery : IQuery<Movie>
    {
        public string Id { get; private set; }

        public SingleMovieQuery(string id)
        {
            Id = id;
        }
    }
}
