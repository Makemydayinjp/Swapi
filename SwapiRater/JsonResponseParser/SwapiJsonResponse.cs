using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiRater.JsonResponseParser
{
    public partial class SwapiJsonResponse
    {
        [JsonProperty("results")]
        public SwapiResult[] Result { get; protected set; }

    }

    public partial class SwapiJsonResponse
    {
        public static SwapiJsonResponse FromJson(string json) =>
            JsonConvert.DeserializeObject<SwapiJsonResponse>(json);
    }
    public class SwapiResult
    {
            [JsonProperty("title")]
        public string Title { get; protected set; }

        [JsonProperty("episode_id")]
        public string EpisodeId { get; protected set; }

        [JsonProperty("opening_crawl")]
        public string OpeningCrawl { get; protected set; }

        [JsonProperty("director")]
        public string Director { get; protected set; }

        [JsonProperty("producer")]
        public string Producer { get; protected set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; protected set; }

        [JsonProperty("url")]
        public string Url { get; protected set; }

        public string Key => $"{this.EpisodeId} {this.Title}";
    }
}
