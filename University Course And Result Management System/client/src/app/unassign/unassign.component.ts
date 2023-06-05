import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-unassign',
    templateUrl: './unassign.component.html',
    styleUrls: ['./unassign.component.scss'],
})
export class UnassignComponent {
    constructor(private http: HttpClient, private router: Router) {}

    unassignCourses() {
        if (confirm('Are you sure to unassign all courses?')) {
            this.http
                .patch('https://localhost:7026/api/assignedcourse/unassign', {})
                .subscribe({
                    next: (data: any) => {
                        this.router.navigate([`course`]);
                    },
                    error: (err: any) => {
                        console.log(err);
                    },
                });
        }
    }

    unallocateRooms() {
        if (confirm('Are you sure to unallocate all classrooms info?')) {
            this.http
                .patch('https://localhost:7026/api/room/unallocate', {})
                .subscribe({
                    next: (data: any) => {
                        this.router.navigate([`schedule`]);
                    },
                    error: (err: any) => {
                        console.log(err);
                    },
                });
        }
    }
}
