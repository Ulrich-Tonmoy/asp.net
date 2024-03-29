import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DepartmentComponent } from './department/department.component';
import { StudentComponent } from './student/student.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { HttpClientModule } from '@angular/common/http';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { DeptFormComponent } from './department/form/form.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ReactiveFormsModule } from '@angular/forms';
import { StudentFormComponent } from './student/form/form.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { CourseComponent } from './course/course.component';
import { CourseFormComponent } from './course/form/form.component';
import { TeacherComponent } from './teacher/teacher.component';
import { TeacherFormComponent } from './teacher/form/form.component';
import { CourseAssignComponent } from './course-assign/course-assign.component';
import { AllocateRoomComponent } from './allocate-room/allocate-room.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { EnrollComponent } from './enroll/enroll.component';
import { ResultsComponent } from './results/results.component';
import { AddResultsComponent } from './results/add-results/add-results.component';
import { UnassignComponent } from './unassign/unassign.component';

@NgModule({
    declarations: [
        AppComponent,
        DepartmentComponent,
        StudentComponent,
        DeptFormComponent,
        StudentFormComponent,
        CourseComponent,
        CourseFormComponent,
        TeacherComponent,
        TeacherFormComponent,
        CourseAssignComponent,
        AllocateRoomComponent,
        ScheduleComponent,
        EnrollComponent,
        ResultsComponent,
        AddResultsComponent,
        UnassignComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MatTableModule,
        MatPaginatorModule,
        HttpClientModule,
        MatToolbarModule,
        MatIconModule,
        MatDialogModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatTooltipModule,
        ReactiveFormsModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatSelectModule,
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
