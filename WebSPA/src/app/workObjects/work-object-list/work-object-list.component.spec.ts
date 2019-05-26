import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkObjectListComponent } from './work-object-list.component';

describe('WorkObjectListComponent', () => {
  let component: WorkObjectListComponent;
  let fixture: ComponentFixture<WorkObjectListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkObjectListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkObjectListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
