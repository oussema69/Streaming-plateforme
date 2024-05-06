import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeAdminRoutingModule } from './home-admin-routing.module';
import { HomeComponent } from './components/home/home.component';
import { MdbModalModule } from 'mdb-angular-ui-kit/modal';

import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose } from '@angular/material/dialog';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    HomeAdminRoutingModule,
    MdbModalModule

 
  ]
})
export class HomeAdminModule { }
