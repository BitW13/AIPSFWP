import { TestBed } from '@angular/core/testing';

import { WorkObjectService } from './work-object.service';

describe('WorkObjectService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkObjectService = TestBed.get(WorkObjectService);
    expect(service).toBeTruthy();
  });
});
