import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'app-schedule',
    templateUrl: './schedule.component.html',
    styleUrls: ['./schedule.component.scss'],
})
export class ScheduleComponent {
    displayedColumns: string[] = ['code', 'name', 'schedule'];
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

    getCourse() {
        this.http.get('https://localhost:7026/api/course').subscribe({
            next: (data) => {
                const newData: any = data;
                console.log(data);
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

    tConv24(time24: any) {
        let ts = time24;
        let H = +ts.substr(0, 2);
        let h = H % 12 || 12;
        h = Number(h < 10 ? '0' + h : h); // leading 0 at the left for 1 digit hours
        let ampm = H < 12 ? ' AM' : ' PM';
        ts = h + ts.substr(2, 3) + ampm;
        return ts;
    }
}
