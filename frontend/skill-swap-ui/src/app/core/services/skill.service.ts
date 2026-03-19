import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SkillService {

  // 🔹 MOCK SKILL LIST
  getSkills() {
    return of([
      { id: 1, name: 'Angular' },
      { id: 2, name: 'Python' },
      { id: 3, name: 'Machine Learning' },
      { id: 4, name: 'Java' }
    ]);
  }

  // 🔹 ADD NEW SKILL (MOCK)
  addSkill(skill: any) {
    console.log("Skill added:", skill);

    return of({
      success: true,
      message: 'Skill added successfully'
    });
  }
}