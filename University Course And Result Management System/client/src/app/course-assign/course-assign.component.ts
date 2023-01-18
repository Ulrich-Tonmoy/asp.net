import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'app-course-assign',
    templateUrl: './course-assign.component.html',
    styleUrls: ['./course-assign.component.scss'],
})
export class CourseAssignComponent {
    courseAssignForm!: FormGroup;
    actionButton: string = 'Assign';
    formName: string = 'Assign Course to Teacher';

    canTakeCourse: boolean = true;
    creditToBeTaken: string = '';
    remainingCredit: number = 0;
    name: string = '';
    credit: number = 0;
    departmentId: string = '';

    deptData!: any;
    teacherData!: any;
    courseData!: any;

    constructor(
        private http: HttpClient,
        private formBuilder: FormBuilder,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.courseAssignForm = this.formBuilder.group({
            departmentId: ['', Validators.required],
            teacherId: ['', Validators.required],
            courseId: ['', Validators.required],
        });

        this.getDepartment();
    }

    getDepartment() {
        this.http.get('https://localhost:7026/api/department').subscribe({
            next: (data) => {
                const newData: any = data;
                this.deptData = newData.data;
            },
            error: (err) => {
                console.log(err.error);
            },
        });
    }
    getTeacher(e: any) {
        this.http
            .get('https://localhost:7026/api/teacher/dept/' + e)
            .subscribe({
                next: (data) => {
                    const newData: any = data;
                    this.teacherData = newData.data;
                    this.departmentId = e;
                },
                error: (err) => {
                    console.log(err.error);
                },
            });
    }
    onChangeTeacher(e: any) {
        const tData = this.teacherData.map((t: any) => {
            if (t.id === e) return t;
        });

        this.creditToBeTaken = tData[0].creditToBeTaken;
        this.remainingCredit = tData[0].creditToBeTaken - tData[0].creditTaken;

        this.getCourse(this.departmentId);
    }
    getCourse(e: any) {
        this.http
            .get(
                `https://localhost:7026/api/course/dept/${e}?isAssignedCheck=true`
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
    onChangeCourse(e: any) {
        const newData = this.courseData.map((data: any) => {
            if (data.id === e) return data;
        });
        this.name = newData[0].name;
        this.credit = newData[0].credit;
    }

    assignCourse() {
        if (this.remainingCredit - this.credit < 0) {
            confirm(
                'Cant assign this course to the teacher because its credit is more than the remaining credit of the teacher so change the course'
            );
        } else {
            if (this.courseAssignForm.valid) {
                this.http
                    .post(
                        'https://localhost:7026/api/assignedcourse',
                        this.courseAssignForm.value
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
    }
}
