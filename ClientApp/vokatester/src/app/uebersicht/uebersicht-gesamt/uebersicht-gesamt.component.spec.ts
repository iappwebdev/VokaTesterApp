import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UebersichtGesamtComponent } from './uebersicht-gesamt.component';

describe('UebersichtGesamtComponent', () => {
  let component: UebersichtGesamtComponent;
  let fixture: ComponentFixture<UebersichtGesamtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UebersichtGesamtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UebersichtGesamtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
