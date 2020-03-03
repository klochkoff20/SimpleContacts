import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomChipListComponent } from './custom-chip-list.component';

describe('CustomChipListComponent', () => {
  let component: CustomChipListComponent;
  let fixture: ComponentFixture<CustomChipListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomChipListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomChipListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
