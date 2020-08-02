import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SonderzeichenLeisteComponent } from './sonderzeichen-leiste.component';

describe('SonderzeichenLeisteComponent', () => {
  let component: SonderzeichenLeisteComponent;
  let fixture: ComponentFixture<SonderzeichenLeisteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SonderzeichenLeisteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SonderzeichenLeisteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
