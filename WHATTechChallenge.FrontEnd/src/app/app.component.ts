import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { BettingService } from './betting/betting.service';
import { Bet, Customer, CustomerBet } from './betting/models';

import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/takeUntil';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy, AfterViewInit {

  private ngUnsubscribe: Subject<void> = new Subject<void>();
  private customerBets$: Observable<CustomerBet[]>;
  private isLoading: Boolean = true;

  constructor(private bettingService: BettingService) {
  }

  ngOnInit(): void {
    this.customerBets$ = this.bettingService.getCustomerBets();
  }

  ngAfterViewInit(): void {
    this.customerBets$
      .takeUntil(this.ngUnsubscribe)
      .subscribe(customerBets => {
        this.isLoading = false;
      });
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }
}
