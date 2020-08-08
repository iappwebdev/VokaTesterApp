import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MainUebersichtComponent } from './main-uebersicht.component';

describe('MainUebersichtComponent', () => {
  let component: MainUebersichtComponent;
  let fixture: ComponentFixture<MainUebersichtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainUebersichtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainUebersichtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
