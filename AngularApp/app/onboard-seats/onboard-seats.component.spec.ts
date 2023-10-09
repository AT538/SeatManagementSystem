import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnboardSeatsComponent } from './onboard-seats.component';

describe('OnboardSeatsComponent', () => {
  let component: OnboardSeatsComponent;
  let fixture: ComponentFixture<OnboardSeatsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OnboardSeatsComponent]
    });
    fixture = TestBed.createComponent(OnboardSeatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
