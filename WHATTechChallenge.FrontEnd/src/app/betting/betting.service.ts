import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { Customer } from './models/customer';
import { Bet } from './models/bet';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class BettingService {

    private baseUrl: string = 'http://localhost:5000/api/';
    private customerEndpoint: string = `${this.baseUrl}customers`;
    private betEndpoint: string = `${this.baseUrl}bets`;

    constructor(private http: Http) {
    }

    public getCustomers(): Observable<Customer[]> {
        return this.getByEndpoint(this.customerEndpoint);
    }

    public getBets(): Observable<Bet[]> {
        return this.getByEndpoint(this.betEndpoint);
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