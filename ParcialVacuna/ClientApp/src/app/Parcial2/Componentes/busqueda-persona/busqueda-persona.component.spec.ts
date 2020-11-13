import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusquedaPersonaComponent } from './busqueda-persona.component';

describe('BusquedaPersonaComponent', () => {
  let component: BusquedaPersonaComponent;
  let fixture: ComponentFixture<BusquedaPersonaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusquedaPersonaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusquedaPersonaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
