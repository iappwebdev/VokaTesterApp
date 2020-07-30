import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LernenLektionComponent } from './lernen-lektion.component';

describe('LernenLektionComponent', () => {
  let component: LernenLektionComponent;
  let fixture: ComponentFixture<LernenLektionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LernenLektionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LernenLektionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
