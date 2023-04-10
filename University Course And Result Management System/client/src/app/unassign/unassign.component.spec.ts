import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnassignComponent } from './unassign.component';

describe('UnassignComponent', () => {
  let component: UnassignComponent;
  let fixture: ComponentFixture<UnassignComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnassignComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UnassignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
