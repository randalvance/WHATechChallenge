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
			return await this.GetFromEndpoint<Customer>(endpointOptions.CustomersEndpoint);
		}

        public async Task<Bet[]> GetBetsAsync()
        {
			return await this.GetFromEndpoint<Bet>(endpointOptions.BetsEndpoint);
        }

		private async Task<T[]> GetFromEndpoint<T>(string endpoint)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var json = await client.GetStringAsync(endpoint);

			var objects = JsonConvert.DeserializeObject<T[]>(json);

			return objects;
		}
    }
}
