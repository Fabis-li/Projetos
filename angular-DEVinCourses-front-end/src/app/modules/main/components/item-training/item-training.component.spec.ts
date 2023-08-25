import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemTrainingComponent } from './item-training.component';

describe('ItemTrainingComponent', () => {
  let component: ItemTrainingComponent;
  let fixture: ComponentFixture<ItemTrainingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemTrainingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemTrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
