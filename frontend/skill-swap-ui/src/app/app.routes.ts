import { Routes } from '@angular/router';

// 🔹 Import Components
import { LoginComponent } from './features/auth/login/login.component';
import { SkillListComponent } from './features/skills/skill-list/skill-list.component';

// 🔹 Import Guard
import { authGuard } from './core/guards/auth-guard';

// 🔹 Define Routes
export const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'skills',
    component: SkillListComponent,
    canActivate: [authGuard] // ✅ Protected route
  }
];