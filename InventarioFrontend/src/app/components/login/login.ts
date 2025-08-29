import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Auth} from '../../services/auth';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})

export class LoginComponent {
  user: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: Auth, private router: Router) {}

  onSubmit() {
    this.authService.login(this.user, this.password).subscribe({
  next: (res) => {
    this.router.navigate(['/inventario']);
  },
  error: (err) => {
    this.errorMessage = 'Credenciales inválidas';
  }
});
  }
}