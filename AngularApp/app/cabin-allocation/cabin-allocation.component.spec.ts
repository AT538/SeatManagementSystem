import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabinAllocationComponent } from './cabin-allocation.component';

describe('CabinAllocationComponent', () => {
  let component: CabinAllocationComponent;
  let fixture: ComponentFixture<CabinAllocationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CabinAllocationComponent]
    });
    fixture = TestBed.createComponent(CabinAllocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
