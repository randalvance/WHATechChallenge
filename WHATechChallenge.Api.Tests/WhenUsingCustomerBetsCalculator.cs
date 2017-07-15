using Moq;
using System.Linq;
using System.Threading.Tasks;
using WHATechChallenge.Api.Models;
using WHATechChallenge.Api.Services;
using Xunit;

namespace WHATechChallenge.Api.Tests
{
	public class WhenUsingCustomerBetsCalculator
    {
        [Fact]
        public async Task ShouldProperlyCorrelateCustomerWithTheirBets()
		{
			// Arrange
			var mockTotalWinningsCalculationStrategy = new Mock<ITotalWinningsCalculationStrategy>();
			mockTotalWinningsCalculationStrategy.Setup(x => x.CalculateTotalWinnings(It.IsAny<CustomerBet>())).Returns(0);

			var mockBettingEndpointConnector = new Mock<IBettingEndpointConnector>();
			mockBettingEndpointConnector.Setup(x => x.GetCustomersAsync()).Returns(Task.FromResult(
				new Customer[]
				{
					new Customer { CustomerId = 1, Name = "Joe" },
					new Customer { CustomerId = 2, Name = "Harry" },
					new Customer { CustomerId = 3, Name = "Carol" }
				}));
			mockBettingEndpointConnector.Setup(x => x.GetBetsAsync()).Returns(Task.FromResult(
				new Bet[]
				{
					new Bet { CustomerId = 2, RaceId = 1, ReturnStake = 100, Won = false },
					new Bet { CustomerId = 1, RaceId = 3, ReturnStake = 300, Won = true },
					new Bet { CustomerId = 3, RaceId = 2, ReturnStake = 200, Won = false },
					new Bet { CustomerId = 2, RaceId = 2, ReturnStake = 300, Won = true },
					new Bet { CustomerId = 2, RaceId = 3, ReturnStake = 400, Won = true },
					new Bet { CustomerId = 1, RaceId = 2, ReturnStake = 100, Won = false }
				}));
			
			var subject = new CustomerBetsCalculator(
				mockBettingEndpointConnector.Object, 
				mockTotalWinningsCalculationStrategy.Object);

			// Act
			var result = await subject.CalculateCustomerBetsAsync();

			// Assert

			Assert.Equal(3, result.Count);
			
			var firstCustomer = result.SingleOrDefault(x => x.Customer.CustomerId == 1);
			Assert.NotNull(firstCustomer);
			Assert.Equal(2, firstCustomer.Bets.Count);
			Assert.True(firstCustomer.Bets.All(b => b.CustomerId == 1));

			var secondCustomer = result.SingleOrDefault(x => x.Customer.CustomerId == 2);
			Assert.NotNull(secondCustomer);
			Assert.Equal(3, secondCustomer.Bets.Count);
			Assert.True(secondCustomer.Bets.All(b => b.CustomerId == 2));

			var thirdCustomer = result.SingleOrDefault(x => x.Customer.CustomerId == 3);
			Assert.NotNull(thirdCustomer);
			Assert.Equal(1, thirdCustomer.Bets.Count);
			Assert.True(thirdCustomer.Bets.All(b => b.CustomerId == 3));
		}
    }
}
