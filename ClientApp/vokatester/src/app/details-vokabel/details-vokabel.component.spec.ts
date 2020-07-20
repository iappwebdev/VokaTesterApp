import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsVokabelComponent } from './details-vokabel.component';

describe('DetailsVokabelComponent', () => {
  let component: DetailsVokabelComponent;
  let fixture: ComponentFixture<DetailsVokabelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailsVokabelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsVokabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
