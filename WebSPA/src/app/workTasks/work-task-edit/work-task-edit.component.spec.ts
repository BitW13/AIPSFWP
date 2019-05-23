import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkTaskEditComponent } from './work-task-edit.component';

describe('WorkTaskEditComponent', () => {
  let component: WorkTaskEditComponent;
  let fixture: ComponentFixture<WorkTaskEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkTaskEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkTaskEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
