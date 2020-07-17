import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateVokabelComponent } from './create-vokabel.component';

describe('CreateVokabelComponent', () => {
  let component: CreateVokabelComponent;
  let fixture: ComponentFixture<CreateVokabelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateVokabelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateVokabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
