import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { Bet, Customer, CustomerBet } from './models';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class BettingService {

    private baseUrl: string = 'http://localhost:5000/api/';
    private customersEndpoint: string = `${this.baseUrl}customers`;
    private betsEndpoint: string = `${this.baseUrl}bets`;
    private customersbetEndpoint: string = `${this.baseUrl}customerbets`;

    constructor(private http: Http) {
    }

    public getCustomerBets(): Observable<CustomerBet[]> {
        return this.getByEndpoint<CustomerBet>(this.customersbetEndpoint)
    }

    public getCustomers(): Observable<Customer[]> {
        return this.getByEndpoint<Customer>(this.customersEndpoint);
    }

    public getBets(): Observable<Bet[]> {
        return this.getByEndpoint<Bet>(this.betsEndpoint);
    }

    private getByEndpoint<T>(endPoint: string): Observable<T[]> {
        let headers = new Headers(
            {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        );

        return this.http.get(endPoint, { headers: headers })
            .map((response: Response) => <T[]>response.json())
            .catch((err, caught) => {
                return Observable.throw(err || 'An error occurred');
            });
    }
}