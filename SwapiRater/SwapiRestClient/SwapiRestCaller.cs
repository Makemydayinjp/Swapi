using RestSharp;
using System.Threading.Tasks;
using RS = RestSharp;

namespace SwapiRater.SwapiRestClient
{
    public class SwapiRestCaller : ISwapiRestCaller
    {
        public async Task<string> Get()
        {
            var client = new RS.RestClient(@"http://swapi.dev/api/films/");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            return response.Content;
        }
    }
  
}
