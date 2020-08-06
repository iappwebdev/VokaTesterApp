import { TestBed } from '@angular/core/testing';

import { CheckResultService } from './check-result.service';

describe('CheckResultService', () => {
  let service: CheckResultService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CheckResultService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
