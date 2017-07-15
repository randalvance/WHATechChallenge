using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WHATechChallenge.Api.Controllers;
using WHATechChallenge.Api.Models;
using WHATechChallenge.Api.Services;
using Xunit;

namespace WHATechChallenge.Api.Tests
{
	public class WhenUsingCustomerBetsController
    {
		[Fact]
		public async Task ShouldReturnCustomerBets()
		{
			// Arrange
			var mockCustomerBetsCalculator = new Mock<ICustomerBetsCalculator>();
			var sampleData = new List<CustomerBet>
			{
				new CustomerBet
				{
					Customer = new Customer
					{
						Id = 1,
						Name = "John"
					},
					Bets = new List<Bet>
					{
						new Bet { CustomerId = 1, ReturnStake = 100, Won = false },
						new Bet { CustomerId = 1, ReturnStake = 300, Won = true },
						new Bet { CustomerId = 1, ReturnStake = 200, Won = false }
					}
				},
				new CustomerBet
				{
					Customer = new Customer
					{
						Id = 2,
						Name = "Mike"
					},
					Bets = new List<Bet>
					{
						new Bet { CustomerId = 2, ReturnStake = 400, Won = true },
						new Bet { CustomerId = 2, ReturnStake = 500, Won = true },
						new Bet { CustomerId = 2, ReturnStake = 600, Won = false }
					}
				}
			};
			mockCustomerBetsCalculator.Setup(x => x.CalculateCustomerBetsAsync()).Returns(Task.FromResult(sampleData));

			var controller = new CustomerBetsController(mockCustomerBetsCalculator.Object);

			// Act
			var result = await controller.Get();

			// Assert
			var expectedSerialized = JsonConvert.SerializeObject(sampleData);
			var resultSerialized = JsonConvert.SerializeObject(result);

			Assert.Equal(expectedSerialized, resultSerialized);
		}
    }
}
