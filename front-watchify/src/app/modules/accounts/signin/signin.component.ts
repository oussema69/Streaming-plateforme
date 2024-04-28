import { FacebookLoginProvider, SocialAuthService } from '@abacritt/angularx-social-login';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Auth } from 'src/app/model/auth';
import { AuthService } from 'src/app/service/auth.service';
import { UserService } from 'src/app/service/user.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent {
  title = 'angular-facebook';
  user:any;
  loggedIn:any;
  email:string;
  password:string;
token:any;
decodedToken:any;
form: FormGroup;

constructor(private authService1:AuthService,
  private authService: SocialAuthService,
  private userservice:UserService,
  private toastr: ToastrService,
  private fb: FormBuilder,
private route:Router,
private cookieService: CookieService){

}

ngOnInit(): void {
  this.form = this.fb.group({
    username: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+}{"':;?/><,.\\[\]\\=-])[A-Za-z\d!@#$%^&*()_+}{"':;?/><,.\\[\]\\=-]{8,}$/)]],
    // Add more form controls as needed
  });
  this.authService.authState.subscribe((user) => {
    this.user = user;
    console.log(this.user);
    this.userservice.getUserByusername(this.user.email).subscribe(res=>{
      this.toastr.success("succesfuly logged In", 'Error');

      this.route.navigate(['/customer'])
    },
  error=>{
    this.toastr.error('user not registred', 'Error');

    console.log("user maandy",error)

  })
    this.loggedIn = (user != null);
  });
}


login(){
  if (this.form.valid){
    this.authService1.login(this.form.value).subscribe(res=>{
      this.token=res

      this.cookieService.set('token', this.token.token);
      this.cookieService.set('role', this.token.role);
      this.toastr.success("succesfuly logged In", 'Error');

      if(this.token.role==0){
       this.route.navigate(['/admin'])
      }else if(this.token.role==1){
        this.route.navigate(['/customer'])

      }else{
        this.route.navigate(['/partner'])

      }
    },
    error=>{
      console.log('error',error);
      this.toastr.error(error.error, 'Error');

    }
  )
  }else{
    this.toastr.error("you must validate the form", 'Error');

  }

}

signInWithFB(): void {
  this.authService.signIn(FacebookLoginProvider.PROVIDER_ID);
}

}
