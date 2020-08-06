import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ÜbersichtLektionenComponent } from './übersicht-lektionen.component';

describe('ÜbersichtLektionenComponent', () => {
  let component: ÜbersichtLektionenComponent;
  let fixture: ComponentFixture<ÜbersichtLektionenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ÜbersichtLektionenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ÜbersichtLektionenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
