/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SugestoesService } from './Sugestoes.service';

describe('Service: Sugestoes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SugestoesService]
    });
  });

  it('should ...', inject([SugestoesService], (service: SugestoesService) => {
    expect(service).toBeTruthy();
  }));
});
