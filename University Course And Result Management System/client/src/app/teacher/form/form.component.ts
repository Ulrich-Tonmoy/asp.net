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
    selector: 'app-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.scss'],
})
export class TeacherFormComponent {
    teacherForm!: FormGroup;
    actionButton: string = 'Register';
    formName: string = 'Add New Teacher';

    deptData!: any;
    desData!: any;

    // email input validation
    emailFormControl = new FormControl('', [
        Validators.required,
        Validators.email,
    ]);
    matcher = new MyErrorStateMatcher();

    constructor(
        @Inject(MAT_DIALOG_DATA) public editData: any,
        private http: HttpClient,
        private formBuilder: FormBuilder,
        private dialogRef: MatDialogRef<TeacherFormComponent>
    ) {}

    ngOnInit(): void {
        this.teacherForm = this.formBuilder.group({
            name: ['', Validators.required],
            contactNo: ['', Validators.required],
            address: ['', Validators.required],
            designationId: ['', Validators.required],
            departmentId: ['', Validators.required],
            creditToBeTaken: ['', Validators.required],
        });

        this.getDepartment();
        this.getDesignation();

        if (this.editData) {
            this.actionButton = 'Update';
            this.formName = `Update Teacher "${this.editData.name}"`;

            this.teacherForm.controls['name'].setValue(this.editData.name);
            this.emailFormControl = new FormControl(this.editData.email, [
                Validators.required,
                Validators.email,
            ]);
            this.teacherForm.controls['contactNo'].setValue(
                this.editData.contactNo
            );
            this.teacherForm.controls['address'].setValue(
                this.editData.address
            );
            this.teacherForm.controls['departmentId'].setValue(
                this.editData.departmentId
            );
            this.teacherForm.controls['designationId'].setValue(
                this.editData.designationId
            );
            this.teacherForm.controls['creditToBeTaken'].setValue(
                this.editData.creditToBeTaken
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
    getDesignation() {
        this.http.get('https://localhost:7026/api/designation').subscribe({
            next: (data) => {
                const newData: any = data;
                this.desData = newData.data;
            },
            error: (err) => {
                console.log(err.error);
            },
        });
    }

    formAction() {
        this.teacherForm.value.email = this.emailFormControl.value;
        if (this.editData) {
            this.updateTeacher();
        } else {
            this.createTeacher();
        }
    }
    createTeacher() {
        if (this.teacherForm.valid) {
            this.http
                .post(
                    'https://localhost:7026/api/teacher',
                    this.teacherForm.value
                )
                .subscribe({
                    next: (data) => {
                        this.teacherForm.reset();
                        this.dialogRef.close('save');
                    },
                    error: (err) => {
                        console.log(err);
                    },
                });
        }
    }

    updateTeacher() {
        if (this.teacherForm.valid) {
            this.http
                .put('https://localhost:7026/api/teacher', {
                    ...this.teacherForm.value,
                    id: this.editData.id,
                })
                .subscribe({
                    next: (data) => {
                        this.teacherForm.reset();
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
