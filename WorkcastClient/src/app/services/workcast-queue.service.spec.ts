import { TestBed } from '@angular/core/testing';

import { WorkcastQueueService } from './workcast-queue.service';

describe('WorkcastQueueService', () => {
  let service: WorkcastQueueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkcastQueueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
