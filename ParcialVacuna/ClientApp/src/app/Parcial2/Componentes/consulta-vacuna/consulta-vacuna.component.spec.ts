import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultaVacunaComponent } from './consulta-vacuna.component';

describe('ConsultaVacunaComponent', () => {
  let component: ConsultaVacunaComponent;
  let fixture: ComponentFixture<ConsultaVacunaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultaVacunaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultaVacunaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
