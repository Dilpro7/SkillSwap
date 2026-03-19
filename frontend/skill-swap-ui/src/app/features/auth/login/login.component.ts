import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html'
})
export class LoginComponent {

  email = '';
  password = '';

  constructor(private authService: AuthService) {}

  login() {
    const data = {
      email: this.email,
      password: this.password
    };

    console.log("Sending login request:", data);

    this.authService.login(data).subscribe({
      next: (res) => {
        console.log("Response:", res);

        this.authService.saveToken(res.token);

        alert('Login Success ✅');
      },
      error: (err) => {
        console.log("Error:", err);
        alert('Login Failed ❌');
      }
    });
  }
}