import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainierenBereichComponent } from './trainieren-bereich.component';

describe('TrainierenBereichComponent', () => {
  let component: TrainierenBereichComponent;
  let fixture: ComponentFixture<TrainierenBereichComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainierenBereichComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainierenBereichComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
