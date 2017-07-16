import { Component, Input, OnInit } from '@angular/core';
import { CustomerBet } from '../models';

@Component({
    selector: 'wha-customer-bet',
    templateUrl: './customer-bet.component.html',
    styleUrls: [ './customer-bet.component.scss' ]
})
export class CustomerBetComponent implements OnInit {
    @Input()
    private customerBet: CustomerBet;
    
    ngOnInit(): void {
        
    }
}