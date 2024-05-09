import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { log } from 'console';
import { Film } from 'src/app/Models/Film';
import { ServicePartenaireService } from 'src/app/Services/service-partenaire.service';

@Component({
  selector: 'app-detaill-film',
  templateUrl: './detaill-film.component.html',
  styleUrls: ['./detaill-film.component.css']
})
export class DetaillFilmComponent {
  id: number
  objectfilm: any
  comantaire:any
  conteur:number

  constructor(private router: ActivatedRoute, private service: ServicePartenaireService) { }
  ngOnInit(): void {

    this.router.params.subscribe(param => {
      this.id = param['id'];


    })
    this.Getfilmparid()
    this.getcom()

  }


  Getfilmparid() {
    this.service.GetFilmparId(this.id).subscribe((res) => {
      this.objectfilm = res
      console.log("l'objet film", this.objectfilm)

    })
  }

  getcom() {
    this.service.GetCommantairebaridfilm(this.id).subscribe((data)=>{
      this.comantaire= data;
      console.log(data);

    })
  }

}
