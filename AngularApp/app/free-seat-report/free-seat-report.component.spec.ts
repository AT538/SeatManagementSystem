import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FreeSeatReportComponent } from './free-seat-report.component';

describe('FreeSeatReportComponent', () => {
  let component: FreeSeatReportComponent;
  let fixture: ComponentFixture<FreeSeatReportComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FreeSeatReportComponent]
    });
    fixture = TestBed.createComponent(FreeSeatReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
