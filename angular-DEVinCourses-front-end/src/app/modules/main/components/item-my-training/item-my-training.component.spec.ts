import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemMyTrainingComponent } from './item-my-training.component';

describe('ItemMyTrainingComponent', () => {
  let component: ItemMyTrainingComponent;
  let fixture: ComponentFixture<ItemMyTrainingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemMyTrainingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemMyTrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
