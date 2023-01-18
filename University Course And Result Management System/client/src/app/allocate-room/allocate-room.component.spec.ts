import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllocateRoomComponent } from './allocate-room.component';

describe('AllocateRoomComponent', () => {
  let component: AllocateRoomComponent;
  let fixture: ComponentFixture<AllocateRoomComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllocateRoomComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllocateRoomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
