import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MainLernenComponent } from './main-lernen.component';

describe('MainLernenComponent', () => {
  let component: MainLernenComponent;
  let fixture: ComponentFixture<MainLernenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainLernenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainLernenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
