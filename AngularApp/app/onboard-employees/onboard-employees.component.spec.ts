import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnboardEmployeesComponent } from './onboard-employees.component';

describe('OnboardEmployeesComponent', () => {
  let component: OnboardEmployeesComponent;
  let fixture: ComponentFixture<OnboardEmployeesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OnboardEmployeesComponent]
    });
    fixture = TestBed.createComponent(OnboardEmployeesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
