import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/core/models/category';
import { CategoriesService } from 'src/app/core/services/categories.service';

@Component({
  selector: 'app-category-navbar',
  templateUrl: './category-navbar.component.html',
  styleUrls: ['./category-navbar.component.scss'],
})
export class CategoryNavbarComponent implements OnInit {
  categories: Array<Category> = [];

  constructor(private catService: CategoriesService) {}

  ngOnInit(): void {
    this.catService.getCategories().subscribe((data) => {
      this.categories = data;
    });
  }
}
