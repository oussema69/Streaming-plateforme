import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddfilmComponent } from './addfilm/addfilm.component';

const routes: Routes = [
  {path:"home",component:HomeComponent},
  {path:"addfilm",component:AddfilmComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomePartnerRoutingModule { }
