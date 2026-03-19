import { CanActivateFn } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {

  const token = localStorage.getItem('token');

  if (token) {
    return true; // allow access
  } else {
    alert('Please login first');
    return false; // block access
  }
};