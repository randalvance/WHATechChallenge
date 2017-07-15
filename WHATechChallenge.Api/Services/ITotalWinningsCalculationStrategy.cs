using WHATechChallenge.Api.Models;

namespace WHATechChallenge.Api.Services
{
    public interface ITotalWinningsCalculationStrategy
    {
        decimal CalculateTotalWinnings(CustomerBet customerBet);
    }
}
