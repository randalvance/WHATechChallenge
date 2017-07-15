using System.Threading.Tasks;
using WHATechChallenge.Api.Models;

namespace WHATechChallenge.Api.Services
{
  public interface IBettingEndpointConnector
  {
    Task<Bet[]> GetBetsAsync();
    Task<Customer[]> GetCustomersAsync();
  }
}