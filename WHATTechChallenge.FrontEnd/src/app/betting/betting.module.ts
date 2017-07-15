import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { BettingService } from './betting.service';

import { CustomerBetsComponent } from './components';

@NgModule({
    imports: [
        CommonModule,
        HttpModule
    ],
    declarations: [
        CustomerBetsComponent
    ],
    exports: [
        CustomerBetsComponent
    ],
    providers: [
        BettingService
    ]
})
export class BettingModule {

}