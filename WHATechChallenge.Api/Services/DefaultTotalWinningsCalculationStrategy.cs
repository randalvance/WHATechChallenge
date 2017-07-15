using System;
using System.Linq;
using WHATechChallenge.Api.Models;

namespace WHATechChallenge.Api.Services
{
	/// <summary>
	/// This default calculation strategy adds to total winnings if race is won, and remove to total winnigns if race is lost
	/// </summary>
	public class DefaultTotalWinningsCalculationStrategy : ITotalWinningsCalculationStrategy
	{
		public decimal CalculateTotalWinnings(CustomerBet customerBet)
		{
			if (customerBet == null)
			{
				throw new ArgumentNullException(nameof(customerBet));
			}

			if (customerBet.Bets == null || !customerBet.Bets.Any())
			{
				return 0;
			}

			var results = customerBet.Bets.Select(bet => bet.Won ? bet.ReturnStake : (bet.ReturnStake * -1));

			return results.Sum(r => r);
		}
	}
}
