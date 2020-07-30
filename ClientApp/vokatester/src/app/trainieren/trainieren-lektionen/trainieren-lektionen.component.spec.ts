import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { TrainierenLektionenComponent } from './trainieren-lektionen.component';

describe('TrainierenLektionenComponent', () => {
  let component: TrainierenLektionenComponent;
  let fixture: ComponentFixture<TrainierenLektionenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainierenLektionenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainierenLektionenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
