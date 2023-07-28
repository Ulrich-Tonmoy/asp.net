import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { HomeComponent } from './home/home.component';
import { CategoriesComponent } from './categories/categories.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AllPostComponent } from './posts/all-post/all-post.component';
import { NewPostComponent } from './posts/new-post/new-post.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { SharedModule } from '../shared/shared.module';
import { SubscribersComponent } from './subscribers/subscribers.component';

@NgModule({
  declarations: [
    DashboardComponent,
    HomeComponent,
    CategoriesComponent,
    AllPostComponent,
    NewPostComponent,
    SubscribersComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    AngularEditorModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {
        path: '',
        component: DashboardComponent,
        children: [
          { path: '', component: HomeComponent, pathMatch: 'full' },
          { path: 'categories', component: CategoriesComponent },
          { path: 'posts', component: AllPostComponent },
          { path: 'posts/new', component: NewPostComponent },
          { path: 'subscribers', component: SubscribersComponent },
        ],
      },
    ]),
  ],
})
export class DashboardModule {}
