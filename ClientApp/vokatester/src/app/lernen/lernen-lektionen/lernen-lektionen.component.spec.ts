import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { LernenLektionenComponent } from './lernen-lektionen.component';

describe('LernenLektionenComponent', () => {
  let component: LernenLektionenComponent;
  let fixture: ComponentFixture<LernenLektionenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LernenLektionenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LernenLektionenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
