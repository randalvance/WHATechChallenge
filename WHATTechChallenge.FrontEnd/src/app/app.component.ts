import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { BettingService } from './betting/betting.service';
import { Bet, Customer } from './betting/models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  private customers$: Observable<Customer[]>;

  constructor(private bettingService: BettingService) {
  }

  ngOnInit(): void {
    this.customers$ = this.bettingService.getCustomers();
  }
}
