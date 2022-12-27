import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ViewChild, Inject } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormComponent } from './form/form.component';

@Component({
    selector: 'app-department',
    templateUrl: './department.component.html',
    styleUrls: ['./department.component.scss'],
})
export class DepartmentComponent {
    displayedColumns: string[] = ['code', 'name', 'actions'];
    dataSource!: MatTableDataSource<any>;
    @ViewChild(MatPaginator) paginator!: MatPaginator;

    constructor(private http: HttpClient, public dialog: MatDialog) {}

    ngOnInit(): void {
        this.getDepartment();
    }

    openDialog() {
        this.dialog
            .open(FormComponent, { width: '40%' })
            .afterClosed()
            .subscribe((res) => {
                if (res == 'save') this.getDepartment();
            });
    }

    editDepartment(element: any) {
        this.dialog
            .open(FormComponent, { width: '40%', data: element })
            .afterClosed()
            .subscribe((res) => {
                if (res == 'update') this.getDepartment();
            });
    }

    getDepartment() {
        this.http.get('https://localhost:7026/api/department').subscribe({
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

    deleteDepartment(element: any) {
        if (confirm(`Do you want to delete department "${element.code}"`)) {
            this.http
                .delete('https://localhost:7026/api/department/' + element.id)
                .subscribe({
                    next: (data) => {
                        console.log(data);
                        this.getDepartment();
                    },
                    error: (err) => {
                        console.log(err.error);
                    },
                });
        }
    }
}
