import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnboardFacilityComponent } from './onboard-facility.component';

describe('OnboardFacilityComponent', () => {
  let component: OnboardFacilityComponent;
  let fixture: ComponentFixture<OnboardFacilityComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OnboardFacilityComponent]
    });
    fixture = TestBed.createComponent(OnboardFacilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
