import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkObjectDetailsComponent } from './work-object-details.component';

describe('WorkObjectDetailsComponent', () => {
  let component: WorkObjectDetailsComponent;
  let fixture: ComponentFixture<WorkObjectDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkObjectDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkObjectDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
