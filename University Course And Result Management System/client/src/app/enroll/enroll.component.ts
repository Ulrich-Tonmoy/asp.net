import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import {
    FormBuilder,
    FormGroup,
    FormControl,
    Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'app-enroll',
    templateUrl: './enroll.component.html',
    styleUrls: ['./enroll.component.scss'],
})
export class EnrollComponent {
    courseEnrollForm!: FormGroup;
    actionButton: string = 'Enroll';
    formName: string = 'Enroll in a Course';

    studentsData!: any;
    studentData!: any;
    courseData!: any;
    // date picker
    currentDate = new FormControl(new Date());

    constructor(
        private http: HttpClient,
        private formBuilder: FormBuilder,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.courseEnrollForm = this.formBuilder.group({
            studentId: ['', Validators.required],
            courseId: ['', Validators.required],
            date: ['', Validators.required],
        });

        this.getStudents();
    }

    getStudents() {
        this.http.get('https://localhost:7026/api/student').subscribe({
            next: (data) => {
                const newData: any = data;
                this.studentsData = newData.data;
            },
            error: (err) => {
                console.log(err.error);
            },
        });
    }
    onChangeStudent(e: any) {
        this.http.get('https://localhost:7026/api/student/' + e).subscribe({
            next: (data) => {
                const newData: any = data;
                this.studentData = data;
                this.getCourse(this.studentData?.departmentId);
            },
            error: (err) => {
                console.log(err.error);
            },
        });
    }
    getCourse(e: any) {
        this.http
            .get(
                `https://localhost:7026/api/course/dept/${e}?isAssignedCheck=false`
            )
            .subscribe({
                next: (data) => {
                    const newData: any = data;
                    this.courseData = newData.data;
                },
                error: (err) => {
                    console.log(err.error);
                },
            });
    }

    enrollCourse() {
        this.courseEnrollForm.value.date =
            this.currentDate.value?.toISOString();

        this.http
            .post(
                'https://localhost:7026/api/enrolledcourse',
                this.courseEnrollForm.value
            )
            .subscribe({
                next: (data) => {
                    this.router.navigate([`student`]);
                },
                error: (err) => {
                    console.log(err);
                },
            });
    }
}
