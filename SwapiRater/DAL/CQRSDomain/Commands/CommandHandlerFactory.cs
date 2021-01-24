using SwapiRater.DAL.CQRSDomain.Commands.Command;
using SwapiRater.DAL.CQRSDomain.Commands.Command.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.DAL.CQRSDomain.Commands
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly SwapiContext _context;

        public CommandHandlerFactory(SwapiContext context)
        {
            _context = context;
        }
        public ICommandHandler<SaveMovieRateCommand, bool> Build(SaveMovieRateCommand comm)
        {
            return new SaveMovieRateCommandHandler(comm, _context);

        }
    }
}
