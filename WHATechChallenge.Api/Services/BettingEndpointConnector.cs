using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WHATechChallenge.Api.Models;
using WHATechChallenge.Api.Options;

namespace WHATechChallenge.Api.Services
{
	public class BettingEndpointConnector : IBettingEndpointConnector
  {
        private EndpointOptions endpointOptions;

        public BettingEndpointConnector(IOptions<EndpointOptions> endpointOptions)
        {
            this.endpointOptions = endpointOptions.Value;    
        }

        public async Task<Customer[]> GetCustomersAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = await client.GetStringAsync(endpointOptions.CustomersEndpoint);

            var customers = JsonConvert.DeserializeObject<Customer[]>(json);

            return customers;
        }

        public async Task<Bet[]> GetBetsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = await client.GetStringAsync(endpointOptions.BetsEndpoint);

            var bets = JsonConvert.DeserializeObject<Bet[]>(json);

            return bets;
        }
    }
}
