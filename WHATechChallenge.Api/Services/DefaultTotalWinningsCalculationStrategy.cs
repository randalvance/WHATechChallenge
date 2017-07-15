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
			throw new NotImplementedException();
		}
	}
}
