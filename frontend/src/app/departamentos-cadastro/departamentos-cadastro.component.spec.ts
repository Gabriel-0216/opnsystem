import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartamentosCadastroComponent } from './departamentos-cadastro.component';

describe('DepartamentosCadastroComponent', () => {
  let component: DepartamentosCadastroComponent;
  let fixture: ComponentFixture<DepartamentosCadastroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepartamentosCadastroComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartamentosCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
