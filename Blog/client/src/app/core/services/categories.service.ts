import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient, private toastr: ToastrService) {}

  createCategory = (name: string) => {
    this.http.post(`${this.baseUrl}/category`, { name }).subscribe(
      (response: any) => {
        console.log(response);
        this.toastr.success(`Category ${name} added successfully!`);
      },
      (error: any) => {
        this.toastr.error('Error occurred creating category!');
        this.toastr.error(error);
      }
    );
  };

  getCategories = () => {
    return this.http
      .get(`${this.baseUrl}/category`)
      .pipe(map((actions: any) => actions.data));
  };

  updateCategory = (id: string, name: string) => {
    this.http.put(`${this.baseUrl}/category`, { id, name }).subscribe(
      (response: any) => {
        console.log(response.data);
        this.toastr.success(`Category ${name} updated successfully!`);
      },
      (error: any) => {
        this.toastr.error('Error occurred updating category!');
        this.toastr.error(error);
      }
    );
  };

  deleteCategory = (id: string, name: string) => {
    this.http.delete(`${this.baseUrl}/category/${id}`).subscribe(
      (response: any) => {
        console.log(response);
        this.toastr.warning(`Category ${name} deleted successfully!`);
      },
      (error: any) => {
        this.toastr.error('Error occurred deleting category!');
        this.toastr.error(error);
      }
    );
  };
}
