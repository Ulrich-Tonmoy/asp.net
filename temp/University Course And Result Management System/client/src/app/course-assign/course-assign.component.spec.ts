import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseAssignComponent } from './course-assign.component';

describe('CourseAssignComponent', () => {
  let component: CourseAssignComponent;
  let fixture: ComponentFixture<CourseAssignComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseAssignComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseAssignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
