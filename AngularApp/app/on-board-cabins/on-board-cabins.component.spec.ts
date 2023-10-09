import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnBoardCabinsComponent } from './on-board-cabins.component';

describe('OnBoardCabinsComponent', () => {
  let component: OnBoardCabinsComponent;
  let fixture: ComponentFixture<OnBoardCabinsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OnBoardCabinsComponent]
    });
    fixture = TestBed.createComponent(OnBoardCabinsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
