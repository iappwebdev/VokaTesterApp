import { TestBed } from '@angular/core/testing';

import { FortschrittService } from './fortschritt.service';

describe('FortschrittService', () => {
  let service: FortschrittService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FortschrittService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
