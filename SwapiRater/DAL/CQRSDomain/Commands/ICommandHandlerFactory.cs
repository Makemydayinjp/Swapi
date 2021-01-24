using SwapiRater.DAL.CQRSDomain.Commands.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.DAL.CQRSDomain.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<SaveMovieRateCommand, bool> Build(SaveMovieRateCommand comm);
    }
}
