import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FreeSeatReportResultComponent } from './free-seat-report-result.component';

describe('FreeSeatReportResultComponent', () => {
  let component: FreeSeatReportResultComponent;
  let fixture: ComponentFixture<FreeSeatReportResultComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FreeSeatReportResultComponent]
    });
    fixture = TestBed.createComponent(FreeSeatReportResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
