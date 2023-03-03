import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'app-allocate-room',
    templateUrl: './allocate-room.component.html',
    styleUrls: ['./allocate-room.component.scss'],
})
export class AllocateRoomComponent {
    courseAssignForm!: FormGroup;

    dayData: any[] = [
        {
            id: 'Mon',
            name: 'Monday',
        },
        {
            id: 'Tue',
            name: 'Tuesday',
        },
        {
            id: 'Wed',
            name: 'Wednesday',
        },
        {
            id: 'Thu',
            name: 'Thursday',
        },
        {
            id: 'Fri',
            name: 'Friday',
        },
        {
            id: 'Sat',
            name: 'Saturday',
        },
        {
            id: 'Sun',
            name: 'Sunday',
        },
    ];
    deptData!: any;
    courseData!: any;
    roomData!: any;
    show!: any;

    constructor(
        private http: HttpClient,
        private formBuilder: FormBuilder,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.courseAssignForm = this.formBuilder.group({
            departmentId: ['', Validators.required],
            courseId: ['', Validators.required],
            roomId: ['', Validators.required],
            day: ['', Validators.required],
            from: ['', Validators.required],
            to: ['', Validators.required],
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

    getCourse(e: any) {
        this.http
            .get(
                `https://localhost:7026/api/course/dept/${e}?isAssignedCheck=false`
            )
            .subscribe({
                next: (data) => {
                    const newData: any = data;
                    this.courseData = newData.data;
                    console.log(data);
                },
                error: (err) => {
                    console.log(err.error);
                },
            });
    }

    getRoom() {
        this.http.get(`https://localhost:7026/api/room`).subscribe({
            next: (data) => {
                const newData: any = data;
                this.roomData = newData.data;
            },
            error: (err) => {
                console.log(err.error);
            },
        });
    }

    allocateRoom() {
        if (this.courseAssignForm.valid) {
            this.http
                .post(
                    'https://localhost:7026/api/schedule',
                    this.courseAssignForm.value
                )
                .subscribe({
                    next: (data) => {
                        this.router.navigate([`/`]);
                    },
                    error: (err) => {
                        console.log(err);
                    },
                });
        }
    }
}
