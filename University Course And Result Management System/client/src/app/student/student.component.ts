import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
    selector: 'app-student',
    templateUrl: './student.component.html',
    styleUrls: ['./student.component.scss'],
})
export class StudentComponent implements AfterViewInit {
    constructor(private http: HttpClient) {}

    ngOnInit(): void {
        this.getStudent();
    }

    displayedColumns: string[] = ['code', 'name'];
    dataSource = new MatTableDataSource<any>([]);

    @ViewChild(MatPaginator) paginator: any = MatPaginator;

    ngAfterViewInit() {
        this.dataSource.paginator = this.paginator;
    }

    getStudent() {
        this.http
            .get('https://localhost:7026/api/student')
            .subscribe((data) => {
                console.log(data);

                const newData: any = data;
                this.dataSource = newData.data;
                this.dataSource.paginator = this.paginator;
            });
    }
}
