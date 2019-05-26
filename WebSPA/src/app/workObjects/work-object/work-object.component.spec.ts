import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkObjectComponent } from './work-object.component';

describe('WorkObjectComponent', () => {
  let component: WorkObjectComponent;
  let fixture: ComponentFixture<WorkObjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkObjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkObjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
