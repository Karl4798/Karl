import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentPlacedComponent } from './department-placed.component';

describe('DepartmentPlacedComponent', () => {
  let component: DepartmentPlacedComponent;
  let fixture: ComponentFixture<DepartmentPlacedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepartmentPlacedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartmentPlacedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
