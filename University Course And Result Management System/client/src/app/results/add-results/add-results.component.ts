import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import {
    FormBuilder,
    FormGroup,
    FormControl,
    Validators,
} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'app-add-results',
    templateUrl: './add-results.component.html',
    styleUrls: ['./add-results.component.scss'],
})
export class AddResultsComponent {
    gradeForm!: FormGroup;
    actionButton: string = 'Save';
    formName: string = 'Update Student Results';
    studentsData!: any;
    course: any[] = [];
    selectedCourse: any;
    studentData!: any;
    grade = [
        'A+',
        'A',
        'A-',
        'B+',
        'B',
        'B-',
        'C+',
        'C',
        'C-',
        'D+',
        'D',
        'D-',
        'F',
    ];

    constructor(
        @Inject(MAT_DIALOG_DATA) public editData: any,
        private http: HttpClient,
        private formBuilder: FormBuilder,
        private dialogRef: MatDialogRef<AddResultsComponent>
    ) {}

    ngOnInit(): void {
        this.gradeForm = this.formBuilder.group({
            studentId: ['', Validators.required],
            courseId: ['', Validators.required],
            id: ['', Validators.required],
            date: ['', Validators.required],
            grade: ['', Validators.required],
        });
        this.getStudents();
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
                data.studentEnrolledCourse.map((c: any) => {
                    this.course.push({
                        ...c.enrolledCourse.course,
                        enrolledCourseId: c.enrolledCourseId,
                        date: c.enrolledCourse.date,
                    });
                });
            },
            error: (err) => {
                console.log(err.error);
            },
        });
    }

    onCourseChange(e: any) {
        this.selectedCourse = this.course.filter((c) => c.id == e);
    }

    updateCourse() {
        // this.gradeForm.value.date = this.selectedCourse[0].date.toString();
        // this.gradeForm.value.id = this.selectedCourse[0].enrolledCourseId;
        // this.http
        //     .put('https://localhost:7026/api/enrolledcourse', {
        //         ...this.gradeForm.value,
        //     })
        //     .subscribe({
        //         next: (data) => {
        //             this.gradeForm.reset();
        //             this.dialogRef.close('save');
        //         },
        //         error: (err) => {
        //             console.log(err.error);
        //         },
        //     });
        console.log(this.gradeForm.value);
    }
}
