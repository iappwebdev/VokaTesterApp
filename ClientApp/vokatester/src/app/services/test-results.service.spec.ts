import { TestBed } from '@angular/core/testing';

import { TestResultsService } from './test-results.service';

describe('TestResultsService', () => {
  let service: TestResultsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestResultsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
