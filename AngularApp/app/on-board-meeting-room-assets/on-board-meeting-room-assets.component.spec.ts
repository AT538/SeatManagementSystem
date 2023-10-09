import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnBoardMeetingRoomAssetsComponent } from './on-board-meeting-room-assets.component';

describe('OnBoardMeetingRoomAssetsComponent', () => {
  let component: OnBoardMeetingRoomAssetsComponent;
  let fixture: ComponentFixture<OnBoardMeetingRoomAssetsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OnBoardMeetingRoomAssetsComponent]
    });
    fixture = TestBed.createComponent(OnBoardMeetingRoomAssetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
