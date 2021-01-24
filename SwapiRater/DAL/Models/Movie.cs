using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.DAL.Models
{
    public class Movie
    {
        public int Id { get; private set; }
        public string EpisodeId { get; set; }
        public string Grade { get; set; }
    }
}
