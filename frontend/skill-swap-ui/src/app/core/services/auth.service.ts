import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs'; // ✅ ADD THIS

@Injectable({ providedIn: 'root' })
export class AuthService {

  private baseUrl = 'https://localhost:5001/api/auth';

  constructor(private http: HttpClient) {}

  login(data: any) {
    console.log("Mock login called");

    return of({
      token: 'dummy-token-123'
    });
  }

  saveToken(token: string) {
    localStorage.setItem('token', token);
  }
}