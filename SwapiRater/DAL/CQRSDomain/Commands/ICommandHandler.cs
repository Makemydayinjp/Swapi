using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.DAL.CQRSDomain.Commands
{
    public interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand<bool>
    {
        bool Execute();
    }
}
