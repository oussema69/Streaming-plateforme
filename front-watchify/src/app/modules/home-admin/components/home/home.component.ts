import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { User } from 'src/app/Models/User';
import { AdminService } from 'src/app/Services/admin.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    
  public canvas : any;
  public ctx :any;
  public chartColor: any;
  public chartEmail :any;
  public chartHours : any;

  allUsers:User[]=[];

  constructor(private adminserv:AdminService){}

  ngOnInit(){
    console.log("la liste est ",this.getAll());
  }
  getAll(){
    return this.adminserv.getAllUsers().subscribe((res:any)=>{
      this.allUsers=res;
      console.log("aaaaaa",this.allUsers)
    },(error:any)=>console.log("errrrrrrrr",error)
    )
  }


  updateUser(userId: number, updatedUserData: any){
    this.adminserv.updateUser(userId, updatedUserData).subscribe(
      (res:any) => {
        console.log("Utilisateur mis à jour :", res);
      },
      (error:any) => {
        console.error("Erreur lors de la mise à jour de l'utilisateur :", error);
      }
    );
  }

  deactivateUser(userId: number){
    this.adminserv.deactivateUser(userId).subscribe(
      (res:any) => {
        console.log("Utilisateur désactivé avec succès");
      },
      (error:any) => {
        console.error("Erreur lors de la désactivation de l'utilisateur :", error);
      }
    );
  }
}
