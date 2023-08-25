import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemRegisterTrainingComponent } from './item-register-training.component';

describe('ItemRegisterTrainingComponent', () => {
  let component: ItemRegisterTrainingComponent;
  let fixture: ComponentFixture<ItemRegisterTrainingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemRegisterTrainingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemRegisterTrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
