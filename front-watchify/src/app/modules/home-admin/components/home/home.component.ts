import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { JwtDecoderService } from 'src/app/service/jwt-decoder.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private cookieService: CookieService,private jwtdecode:JwtDecoderService) { }

  ngOnInit(): void {
    // Your initialization logic here

    // Check if token and role are saved in cookies
    const token = this.cookieService.get('token');
    const role = this.cookieService.get('role');

    if (token && role) {
      console.log('Token and role are saved in cookies:', token, role);
      console.log(this.jwtdecode.decodeToken1(token))

    } else {
      console.log('Token and role are not saved in cookies');
    }
  }

}
