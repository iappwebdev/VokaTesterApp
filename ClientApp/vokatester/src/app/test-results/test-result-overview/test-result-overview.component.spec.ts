import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestResultOverviewComponent } from './test-result-overview.component';

describe('TestResultOverviewComponent', () => {
  let component: TestResultOverviewComponent;
  let fixture: ComponentFixture<TestResultOverviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestResultOverviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestResultOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
