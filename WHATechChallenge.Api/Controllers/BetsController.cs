using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WHATechChallenge.Api.Models;
using WHATechChallenge.Api.Services;

namespace WHATechChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    public class BetsController : Controller
    {
        private IBettingEndpointConnector bettingEndpointConnector;

        public BetsController(IBettingEndpointConnector bettingEndpointConnector)
        {
            this.bettingEndpointConnector = bettingEndpointConnector;
        }

        [HttpGet]
        public async Task<Customer[]> Get()
        {
            return await this.bettingEndpointConnector.GetBetsAsync();
        }
    }
}
