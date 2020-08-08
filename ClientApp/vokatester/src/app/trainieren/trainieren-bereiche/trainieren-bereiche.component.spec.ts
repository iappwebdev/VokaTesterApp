import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainierenBereicheComponent } from './trainieren-bereiche.component';

describe('TrainierenBereicheComponent', () => {
  let component: TrainierenBereicheComponent;
  let fixture: ComponentFixture<TrainierenBereicheComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainierenBereicheComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainierenBereicheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
