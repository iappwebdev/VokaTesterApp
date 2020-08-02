import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainierenLektionComponent } from './trainieren-lektion.component';

describe('TrainierenLektionComponent', () => {
  let component: TrainierenLektionComponent;
  let fixture: ComponentFixture<TrainierenLektionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainierenLektionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainierenLektionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
