import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MdbModalRef } from 'mdb-angular-ui-kit/modal';
import { AdminService } from 'src/app/Services/admin.service';


@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent {
  userId: number;
  userData: any; 

  constructor(private router: Router, private route: ActivatedRoute, private adminServ: AdminService) {
    this.userId = parseInt(this.route.snapshot.paramMap.get('id') || '0');
    this.getUserData(this.userId);
  }

  getUserData(id:number) {
    this.adminServ.getUserById(this.userId).subscribe(
      (data: any) => {
        this.userData = data;
      },
      (error: any) => {
        console.error("Erreur lors de la récupération des données de l'utilisateur :", error);
      }
    );
  }
}
