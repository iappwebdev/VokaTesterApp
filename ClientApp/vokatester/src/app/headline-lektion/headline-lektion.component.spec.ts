import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeadlineLektionComponent } from './headline-lektion.component';

describe('HeadlineLektionComponent', () => {
  let component: HeadlineLektionComponent;
  let fixture: ComponentFixture<HeadlineLektionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeadlineLektionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeadlineLektionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
