import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkTaskComponent } from './work-task.component';

describe('WorkTaskComponent', () => {
  let component: WorkTaskComponent;
  let fixture: ComponentFixture<WorkTaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkTaskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
