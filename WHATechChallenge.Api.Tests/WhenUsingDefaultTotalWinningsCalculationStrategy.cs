using System;
using System.Collections.Generic;
using WHATechChallenge.Api.Models;
using WHATechChallenge.Api.Services;
using Xunit;

namespace WHATechChallenge.Api.Tests
{
	public class WhenUsingDefaultTotalWinningsCalculationStrategy
	{
		[Fact]
		public void ShouldCalculateTotalWinningsCorrectly()
		{
			// Arrange
			var customerBet = new CustomerBet
			{
				Bets = new List<Bet>
				{
					new Bet { ReturnStake = 100, Won = false },
					new Bet { ReturnStake = 300, Won = true },
					new Bet { ReturnStake = 200, Won = false },
					new Bet { ReturnStake = 300, Won = true },
					new Bet { ReturnStake = 400, Won = true },
					new Bet { ReturnStake = 100, Won = false }
				}
			};

			var target = new DefaultTotalWinningsCalculationStrategy();

			// Act
			var totalWinnings = target.CalculateTotalWinnings(customerBet);

			// Assert
			Assert.Equal(1000, totalWinnings);
		}

		[Fact]
		public void ShouldReturnZeroEarningsIfNoBet()
		{
			// Arrange
			var customerBet = new CustomerBet
			{
				Bets = new List<Bet>()
			};

			var target = new DefaultTotalWinningsCalculationStrategy();

			// Act
			var totalWinnings = target.CalculateTotalWinnings(customerBet);

			// Assert
			Assert.Equal(0, totalWinnings);
		}

		[Fact]
		public void ShouldThrowIfCustomerBetIsNull()
		{
			// Arrange
			CustomerBet customerBet = null;

			var target = new DefaultTotalWinningsCalculationStrategy();

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
			{
				var totalWinnings = target.CalculateTotalWinnings(customerBet);
			});
		}
	}
}
