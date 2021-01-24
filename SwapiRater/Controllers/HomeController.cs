using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SwapiRater.DAL.CQRSDomain.Commands;
using SwapiRater.DAL.CQRSDomain.Commands.Command;
using SwapiRater.DAL.CQRSDomain.Queries;
using SwapiRater.DAL.CQRSDomain.Queries.Query;
using SwapiRater.DAL.Models;
using SwapiRater.JsonResponseParser;
using SwapiRater.SwapiRestClient;
using SwapiRater.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.Controllers
{
    public class HomeController : Controller
    {
            private readonly ISwapiRestCaller _caller;
            private readonly ILogger<HomeController> _logger;

            private readonly ICommandHandlerFactory _commFac;
            private readonly IQueryHandlerFactory _queryfac;

            protected static Dictionary<string, MovieViewModel> movies;

            public HomeController(ILogger<HomeController> logger, ISwapiRestCaller caller,
                ICommandHandlerFactory commfac, IQueryHandlerFactory queryFac)
            {
                _logger = logger;
                _caller = caller;
                _commFac = commfac;
                _queryfac = queryFac;
            }

            public async Task<IActionResult> Index()
            {
                var result = await _caller.Get();

                var converted = SwapiJsonResponse.FromJson(result);
                movies = new Dictionary<string, MovieViewModel>();
                foreach (var item in converted.Result)
                {
                    try
                    {
                        var mvm = new MovieViewModel(item);
                        movies.Add(item.Key, mvm);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                UpdateViewBag();
                return View();
            }

            [HttpGet("getDetails")]
            public async Task<IActionResult> GetDetails(string key)
            {

                if (movies.TryGetValue(key, out MovieViewModel res))
                {
                    var movieGrade = _queryfac.Build(new SingleMovieQuery(res.EpisodeId)).Get();
                    if (movieGrade != null)
                    {
                        res.Grade = movieGrade.Grade;
                    }

                    UpdateViewBag();
                    return View(res);
                }

                return null;
            }

            [HttpPost("RateMovie")]
            public async Task<IActionResult> RateMovie(string rate, string key)
            {
                if (movies.TryGetValue(key, out MovieViewModel res))
                {
                    movies[key].Grade = rate;
                    res.Grade = rate;
                    var movie = _queryfac.Build(new SingleMovieQuery(res.EpisodeId)).Get();

                    if (movie != null)
                        movie.Grade = rate;
                    else
                        movie = new Movie() { EpisodeId = res.EpisodeId, Grade = rate };

                    _commFac.Build(new SaveMovieRateCommand(movie)).Execute();


                    return View("GetDetails", res);
                }


                return null;
            }

            private void UpdateViewBag()
            {
                var movieList = movies.Select(a => a.Key);
                ViewBag.MovieList = new SelectList(movieList, "Key");
            }
        }
}
