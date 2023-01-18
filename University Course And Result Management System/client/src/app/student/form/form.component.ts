import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import {
    FormBuilder,
    FormGroup,
    Validators,
    FormControl,
    FormGroupDirective,
    NgForm,
} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ErrorStateMatcher } from '@angular/material/core';

@Component({
    selector: 'student-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.scss'],
})
export class StudentFormComponent {
    studentForm!: FormGroup;
    actionButton: string = 'Register';
    formName: string = 'Add New Student';

    deptData!: any;

    // email input validation
    emailFormControl = new FormControl('', [
        Validators.required,
        Validators.email,
    ]);
    matcher = new MyErrorStateMatcher();

    // date picker
    currentDate = new FormControl(new Date());

    constructor(
        @Inject(MAT_DIALOG_DATA) public editData: any,
        private http: HttpClient,
        private formBuilder: FormBuilder,
        private dialogRef: MatDialogRef<StudentFormComponent>
    ) {}

    ngOnInit(): void {
        this.studentForm = this.formBuilder.group({
            regiNo: [''],
            name: ['', Validators.required],
            contactNo: ['', Validators.required],
            address: ['', Validators.required],
            departmentId: ['', Validators.required],
        });

        this.getDepartment();

        if (this.editData) {
            this.actionButton = 'Update';
            this.formName = `Update Student "${this.editData.regiNo}"`;

            this.studentForm.controls['regiNo'].setValue(this.editData.regiNo);
            this.studentForm.controls['name'].setValue(this.editData.name);
            this.emailFormControl = new FormControl(this.editData.email, [
                Validators.required,
                Validators.email,
            ]);
            this.studentForm.controls['contactNo'].setValue(
                this.editData.contactNo
            );
            this.currentDate = new FormControl(this.editData.date);
            this.studentForm.controls['address'].setValue(
                this.editData.address
            );
            this.studentForm.controls['departmentId'].setValue(
                this.editData.departmentId
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

    formAction() {
        this.studentForm.value.email = this.emailFormControl.value;
        this.studentForm.value.date = this.currentDate.value?.toISOString();
        if (this.editData) {
            this.updateStudent();
        } else {
            this.createStudent();
        }
    }
    createStudent() {
        if (this.studentForm.valid) {
            this.http
                .post(
                    'https://localhost:7026/api/student',
                    this.studentForm.value
                )
                .subscribe({
                    next: (data) => {
                        this.studentForm.reset();
                        this.dialogRef.close('save');
                    },
                    error: (err) => {
                        console.log(err);
                    },
                });
        }
    }

    updateStudent() {
        if (this.studentForm.valid) {
            this.http
                .put('https://localhost:7026/api/student', {
                    ...this.studentForm.value,
                    id: this.editData.id,
                })
                .subscribe({
                    next: (data) => {
                        this.studentForm.reset();
                        this.dialogRef.close('update');
                    },
                    error: (err) => {
                        console.log(err.error);
                    },
                });
        }
    }
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
    isErrorState(
        control: FormControl | null,
        form: FormGroupDirective | NgForm | null
    ): boolean {
        const isSubmitted = form && form.submitted;
        return !!(
            control &&
            control.invalid &&
            (control.dirty || control.touched || isSubmitted)
        );
    }
}
