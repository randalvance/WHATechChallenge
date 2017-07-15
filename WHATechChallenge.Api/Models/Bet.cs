using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WHATechChallenge.Api.Models
{
    public class Bet
    {
        public int CustomerId { get; set; }
        public int RaceId { get; set; }
        public decimal ReturnStake { get; set; }
        public bool Won { get; set; }
    }
}
