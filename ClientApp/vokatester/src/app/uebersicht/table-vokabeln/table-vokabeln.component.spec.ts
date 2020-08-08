import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableVokabelnComponent } from './table-vokabeln.component';

describe('TableVokabelnComponent', () => {
  let component: TableVokabelnComponent;
  let fixture: ComponentFixture<TableVokabelnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableVokabelnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableVokabelnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
