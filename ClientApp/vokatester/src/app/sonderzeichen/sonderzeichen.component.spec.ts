import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SonderzeichenComponent } from './sonderzeichen.component';

describe('SonderzeichenComponent', () => {
  let component: SonderzeichenComponent;
  let fixture: ComponentFixture<SonderzeichenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SonderzeichenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SonderzeichenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
