import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableTestResultsComponent } from './table-test-results.component';

describe('TableTestResultsComponent', () => {
  let component: TableTestResultsComponent;
  let fixture: ComponentFixture<TableTestResultsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableTestResultsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableTestResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
