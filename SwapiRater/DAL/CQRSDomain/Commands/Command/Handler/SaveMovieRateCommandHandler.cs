using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.DAL.CQRSDomain.Commands.Command.Handler
{
    public class SaveMovieRateCommandHandler : ICommandHandler<SaveMovieRateCommand, bool>
    {
        private readonly SwapiContext _context;
        private readonly SaveMovieRateCommand _command;

        public SaveMovieRateCommandHandler(SaveMovieRateCommand command, SwapiContext context)
        {
            _command = command;
            _context = context;
        }
        public bool Execute()
        {

            try
            {
                _context.Movies.Update(_command.Movie);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }

            return false;
        }
    }
}
