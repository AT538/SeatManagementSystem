import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnBoardBuildingComponent } from './on-board-building.component';

describe('OnBoardBuildingComponent', () => {
  let component: OnBoardBuildingComponent;
  let fixture: ComponentFixture<OnBoardBuildingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OnBoardBuildingComponent]
    });
    fixture = TestBed.createComponent(OnBoardBuildingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
