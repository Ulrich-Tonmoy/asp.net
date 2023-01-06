import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseAssignComponent } from './course-assign/course-assign.component';
import { CourseComponent } from './course/course.component';
import { DepartmentComponent } from './department/department.component';
import { StudentComponent } from './student/student.component';
import { TeacherComponent } from './teacher/teacher.component';

const routes: Routes = [
    // { path: '', component: TeacherComponent },
    { path: '', redirectTo: 'course-assign', pathMatch: 'full' },
    { path: 'department', component: DepartmentComponent },
    { path: 'student', component: StudentComponent },
    { path: 'teacher', component: TeacherComponent },
    { path: 'course', component: CourseComponent },
    { path: 'course-assign', component: CourseAssignComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
