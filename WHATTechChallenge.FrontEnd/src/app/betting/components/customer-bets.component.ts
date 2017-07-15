import { Component, Input, OnInit } from '@angular/core';
import { CustomerBet } from '../models';

@Component({
    selector: 'wha-customer-bets',
    templateUrl: 'customer-bets.component.html',
    styleUrls: [ 'customer-bets.component.scss' ]
})
export class CustomerBetsComponent implements OnInit {

    @Input()
    private customerBets: CustomerBet[];

    ngOnInit(): void {
    }
}