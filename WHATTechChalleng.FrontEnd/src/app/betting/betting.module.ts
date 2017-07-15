import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { BettingService } from './betting.service';

@NgModule({
    imports: [
        CommonModule,
        HttpModule
    ],
    providers: [
        BettingService
    ]
})
export class BettingModule {

}