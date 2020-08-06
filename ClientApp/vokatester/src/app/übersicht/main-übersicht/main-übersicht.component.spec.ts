import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MainÜbersichtComponent } from './main-übersicht.component';

describe('MainÜbersichtComponent', () => {
  let component: MainÜbersichtComponent;
  let fixture: ComponentFixture<MainÜbersichtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainÜbersichtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainÜbersichtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
