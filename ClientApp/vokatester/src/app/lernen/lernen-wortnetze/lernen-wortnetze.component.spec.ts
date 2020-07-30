import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { LernenWortnetzeComponent } from './lernen-wortnetze.component';

describe('LernenWortnetzeComponent', () => {
  let component: LernenWortnetzeComponent;
  let fixture: ComponentFixture<LernenWortnetzeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LernenWortnetzeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LernenWortnetzeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
