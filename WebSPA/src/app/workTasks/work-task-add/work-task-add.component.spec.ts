import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkTaskAddComponent } from './work-task-add.component';

describe('WorkTaskAddComponent', () => {
  let component: WorkTaskAddComponent;
  let fixture: ComponentFixture<WorkTaskAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkTaskAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkTaskAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
