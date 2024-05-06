import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddfilmComponent } from './addfilm/addfilm.component';
import { DetaillFilmComponent } from './detaill-film/detaill-film.component';

const routes: Routes = [
  {path:"home/:id",component:HomeComponent},
  {path:"addfilm",component:AddfilmComponent},
  {path:"detaillFilm/:id",component:DetaillFilmComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomePartnerRoutingModule { }
