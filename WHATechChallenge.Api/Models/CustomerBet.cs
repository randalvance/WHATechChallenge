using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WHATechChallenge.Api.Models
{
    public class CustomerBet
    {
        public Customer Customer { get; set; }
        public List<Bet> Bets { get; set; } = new List<Bet>();
		public decimal TotalWinnings { get; set; }
    }
}
