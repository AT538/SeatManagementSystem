import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnBoardDepartmentComponent } from './on-board-department.component';

describe('OnBoardDepartmentComponent', () => {
  let component: OnBoardDepartmentComponent;
  let fixture: ComponentFixture<OnBoardDepartmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OnBoardDepartmentComponent]
    });
    fixture = TestBed.createComponent(OnBoardDepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
