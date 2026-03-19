import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SkillService } from '../../../core/services/skill.service';

@Component({
  selector: 'app-skill-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './skill-list.component.html',
  styleUrls: ['./skill-list.component.css'] // ✅ CSS linked here
})
export class SkillListComponent {

  // 🔹 Skill list
  skills: any[] = [];

  // 🔹 Add skill input
  newSkill: string = '';

  // 🔹 Edit variables
  editIndex: number = -1;
  editSkillName: string = '';

  constructor(private skillService: SkillService) {}

  // 🔹 Load skills
  ngOnInit() {
    this.skillService.getSkills().subscribe(res => {
      this.skills = res;
    });
  }

  // 🔹 Add new skill
  addSkill() {
    if (this.newSkill.trim()) {
      this.skills.push({
        id: this.skills.length + 1,
        name: this.newSkill
      });

      this.newSkill = '';
    }
  }

  // 🔹 Delete skill
  deleteSkill(index: number) {
    this.skills.splice(index, 1);
  }

  // 🔹 Start editing
  startEdit(index: number) {
    this.editIndex = index;
    this.editSkillName = this.skills[index].name;
  }

  // 🔹 Save edited skill
  saveEdit(index: number) {
    this.skills[index].name = this.editSkillName;
    this.editIndex = -1;
  }
}