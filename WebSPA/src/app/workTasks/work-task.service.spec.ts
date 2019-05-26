import { TestBed } from '@angular/core/testing';

import { WorkTaskService } from './work-task.service';

describe('WorkTaskService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkTaskService = TestBed.get(WorkTaskService);
    expect(service).toBeTruthy();
  });
});
