import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubscribersComponent } from './subscribers.component';

describe('SubscribersComponent', () => {
  let component: SubscribersComponent;
  let fixture: ComponentFixture<SubscribersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SubscribersComponent]
    });
    fixture = TestBed.createComponent(SubscribersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
