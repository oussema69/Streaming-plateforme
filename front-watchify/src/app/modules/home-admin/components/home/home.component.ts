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


  constructor(private adminserv:AdminService){}
  ngOnInit(): void {
    // throw new Error('Method not implemented.');
  }

  




  
}
