import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { StudentFormComponent } from './form/form.component';

@Component({
    selector: 'app-student',
    templateUrl: './student.component.html',
    styleUrls: ['./student.component.scss'],
})
export class StudentComponent {
    displayedColumns: string[] = [
        'regiNo',
        'name',
        'department',
        'email',
        'address',
        'contactNo',
        'date',
        'actions',
    ];
    dataSource!: MatTableDataSource<any>;
    @ViewChild(MatPaginator) paginator!: MatPaginator;

    constructor(private http: HttpClient, public dialog: MatDialog) {}

    ngOnInit(): void {
        this.getStudent();
    }

    openDialog() {
        this.dialog
            .open(StudentFormComponent, { width: '40%' })
            .afterClosed()
            .subscribe((res) => {
                if (res == 'save') this.getStudent();
            });
    }

    getStudent() {
        this.http.get('https://localhost:7026/api/student').subscribe({
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

    editStudent(element: any) {
        this.dialog
            .open(StudentFormComponent, { width: '40%', data: element })
            .afterClosed()
            .subscribe((res) => {
                if (res == 'update') this.getStudent();
            });
    }

    deleteStudent(element: any) {
        if (confirm(`Do you want to delete Student "${element.regiNo}"`)) {
            this.http
                .delete('https://localhost:7026/api/student/' + element.id)
                .subscribe({
                    next: (data) => {
                        this.getStudent();
                    },
                    error: (err) => {
                        console.log(err.error);
                    },
                });
        }
    }
}
