using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WHATechChallenge.Api.Models;

namespace WHATechChallenge.Api.Services
{
	public class CustomerBetsCalculator : ICustomerBetsCalculator
	{
		private IBettingEndpointConnector endpointConnector;
		private ITotalWinningsCalculationStrategy totalWinningsCalculationStrategy;

		public CustomerBetsCalculator(IBettingEndpointConnector endpointConnector, ITotalWinningsCalculationStrategy totalWinningsCalculationStrategy)
		{
			this.endpointConnector = endpointConnector;
			this.totalWinningsCalculationStrategy = totalWinningsCalculationStrategy;
		}

		public async Task<List<CustomerBet>> CalculateCustomerBetsAsync()
		{
			var customers = await endpointConnector.GetCustomersAsync();
			var bets = await endpointConnector.GetBetsAsync();

			var customerBets = (from customer in customers
								join bet in bets on customer.Id equals bet.CustomerId into cb
								select new CustomerBet
								{
									Customer = customer,
									Bets = cb.ToList()
								}).ToList();
			
			this.ApplyTotalWinnings(customerBets);

			return customerBets.ToList();
		}

		private void ApplyTotalWinnings(IEnumerable<CustomerBet> customerBets)
		{
			foreach(var customerBet in customerBets)
			{
				customerBet.TotalWinnings = this.totalWinningsCalculationStrategy.CalculateTotalWinnings(customerBet);
			}
		}
	}
}
