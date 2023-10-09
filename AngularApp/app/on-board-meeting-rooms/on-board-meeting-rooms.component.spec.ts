import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnBoardMeetingRoomsComponent } from './on-board-meeting-rooms.component';

describe('OnBoardMeetingRoomsComponent', () => {
  let component: OnBoardMeetingRoomsComponent;
  let fixture: ComponentFixture<OnBoardMeetingRoomsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OnBoardMeetingRoomsComponent]
    });
    fixture = TestBed.createComponent(OnBoardMeetingRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
