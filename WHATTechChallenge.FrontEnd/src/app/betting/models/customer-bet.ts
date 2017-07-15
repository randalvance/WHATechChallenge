import { Bet, Customer } from './';

export interface CustomerBet {
    customer: Customer,
    bets: Bet[],
    totalWinnings: number,
    totalBet: number
}