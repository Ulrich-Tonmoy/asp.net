import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { AddResultsComponent } from './add-results/add-results.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import * as pdfFonts from 'pdfmake/build/vfs_fonts';
import * as pdfMake from 'pdfmake/build/pdfmake';
(pdfMake as any).vfs = pdfFonts.pdfMake.vfs;
import htmlToPdfmake from 'html-to-pdfmake';

@Component({
    selector: 'app-results',
    templateUrl: './results.component.html',
    styleUrls: ['./results.component.scss'],
})
export class ResultsComponent {
    displayedColumns: string[] = ['code', 'name', 'grade'];
    dataSource!: MatTableDataSource<any>;
    @ViewChild(MatPaginator) paginator!: MatPaginator;
    @ViewChild('pdfTable') pdfTable!: ElementRef;

    studentsData!: any;
    studentData!: any;
    stdForm!: FormGroup;

    constructor(
        private http: HttpClient,
        private formBuilder: FormBuilder,
        public dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.stdForm = this.formBuilder.group({
            studentId: ['', Validators.required],
        });
        this.getStudents();
    }

    openDialog() {
        this.dialog
            .open(AddResultsComponent, { width: '40%' })
            .afterClosed()
            .subscribe((res) => {
                if (res == 'save') this.getStudents();
            });
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
            next: (data: any) => {
                this.studentData = data;
                console.log(data);

                this.dataSource = new MatTableDataSource(
                    data?.studentEnrolledCourse
                );
                this.dataSource.paginator = this.paginator;
            },
            error: (err) => {
                console.log(err.error);
            },
        });
    }

    exportPDF() {
        const pdfTable = this.pdfTable?.nativeElement;
        var html = htmlToPdfmake(pdfTable?.innerHTML);
        const documentDefinition = { content: html };
        pdfMake.createPdf(documentDefinition).download();
    }
}
