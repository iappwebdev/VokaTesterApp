import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ÜbersichtLektionComponent } from './übersicht-lektion.component';


describe('ÜbersichtLektionComponent', () => {
  let component: ÜbersichtLektionComponent;
  let fixture: ComponentFixture<ÜbersichtLektionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ÜbersichtLektionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ÜbersichtLektionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
