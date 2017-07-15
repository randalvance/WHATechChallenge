import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { BettingModule } from './betting';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BettingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

}
