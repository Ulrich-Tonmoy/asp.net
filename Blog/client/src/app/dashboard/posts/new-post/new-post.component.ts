import { Component, OnInit } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { Category, Post } from '@shared/libs';
import { ToastrService } from 'ngx-toastr';
import { CategoriesService } from 'src/app/core/services/categories.service';
import { PostsService } from 'src/app/core/services/posts.service';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.scss'],
})
export class NewPostComponent implements OnInit {
  permaLink: string = '';
  heroImg: any = '';
  categories: Array<Category> = [];
  postForm: FormGroup = new FormGroup('');
  formStatus: string = 'Add New';
  id: string = '';
  editorConfig: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    translate: 'yes',
    minHeight: '200px',
    maxHeight: '600px',
  };

  constructor(
    private catService: CategoriesService,
    private formBuilder: FormBuilder,
    private postService: PostsService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router
  ) {
    this.route.queryParams.pipe(takeUntilDestroyed()).subscribe((data) => {
      this.id = data['id'];

      if (this.id) {
        this.postService
          .getPostById(data['id'])
          .pipe(takeUntilDestroyed())
          .subscribe((post) => {
            this.postForm = formBuilder.group({
              title: [
                post.title,
                [Validators.required, Validators.minLength(5)],
              ],
              permaLink: [
                { value: post.permaLink, disabled: true },
                Validators.required,
              ],
              excerpt: [
                post.excerpt,
                [Validators.required, Validators.minLength(20)],
              ],
              category: [
                `${post.category.id}/${post.category.name}`,
                Validators.required,
              ],
              heroImg: [''],
              content: [post.content, Validators.required],
            });
            this.heroImg = post.heroImg;
            this.permaLink = post.permaLink;
            this.formStatus = 'Update';
          });
      } else {
        this.postForm = formBuilder.group({
          title: ['', [Validators.required, Validators.minLength(5)]],
          permaLink: [{ value: '', disabled: true }, Validators.required],
          excerpt: ['', [Validators.required, Validators.minLength(20)]],
          category: ['', Validators.required],
          heroImg: ['', Validators.required],
          content: ['', Validators.required],
        });
      }
    });
  }

  ngOnInit(): void {
    this.catService
      .getCategories()
      .pipe(takeUntilDestroyed())
      .subscribe((data) => {
        this.categories = data;
      });
  }

  get fc() {
    return this.postForm.controls;
  }

  onTitleChange(e: any) {
    const title = e.target.value;
    this.permaLink = title.replaceAll(' ', '-');
  }

  onChangeImg($event: any) {
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.heroImg = e.target.result;
    };
    reader.readAsDataURL($event.target.files[0]);
  }

  onSubmit() {
    const postData: Post = {
      id: this.id,
      title: this.postForm.value.title,
      permaLink: this.permaLink,
      category: {
        id: this.postForm.value.category.split('/')[0],
        name: this.postForm.value.category.split('/')[1],
      },
      heroImg: this.heroImg,
      excerpt: this.postForm.value.excerpt,
      content: this.postForm.value.content,
      isFeatured: false,
      views: 0,
      status: 'new',
      createdAt: new Date(),
    };
    if (this.id) {
      this.postService
        .updatePost(this.id, postData)
        .pipe(takeUntilDestroyed())
        .subscribe((response: any) => {
          console.log(response.data);
          this.toastr.success(
            `Post ${response.data.title} updated successfully!`
          );
          this.router.navigate(['dashboard/posts']);
        });
    } else {
      this.postService
        .createPost(postData)
        .pipe(takeUntilDestroyed())
        .subscribe((response: any) => {
          this.toastr.success(
            `Post ${response.data.title} added successfully!`
          );
          this.router.navigate(['dashboard/posts']);
        });
    }
    this.postForm.reset();
    this.heroImg = '';
  }
}
