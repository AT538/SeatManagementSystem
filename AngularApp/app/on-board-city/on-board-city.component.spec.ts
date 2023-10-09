import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnBoardCityComponent } from './on-board-city.component';

describe('OnBoardCityComponent', () => {
  let component: OnBoardCityComponent;
  let fixture: ComponentFixture<OnBoardCityComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OnBoardCityComponent]
    });
    fixture = TestBed.createComponent(OnBoardCityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
