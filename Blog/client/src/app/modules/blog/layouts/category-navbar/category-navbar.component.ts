import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Category } from '@shared/libs';
import { CategoriesService } from 'src/app/core/services/categories.service';

@Component({
  selector: 'app-category-navbar',
  templateUrl: './category-navbar.component.html',
  styleUrls: ['./category-navbar.component.scss'],
})
export class CategoryNavbarComponent implements OnInit {
  categories: Array<Category> = [];
  destroyRef = inject(DestroyRef);

  constructor(private catService: CategoriesService) {}

  ngOnInit(): void {
    this.catService
      .getCategories()
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((data) => {
        this.categories = data;
      });
  }
}
