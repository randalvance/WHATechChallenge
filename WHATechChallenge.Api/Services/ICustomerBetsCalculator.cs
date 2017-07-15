using System.Collections.Generic;
using System.Threading.Tasks;
using WHATechChallenge.Api.Models;

namespace WHATechChallenge.Api.Services
{
    public interface ICustomerBetsCalculator
    {
        Task<List<CustomerBet>> CalculateCustomerBetsAsync();
    }
}
