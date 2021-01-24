using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.SwapiRestClient
{
    public interface ISwapiRestCaller
    {
        Task<string> Get();
    }
}
