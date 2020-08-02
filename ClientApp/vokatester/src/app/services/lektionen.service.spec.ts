import { TestBed } from '@angular/core/testing';

import { LektionenService } from './lektionen.service';

describe('LektionenService', () => {
  let service: LektionenService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LektionenService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
