import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'app-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.scss'],
})
export class FormComponent {
    deptForm!: FormGroup;
    actionButton: string = 'Save';
    formName: string = 'Add New Department';

    constructor(
        @Inject(MAT_DIALOG_DATA) public editData: any,
        private http: HttpClient,
        private formBuilder: FormBuilder,
        private dialogRef: MatDialogRef<FormComponent>
    ) {}

    ngOnInit(): void {
        this.deptForm = this.formBuilder.group({
            code: ['', Validators.required],
            name: ['', Validators.required],
        });

        if (this.editData) {
            this.actionButton = 'Update';
            this.formName = `Update ${this.editData.code} Department`;
            this.deptForm.controls['code'].setValue(this.editData.code);
            this.deptForm.controls['name'].setValue(this.editData.name);
        }
    }

    formAction() {
        if (this.editData) {
            this.updateDept();
        } else {
            this.createDept();
        }
    }

    createDept() {
        if (this.deptForm.valid) {
            this.http
                .post(
                    'https://localhost:7026/api/department',
                    this.deptForm.value
                )
                .subscribe({
                    next: (data) => {
                        console.log(data);
                        this.deptForm.reset();
                        this.dialogRef.close('save');
                    },
                    error: (err) => {
                        console.log(err.error);
                    },
                });
        }
    }

    updateDept() {
        if (this.deptForm.valid) {
            this.http
                .put('https://localhost:7026/api/department', {
                    ...this.deptForm.value,
                    id: this.editData.id,
                })
                .subscribe({
                    next: (data) => {
                        console.log(data);
                        this.deptForm.reset();
                        this.dialogRef.close('update');
                    },
                    error: (err) => {
                        console.log(err.error);
                    },
                });
        }
    }
}
