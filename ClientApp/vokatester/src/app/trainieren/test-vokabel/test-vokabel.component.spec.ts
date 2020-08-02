import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestVokabelComponent } from './test-vokabel.component';

describe('TestVokabelComponent', () => {
  let component: TestVokabelComponent;
  let fixture: ComponentFixture<TestVokabelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestVokabelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestVokabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
