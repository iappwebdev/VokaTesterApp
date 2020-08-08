import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IpaAlphabetComponent } from './ipa-alphabet.component';

describe('IpaAlphabetComponent', () => {
  let component: IpaAlphabetComponent;
  let fixture: ComponentFixture<IpaAlphabetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IpaAlphabetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IpaAlphabetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
