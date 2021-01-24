using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SwapiRater.Controllers;
using SwapiRater.DAL;
using SwapiRater.DAL.CQRSDomain.Commands;
using SwapiRater.DAL.CQRSDomain.Queries;
using SwapiRater.SwapiRestClient;
using SwapiRater.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwapiRater.Tests
{
    public class HomeControllerTest : HomeController
    {
        public HomeControllerTest(ILogger<HomeController> logger, ISwapiRestCaller caller,
            ICommandHandlerFactory commfac, IQueryHandlerFactory queryFac) : base(logger, caller, commfac, queryFac) { }
        public Dictionary<string, MovieViewModel> GetMovies()
        {
            return movies;
        }
    }

    [TestFixture]
    public class QueryTests
    {

        private Mock<SwapiContext> context;
        private Mock<ISwapiRestCaller> _caller;
        private Mock<ICommandHandlerFactory> _commFact;
        private Mock<IQueryHandlerFactory> _queryFac;
        private Mock<ILogger<HomeController>> _logger;

        [SetUp]
        public void Setup()
        {
            context = new Mock<SwapiContext>();
            _caller = new Mock<ISwapiRestCaller>();
            _commFact = new Mock<ICommandHandlerFactory>();
            _queryFac = new Mock<IQueryHandlerFactory>();
            _logger = new Mock<ILogger<HomeController>>();
        }


        [Test]
        public void GetMovies()
        {

            _caller.Setup(c => c.Get()).Returns(Task.FromResult(SwapiJson()));

            var controller = new HomeControllerTest(_logger.Object, _caller.Object, _commFact.Object, _queryFac.Object);

            var view = controller.Index();


            var movies = controller.GetMovies();
            view.Status.Should().Be(TaskStatus.RanToCompletion);
            view.Id.Should().Be(1);
            view.Exception.Should().BeNull();

            movies.Count.Should().Be(1);

            movies["4 A New Hope"].Title.Should().Be("A New Hope");


        }

        private string SwapiJson()
        {
            return "{   \"count\": 1,   \"next\": null,   \"previous\": null,   \"results\": [     {       \"title\": \"A New Hope\",       \"episode_id\": 4,       \"opening_crawl\": \"It is... \",      \"director\": \"George Lucas\",       \"producer\": \"Gary Kurtz, Rick McCallum\",       \"release_date\": \"1977-05-25\",       \"created\": \"2014-12-10T14:23:31.880000Z\",       \"edited\": \"2014-12-20T19:49:45.256000Z\",       \"url\": \"http://swapi.dev/api/films/1/\"     }   ] }";
        }
    }
}
