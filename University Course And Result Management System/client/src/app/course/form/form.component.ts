import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'app-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.scss'],
})
export class CourseFormComponent {
    courseForm!: FormGroup;
    actionButton: string = 'Save';
    formName: string = 'Add New Course';

    deptData!: any;
    semesterData!: any;

    constructor(
        @Inject(MAT_DIALOG_DATA) public editData: any,
        private http: HttpClient,
        private formBuilder: FormBuilder,
        private dialogRef: MatDialogRef<CourseFormComponent>
    ) {}

    ngOnInit(): void {
        this.courseForm = this.formBuilder.group({
            code: [
                '',
                Validators.compose([
                    Validators.required,
                    Validators.minLength(5),
                ]),
            ],
            name: ['', Validators.required],
            credit: [
                '',
                Validators.compose([
                    Validators.required,
                    Validators.min(0.5),
                    Validators.max(5),
                ]),
            ],
            description: ['', Validators.required],
            departmentId: ['', Validators.required],
            semesterId: ['', Validators.required],
        });

        this.getDepartment();
        this.getSemester();

        if (this.editData) {
            this.actionButton = 'Update';
            this.formName = `Update Course "${this.editData.code}"`;

            this.courseForm.controls['code'].setValue(this.editData.code);
            this.courseForm.controls['name'].setValue(this.editData.name);
            this.courseForm.controls['credit'].setValue(this.editData.credit);
            this.courseForm.controls['description'].setValue(
                this.editData.description
            );
            this.courseForm.controls['departmentId'].setValue(
                this.editData.departmentId
            );
            this.courseForm.controls['semesterId'].setValue(
                this.editData.semesterId
            );
        }
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
    getSemester() {
        this.http.get('https://localhost:7026/api/semester').subscribe({
            next: (data) => {
                const newData: any = data;
                this.semesterData = newData.data;
            },
            error: (err) => {
                console.log(err.error);
            },
        });
    }

    formAction() {
        if (this.editData) {
            this.updateCourse();
        } else {
            this.createCourse();
        }
    }
    createCourse() {
        if (this.courseForm.valid) {
            this.http
                .post(
                    'https://localhost:7026/api/course',
                    this.courseForm.value
                )
                .subscribe({
                    next: (data) => {
                        this.courseForm.reset();
                        this.dialogRef.close('save');
                    },
                    error: (err) => {
                        console.log(err);
                    },
                });
        }
    }

    updateCourse() {
        if (this.courseForm.valid) {
            this.http
                .put('https://localhost:7026/api/course', {
                    ...this.courseForm.value,
                    id: this.editData.id,
                })
                .subscribe({
                    next: (data) => {
                        this.courseForm.reset();
                        this.dialogRef.close('update');
                    },
                    error: (err) => {
                        console.log(err.error);
                    },
                });
        }
    }
}
