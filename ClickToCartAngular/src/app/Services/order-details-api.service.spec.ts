import { TestBed } from '@angular/core/testing';

import { OrderDetailsApiService } from './order-details-api.service';

describe('OrderDetailsApiService', () => {
  let service: OrderDetailsApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrderDetailsApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
