using SwapiRater.JsonResponseParser;

namespace SwapiRater.ViewModel
{
    public class MovieViewModel : SwapiResult
    {
        public string Grade { get; set; }
        public MovieViewModel(SwapiResult result)
        {
            this.EpisodeId = result.EpisodeId;
            this.OpeningCrawl = result.OpeningCrawl;
            this.Producer = result.Producer;
            this.Director = result.Director;
            this.ReleaseDate = result.ReleaseDate;
            this.Title = result.Title;
        }
    }
}
