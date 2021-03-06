﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WHATechChallenge.Api.Models;
using WHATechChallenge.Api.Services;
using Microsoft.AspNetCore.Cors;

namespace WHATechChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private IBettingEndpointConnector bettingEndpointConnector;

        public CustomersController(IBettingEndpointConnector bettingEndpointConnector)
        {
            this.bettingEndpointConnector = bettingEndpointConnector;
        }
    
        [HttpGet]
		public async Task<Customer[]> Get()
        {
            return await this.bettingEndpointConnector.GetCustomersAsync();
        }
    }
}
