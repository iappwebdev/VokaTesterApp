import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeVokabelnComponent } from './home-vokabeln.component';

describe('HomeVokabelnComponent', () => {
  let component: HomeVokabelnComponent;
  let fixture: ComponentFixture<HomeVokabelnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeVokabelnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeVokabelnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
