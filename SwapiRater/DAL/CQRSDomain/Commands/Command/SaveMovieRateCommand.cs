using SwapiRater.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.DAL.CQRSDomain.Commands.Command
{
    public class SaveMovieRateCommand : ICommand<bool>
    {
        public Movie Movie { get; private set; }

        public SaveMovieRateCommand(Movie movie)
        {
            Movie = movie;
        }
    }
}
