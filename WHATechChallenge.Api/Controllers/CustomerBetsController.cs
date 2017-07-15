using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WHATechChallenge.Api.Models;
using WHATechChallenge.Api.Services;

namespace WHATechChallenge.Api.Controllers
{
	[Route("api/[controller]")]
	public class CustomerBetsController : Controller
	{
		private ICustomerBetsCalculator customerBetsCalculator;

		public CustomerBetsController(ICustomerBetsCalculator customerBetsCalculator)
		{
			this.customerBetsCalculator = customerBetsCalculator;
		}

		[HttpGet]
		public async Task<List<CustomerBet>> Get()
		{
			return await this.customerBetsCalculator.CalculateCustomerBetsAsync();
		}
	}
}
