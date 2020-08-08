import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { UebersichtLektionComponent } from './uebersicht-lektion.component';


describe('UebersichtLektionComponent', () => {
  let component: UebersichtLektionComponent;
  let fixture: ComponentFixture<UebersichtLektionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UebersichtLektionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UebersichtLektionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
