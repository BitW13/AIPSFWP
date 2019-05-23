import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkObjectAddComponent } from './work-object-add.component';

describe('WorkObjectAddComponent', () => {
  let component: WorkObjectAddComponent;
  let fixture: ComponentFixture<WorkObjectAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkObjectAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkObjectAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
