import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { UebersichtLektionenComponent } from './uebersicht-lektionen.component';

describe('UebersichtLektionenComponent', () => {
  let component: UebersichtLektionenComponent;
  let fixture: ComponentFixture<UebersichtLektionenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UebersichtLektionenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UebersichtLektionenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
