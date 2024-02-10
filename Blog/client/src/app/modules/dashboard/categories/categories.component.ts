import {
  AfterViewInit,
  Component,
  DestroyRef,
  OnInit,
  inject,
} from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Category } from '@shared/libs';
import { ToastrService } from 'ngx-toastr';
import { CategoriesService } from 'src/app/core/services/categories.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss'],
})
export class CategoriesComponent implements OnInit, AfterViewInit {
  categories: Array<Category> = [];
  categoryForm: string = '';
  editingId: string = '';
  destroyRef = inject(DestroyRef);

  constructor(
    private catService: CategoriesService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getCategories();
  }

  public onSubmit = async (formData: any) => {
    const name = formData.value.category;
    if (!this.editingId) {
      this.catService
        .createCategory(name)
        .pipe(takeUntilDestroyed(this.destroyRef))
        .subscribe((_response) => {
          this.toastr.success(`Category ${name} added successfully!`);
        });
    } else {
      this.catService
        .updateCategory(this.editingId, name)
        .pipe(takeUntilDestroyed(this.destroyRef))
        .subscribe((_response) => {
          this.toastr.success(`Category ${name} updated successfully!`);
        });
      this.editingId = '';
    }
    formData.reset();
    this.getCategories();
  };

  public onEdit(cat: Category) {
    this.categoryForm = cat.name;
    this.editingId = cat.id;
  }

  public onDelete(cat: Category) {
    if (confirm(`Do you want to delete category '${cat.name}'?`)) {
      this.catService
        .deleteCategory(cat.id)
        .pipe(takeUntilDestroyed(this.destroyRef))
        .subscribe((_response) => {
          this.toastr.warning(`Category ${name} deleted successfully!`);
        });
      this.getCategories();
    }
  }

  ngAfterViewInit() {
    this.getCategories();
  }

  private getCategories() {
    this.catService
      .getCategories()
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((data) => {
        this.categories = data;
      });
  }
}
