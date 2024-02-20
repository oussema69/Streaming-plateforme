import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeGuestRoutingModule } from './home-guest-routing.module';
import { WelcomeComponent } from './components/welcome/welcome.component';


@NgModule({
  declarations: [
    WelcomeComponent
  ],
  imports: [
    CommonModule,
    HomeGuestRoutingModule
  ]
})
export class HomeGuestModule { }
