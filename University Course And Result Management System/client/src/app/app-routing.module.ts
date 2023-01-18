import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllocateRoomComponent } from './allocate-room/allocate-room.component';
import { CourseAssignComponent } from './course-assign/course-assign.component';
import { CourseComponent } from './course/course.component';
import { DepartmentComponent } from './department/department.component';
import { StudentComponent } from './student/student.component';
import { TeacherComponent } from './teacher/teacher.component';

const routes: Routes = [
    // { path: '', component: TeacherComponent },
    { path: '', redirectTo: 'allocate-room', pathMatch: 'full' },
    { path: 'department', component: DepartmentComponent },
    { path: 'student', component: StudentComponent },
    { path: 'teacher', component: TeacherComponent },
    { path: 'course', component: CourseComponent },
    { path: 'course-assign', component: CourseAssignComponent },
    { path: 'allocate-room', component: AllocateRoomComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
