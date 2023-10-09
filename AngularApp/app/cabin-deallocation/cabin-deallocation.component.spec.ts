import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabinDeallocationComponent } from './cabin-deallocation.component';

describe('CabinDeallocationComponent', () => {
  let component: CabinDeallocationComponent;
  let fixture: ComponentFixture<CabinDeallocationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CabinDeallocationComponent]
    });
    fixture = TestBed.createComponent(CabinDeallocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
