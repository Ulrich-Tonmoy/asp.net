import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllocateRoomComponent } from './allocate-room/allocate-room.component';
import { CourseAssignComponent } from './course-assign/course-assign.component';
import { CourseComponent } from './course/course.component';
import { DepartmentComponent } from './department/department.component';
import { StudentComponent } from './student/student.component';
import { TeacherComponent } from './teacher/teacher.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { EnrollComponent } from './enroll/enroll.component';
import { ResultsComponent } from './results/results.component';

const routes: Routes = [
    // { path: '', component: TeacherComponent },
    { path: '', redirectTo: 'schedule', pathMatch: 'full' },
    { path: 'department', component: DepartmentComponent },
    { path: 'student', component: StudentComponent },
    { path: 'teacher', component: TeacherComponent },
    { path: 'course', component: CourseComponent },
    { path: 'course-assign', component: CourseAssignComponent },
    { path: 'allocate-room', component: AllocateRoomComponent },
    { path: 'schedule', component: ScheduleComponent },
    { path: 'enroll', component: EnrollComponent },
    { path: 'results', component: ResultsComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
