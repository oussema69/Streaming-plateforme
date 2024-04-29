import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-addfilm',
  templateUrl: './addfilm.component.html',
  styleUrls: ['./addfilm.component.css']
})
export class AddfilmComponent implements OnInit {

  constructor(private formBuilder: FormBuilder){}
  AjouterFilm!: FormGroup;
  selectedFile: any;
  formadata:FormData=new FormData();



  ngOnInit(): void {

    this.AjouterFilm=this.formBuilder.group({
      titre:["",Validators.required],
      description:["",Validators.required],
      duree:["",Validators.required],
      genre:["",Validators.required],
      dateDeSortie:["",Validators.required],
      isFree:["",Validators.required],
      userId:["",Validators.required],
      videoFilePath:["",Validators.required],
      logoFilePath:["",Validators.required]
    })

  }

  onFileSelect(event: Event, field: string): void {
    const element = event.currentTarget as HTMLInputElement;
    let fileList: FileList | null = element.files;
    if (fileList) {
      this.AjouterFilm.patchValue({ [field]: fileList[0] });
    }
  }


  ajoutrFilm()
  {
    this.formadata.append('titre',this.AjouterFilm.value.titre)
    this.formadata.append('description',this.AjouterFilm.value.description)
    this.formadata.append('duree',this.AjouterFilm.value.duree)
    this.formadata.append('genre',this.AjouterFilm.value.genre)
    this.formadata.append('dateDeSortie',this.AjouterFilm.value.dateDeSortie)
    this.formadata.append('isFree',this.AjouterFilm.value.isFree)
    this.formadata.append('videoFilePath',this.AjouterFilm.value.videoFilePath)
    this.formadata.append('logoFilePath',this.AjouterFilm.value.logoFilePath)
    this.formadata.append('userId',"1")


    console.log(this.AjouterFilm.value.isFree);



  }

}
