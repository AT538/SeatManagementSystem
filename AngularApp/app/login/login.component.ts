import { Component } from '@angular/core';
import { UserService } from '../../api/services/user.service';
import { AuthenticationService } from './authentication.service';
import { API_CONFIG } from '../api.config';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  

  constructor(private userService: UserService,private authService: AuthenticationService) {}

  onSubmit() {
    const user = { username: this.username, password: this.password };

    this.userService.postApiUser(user).subscribe(
      () => {
   
        console.log('Login successful');
        this.authService.isAuthenticated=true;
      },
      (error) => {
       
        console.error('Login failed', error);
      }
    );
  }
}