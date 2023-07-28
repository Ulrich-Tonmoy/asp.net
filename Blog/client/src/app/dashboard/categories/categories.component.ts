import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/category';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss'],
})
export class CategoriesComponent implements OnInit {
  categories: Array<Category> = [];
  categoryForm: string = '';
  editingId: string = '';

  constructor(private catService: CategoriesService) {}

  ngOnInit(): void {
    this.getCategories();
  }

  onSubmit = (formData: any) => {
    let name = formData.value.category;
    if (!this.editingId) {
      let category: Category = {
        id: crypto.randomUUID(),
        name,
      };

      this.catService.createCategory(category);
    } else {
      this.catService.updateCategory(this.editingId, name);
      this.editingId = '';
    }
    formData.reset();
    this.getCategories();
  };

  onEdit(cat: Category) {
    this.categoryForm = cat.name;
    this.editingId = cat.id;
  }

  onDelete(cat: Category) {
    if (confirm(`Do you want to delete category '${cat.name}'?`)) {
      this.catService.deleteCategory(cat.id, cat.name);
      this.getCategories();
    }
  }

  private getCategories() {
    this.catService.getCategories().subscribe((data) => {
      this.categories = data;
    });
  }
}
