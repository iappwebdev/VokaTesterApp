import { TestBed } from '@angular/core/testing';

import { TrainierenService } from './trainieren.service';

describe('TrainierenService', () => {
  let service: TrainierenService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrainierenService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
