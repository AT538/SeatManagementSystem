import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatDeallocationComponent } from './seat-deallocation.component';

describe('SeatDeallocationComponent', () => {
  let component: SeatDeallocationComponent;
  let fixture: ComponentFixture<SeatDeallocationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SeatDeallocationComponent]
    });
    fixture = TestBed.createComponent(SeatDeallocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
