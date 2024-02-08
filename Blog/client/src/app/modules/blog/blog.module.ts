import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { SingleCategoryComponent } from './pages/single-category/single-category.component';
import { SinglePostComponent } from './pages/single-post/single-post.component';
import { AboutUsComponent } from './pages/about-us/about-us.component';
import { TermsAndConditionsComponent } from './pages/terms-and-conditions/terms-and-conditions.component';
import { ContactUsComponent } from './pages/contact-us/contact-us.component';
import { BlogComponent } from './blog.component';
import { CategoryNavbarComponent } from './layouts/category-navbar/category-navbar.component';
import { SubscriptionFormComponent } from './subscription-form/subscription-form.component';
import { CommentFormComponent } from './comments/comment-form/comment-form.component';
import { CommentListComponent } from './comments/comment-list/comment-list.component';
import { PostCardComponent } from './layouts/post-card/post-card.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    BlogComponent,
    CategoryNavbarComponent,
    HomeComponent,
    SingleCategoryComponent,
    SinglePostComponent,
    TermsAndConditionsComponent,
    ContactUsComponent,
    SubscriptionFormComponent,
    CommentFormComponent,
    CommentListComponent,
    AboutUsComponent,
    PostCardComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: '',
        component: BlogComponent,
        children: [
          { path: '', component: HomeComponent, pathMatch: 'full' },
          {
            path: 'category/:category/:id',
            component: SingleCategoryComponent,
          },
          { path: 'post/:id', component: SinglePostComponent },
          { path: 'about', component: AboutUsComponent },
          { path: 'terms-conditions', component: TermsAndConditionsComponent },
          { path: 'contact', component: ContactUsComponent },
        ],
      },
    ]),
  ],
})
export class BlogModule {}
