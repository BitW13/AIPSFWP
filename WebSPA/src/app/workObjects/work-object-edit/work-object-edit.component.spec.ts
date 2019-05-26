import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkObjectEditComponent } from './work-object-edit.component';

describe('WorkObjectEditComponent', () => {
  let component: WorkObjectEditComponent;
  let fixture: ComponentFixture<WorkObjectEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkObjectEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkObjectEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
