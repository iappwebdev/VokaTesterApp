import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MainTrainierenComponent } from './main-trainieren.component';


describe('MainTrainierenComponent', () => {
  let component: MainTrainierenComponent;
  let fixture: ComponentFixture<MainTrainierenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainTrainierenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainTrainierenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
