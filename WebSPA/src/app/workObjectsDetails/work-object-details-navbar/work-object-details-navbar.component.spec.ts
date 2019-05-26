import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkObjectDetailsNavbarComponent } from './work-object-details-navbar.component';

describe('WorkObjectDetailsNavbarComponent', () => {
  let component: WorkObjectDetailsNavbarComponent;
  let fixture: ComponentFixture<WorkObjectDetailsNavbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkObjectDetailsNavbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkObjectDetailsNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
