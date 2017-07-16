import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { BettingService } from './betting.service';

import { CustomerBetsComponent, CustomerBetComponent } from './components';

@NgModule({
    imports: [
        CommonModule,
        HttpModule
    ],
    declarations: [
        CustomerBetsComponent,
        CustomerBetComponent
    ],
    exports: [
        CustomerBetsComponent,
        CustomerBetComponent
    ],
    providers: [
        BettingService
    ]
})
export class BettingModule {

}