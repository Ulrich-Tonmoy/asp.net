import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TeacherFormComponent } from './form/form.component';

@Component({
    selector: 'app-teacher',
    templateUrl: './teacher.component.html',
    styleUrls: ['./teacher.component.scss'],
})
export class TeacherComponent {
    displayedColumns: string[] = [
        'name',
        'address',
        'email',
        'contactNo',
        'designation',
        'department',
        'actions',
    ];
    dataSource!: MatTableDataSource<any>;
    @ViewChild(MatPaginator) paginator!: MatPaginator;

    constructor(private http: HttpClient, public dialog: MatDialog) {}

    ngOnInit(): void {
        this.getTeacher();
    }

    openDialog() {
        this.dialog
            .open(TeacherFormComponent, { width: '40%' })
            .afterClosed()
            .subscribe((res) => {
                if (res == 'save') this.getTeacher();
            });
    }

    getTeacher() {
        this.http.get('https://localhost:7026/api/teacher').subscribe({
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

    editTeacher(element: any) {
        this.dialog
            .open(TeacherFormComponent, { width: '40%', data: element })
            .afterClosed()
            .subscribe((res) => {
                if (res == 'update') this.getTeacher();
            });
    }

    deleteTeacher(element: any) {
        if (confirm(`Do you want to delete Student "${element.regiNo}"`)) {
            this.http
                .delete('https://localhost:7026/api/teacher/' + element.id)
                .subscribe({
                    next: (data) => {
                        this.getTeacher();
                    },
                    error: (err) => {
                        console.log(err.error);
                    },
                });
        }
    }
}
