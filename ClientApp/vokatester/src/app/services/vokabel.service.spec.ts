import { TestBed } from '@angular/core/testing';

import { VokabelService } from './vokabel.service';

describe('VokabelService', () => {
  let service: VokabelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VokabelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
