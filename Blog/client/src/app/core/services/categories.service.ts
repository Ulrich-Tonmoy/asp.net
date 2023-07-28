import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  constructor(private http: HttpClient, private toastr: ToastrService) {}

  createCategory = (category: Category) => {
    this.http.post('http://localhost:3000/categories', category).subscribe(
      (response: any) => {
        console.log(response);
        this.toastr.success(`Category ${category.name} added successfully!`);
      },
      (error: any) => {
        this.toastr.error('Error occurred creating category!');
        this.toastr.error(error);
      }
    );
  };

  getCategories = () => {
    return this.http
      .get('http://localhost:3000/categories')
      .pipe(map((actions: any) => actions));
  };

  updateCategory = (id: string, name: string) => {
    this.http
      .patch(`http://localhost:3000/categories/${id}`, { name })
      .subscribe(
        (response: any) => {
          console.log(response);
          this.toastr.success(`Category ${name} updated successfully!`);
        },
        (error: any) => {
          this.toastr.error('Error occurred updating category!');
          this.toastr.error(error);
        }
      );
  };

  deleteCategory = (id: string, name: string) => {
    this.http.delete(`http://localhost:3000/categories/${id}`).subscribe(
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
