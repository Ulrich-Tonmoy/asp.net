import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { CourseFormComponent } from './form/form.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'app-course',
    templateUrl: './course.component.html',
    styleUrls: ['./course.component.scss'],
})
export class CourseComponent {
    displayedColumns: string[] = [
        'code',
        'name',
        'semester',
        'assigned',
        'actions',
    ];
    dataSource!: MatTableDataSource<any>;
    @ViewChild(MatPaginator) paginator!: MatPaginator;

    deptForm!: FormGroup;
    deptData!: any;

    constructor(
        private http: HttpClient,
        private formBuilder: FormBuilder,
        public dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.deptForm = this.formBuilder.group({
            departmentId: ['', Validators.required],
        });
        this.getCourse();
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

    openDialog() {
        this.dialog
            .open(CourseFormComponent, { width: '40%' })
            .afterClosed()
            .subscribe((res) => {
                if (res == 'save') this.getCourse();
            });
    }

    editCourse(element: any) {
        this.dialog
            .open(CourseFormComponent, { width: '40%', data: element })
            .afterClosed()
            .subscribe((res) => {
                if (res == 'update') this.getCourse();
            });
    }

    getCourse() {
        this.http.get('https://localhost:7026/api/course').subscribe({
            next: (data) => {
                const newData: any = data;

                this.dataSource = new MatTableDataSource(newData.data);
                this.dataSource.paginator = this.paginator;
            },
            error: (err) => {
                console.log(err.error);
            },
        });
    }
    getCourseByDept(id: any) {
        this.http
            .get('https://localhost:7026/api/course/dept/' + id)
            .subscribe({
                next: (data) => {
                    const newData: any = data;
                    console.log(newData.data);

                    this.dataSource = new MatTableDataSource(newData.data);
                    this.dataSource.paginator = this.paginator;
                },
                error: (err) => {
                    console.log(err.error);
                },
            });
    }

    deleteCourse(element: any) {
        if (confirm(`Do you want to delete department "${element.code}"`)) {
            this.http
                .delete('https://localhost:7026/api/course/' + element.id)
                .subscribe({
                    next: (data) => {
                        this.getCourse();
                    },
                    error: (err) => {
                        console.log(err.error);
                    },
                });
        }
    }
}
