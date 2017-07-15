import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { BettingService } from './betting/betting.service';
import { Bet, Customer, CustomerBet } from './betting/models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  private customerBets$: Observable<CustomerBet[]>;

  constructor(private bettingService: BettingService) {
  }

  ngOnInit(): void {
    this.customerBets$ = this.bettingService.getCustomerBets();
  }
}
